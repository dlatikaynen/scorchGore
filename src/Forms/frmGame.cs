using ScorchGore.Arena;
using ScorchGore.Constants;
using ScorchGore.Sequencer;

namespace ScorchGore.Forms;

public partial class frmGame : Form
{
    private readonly GoreSession _session;
    private readonly GoreArena _arena;
    private readonly frmArena _arenaWindow;
    private GameState _state = GameState.Unknown;
    private GameState _whosTurnFromMyPerspective = GameState.Unknown;

    public frmGame(GoreSession session)
    {
        _session = session;
        _arena = new GoreArena();
        _arenaWindow = new frmArena(_arena);

        InitializeComponent();

        /* any newly started (or newly replayed) game has stuff at the beginning
         * that tells us who the opponent is, and who won the SSP. evaluate that now */
    }

    public void SetState(GameState newState)
    {
        if (_state == newState)
        {
            return;
        }

        if (newState == GameState.MyTurn || newState == GameState.OpponentsTurn)
        {
            _whosTurnFromMyPerspective = newState;
        }
        else if (_state == GameState.MyTurn || _state == GameState.OpponentsTurn)
        {
            _whosTurnFromMyPerspective = _state;
        }

        _state = newState;
        Invoke(() =>
        {
            switch (_state)
            {
                case GameState.GameEngine:
                    lblStatus.Text = "Spiellogik";
                    txtCommand.ReadOnly = true;
                    txtOomph.ReadOnly = true;                    
                    break;

                case GameState.MyTurn:
                    lblStatus.Text = "ich bin dran";
                    txtCommand.ReadOnly = false;
                    txtOomph.ReadOnly = false;
                    if (WindowState == FormWindowState.Minimized)
                    {
                        WindowState = FormWindowState.Normal;
                    }

                    BringToFront();
                    txtCommand.Focus();
                    break;

                case GameState.OpponentsTurn:
                    lblStatus.Text = "Gegner ist dran";
                    txtCommand.ReadOnly = true;
                    txtOomph.ReadOnly = true;
                    break;

                default:
                    lblStatus.Text = "initialisieren";
                    txtCommand.ReadOnly = true;
                    txtOomph.ReadOnly = true;
                    break;
            }

            lblTurn.Text = _session.Watermark.ToString();
        });
    }

    public async Task DoSomething()
    {
        SetState(GameState.OpponentsTurn);
        await PrepareArenaAndReadUp();
        Show();
        if (ShouldAutoImmerse())
        {
            Immerse();
        }

        ThreadPool.QueueUserWorkItem(async (_) =>
        {
            do
            {
                Thread.Sleep(333);

                if (_state == GameState.OpponentsTurn)
                {
                    if (_session.Sequencer.PollPopPeerAction())
                    {
                        await Invoke(async () =>
                        {
                            await ProcessGameQueue();
                        });
                    }
                }
            } while (true);
        });
    }

    /// <summary>
    /// This function will replay the whole story, and bring the arena
    /// up to exactly the status and appearance, pixel-perfectly, like
    /// it was by the time the game was interrupted. Starting a new
    /// game is merely an edge case of this algorithm.
    /// </summary>
    private async Task PrepareArenaAndReadUp()
    {
        foreach (var command in _session.Sequencer.ProcessedCommands)
        {
            switch (command.Command)
            {
                case SequencerCommands.OHAI:
                    if (_session.AmITheInitiatorEven)
                    {
                        Text = command.Arguments;
                    }

                    break;

                case SequencerCommands.HELO:
                    if (_session.AmIThePeerOdd)
                    {
                        Text = command.Arguments;
                    }

                    break;

                default:
                    await ExecuteCommand(command, isReplay: true);
                    break;
            }
        }

        await ProcessGameQueue();
    }

    private async Task ProcessGameQueue()
    {
        while (_session.Sequencer.CommandQueue.TryPeek(out var command))
        {
            await ExecuteCommand(command, isReplay: false);
        }
    }

    private async Task<bool> PushAndExecuteCommand(SequencerCommand command)
    {
        if(!_session.Sequencer.MyTurnPushCommand([command]))
        {
            return false;
        }

        _session.Sequencer.CommandQueue.Enqueue(command);

        var executedCommand = await ExecuteCommand(command);

        // we consider it succeeded if the command that
        // was executed, is the command the had been
        // commanded to execute. we may reconsider this
        // later on, if maybe substitution is useful
        return executedCommand.Command == command.Command;
    }

    private async Task<SequencerCommand> ExecuteCommand(SequencerCommand command, bool isReplay = false)
    {
        switch (command.Command)
        {
            case SequencerCommands.OHAI:
            case SequencerCommands.HELO:
                // they are only looked at in stages where they
                // have necessarily already been consumed
                break;

            case SequencerCommands.CANVAS_THE_CITY_AND_BRUSH_THE_BACKDROP:
                _arena.Initialize(1);
                break;

            case SequencerCommands.INITIATORS_TURN:
                if (_session.AmIThePeerOdd)
                {
                    // pong!
                    SetState(GameState.OpponentsTurn);
                    await PushAndExecuteCommand(new() { Command = SequencerCommands.ACK });
                }

                break;

            case SequencerCommands.ACK:
                if (_session.AmITheInitiatorEven)
                {
                    SetState(GameState.MyTurn);
                }

                break;

            case SequencerCommands.TURN_OF_HE_WHOMST_JOINED:
                if (_session.AmIThePeerOdd)
                {
                    SetState(GameState.MyTurn);
                }

                break;

            case SequencerCommands.FIRE_IN_THE_HOLE:
                // shoot!
                SetState(GameState.GameEngine);

                int fromPlayer = 0;
                int thruPlayer = 0;

                if(_session.AmIThePeerOdd)
                {
                    // I am player 1. my opponent is player 2. if it is my turn, then we shoot 1 ==> 2. if it is their turn, we shoot 2 ==> 1
                    fromPlayer = _whosTurnFromMyPerspective == GameState.MyTurn ? 1 : 2;
                    thruPlayer = _whosTurnFromMyPerspective == GameState.MyTurn ? 2 : 1;
                }
                else if(_session.AmITheInitiatorEven)
                {
                    // I am player 2. my opponent is player 1. if it is my turn, then we shoot 2 ==> 1. if it is their turn, we shoot 1 ==> 2
                    fromPlayer = _whosTurnFromMyPerspective == GameState.MyTurn ? 2 : 1;
                    thruPlayer = _whosTurnFromMyPerspective == GameState.MyTurn ? 1 : 2;
                }

                if (fromPlayer > 0 && thruPlayer > 0)
                {
                    var result = _arena.Shoot(fromPlayer, thruPlayer, command);

                    if (result.Ergebnis != SchussErgebnis.NichtGeschossen)
                    {
                        if (_whosTurnFromMyPerspective == GameState.OpponentsTurn)
                        {
                            SetState(GameState.MyTurn);
                        }
                        else
                        {
                            // now my turn is over and we continue
                            // waiting and polling the opponent's queue
                            SetState(GameState.OpponentsTurn);
                        }
                    }
                }

                break;
        }

        if (!isReplay)
        {
            return _session.Sequencer.ConsumeOne();
        }

        return command;
    }

    private bool ShouldAutoImmerse()
    {
        return true;
    }

    public void Immerse()
    {
        if (_arenaWindow.Visible)
        {
            _arenaWindow.BringToFront();
        }
        else
        {
            _arenaWindow.Text = Text;
            //_arenaWindow.MdiParent = MdiParent;
            _arenaWindow.Show();
        }
    }

    private async void frmGame_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;

            var command = ValidateInput();
            if(command.isValid)
            {
                txtOomph.ReadOnly = true;
                txtCommand.ReadOnly = true;
                if (await PushAndExecuteCommand(command.input))
                {
                    txtCommand.Clear();
                    txtOomph.Clear();
                }
                else
                {
                    txtCommand.ReadOnly = false;
                    txtOomph.ReadOnly = false;
                }
            }
        }
    }

    private (bool isValid, SequencerCommand input) ValidateInput()
    {
        var command = new SequencerCommand
        {
            Command = SequencerCommands.INDETERMINATE
        };

        if(int.TryParse(txtOomph.Text, out int oomph) && oomph > 0 && oomph <= GameLogicConstants.MaxOomph)
        {
            var rawCommand = txtCommand.Text.Trim();

            if(string.IsNullOrEmpty(rawCommand))
            {
                BringToFront();
                txtCommand.Focus();
            }
            else
            {
                // some potentially valid input
                if (int.TryParse(rawCommand, out int angle) && angle > 0)
                {
                    command.Command = SequencerCommands.FIRE_IN_THE_HOLE;
                    command.Arguments = $"{angle} {oomph}";

                    return (isValid: true, input: command);
                }
            }
        }
        else
        {
            BringToFront();
            txtOomph.Focus();
        }

        return (isValid: false, input: command);
    }
}
