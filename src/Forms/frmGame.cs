using ScorchGore.Arena;
using ScorchGore.Constants;
using ScorchGore.GameSession;
using ScorchGore.Sequencer;

namespace ScorchGore.Forms;

public partial class frmGame : Form
{
    private readonly GoreSession _session;
    private readonly GoreArena _arena;
    private readonly frmArena _arenaWindow;
    private GameState _state = GameState.Unknown;

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

        _state = newState;
        Invoke(() =>
        {
            switch (_state)
            {
                case GameState.GameEngine:
                    lblStatus.Text = "Spiellogik";
                    break;

                case GameState.MyTurn:
                    lblStatus.Text = "ich bin dran";
                    break;

                case GameState.OpponentsTurn:
                    lblStatus.Text = "Gegner ist dran";
                    break;

                default:
                    lblStatus.Text = "initialisieren";
                    break;
            }

            lblTurn.Text = _session.Watermark.ToString();
        });
    }

    public void DoSomething()
    {
        SetState(GameState.OpponentsTurn);
        PrepareArenaAndReadUp();
        Show();
        if (ShouldAutoImmerse())
        {
            Immerse();
        }

        ThreadPool.QueueUserWorkItem((_) =>
        {
            do
            {
                Thread.Sleep(333);

                if (_state == GameState.OpponentsTurn)
                {
                    if (_session.Sequencer.PollPopPeerAction())
                    {
                        Invoke(() =>
                        {
                            ProcessGameQueue();
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
    private void PrepareArenaAndReadUp()
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
                    ExecuteCommand(command, isReplay: true);
                    break;
            }
        }

        ProcessGameQueue();
    }

    private void ProcessGameQueue()
    {
        while (_session.Sequencer.CommandQueue.TryPeek(out var command))
        {
            ExecuteCommand(command, isReplay: false);
        }
    }

    private bool PushAndExecuteCommand(SequencerCommand command)
    {
        if(!_session.Sequencer.MyTurnPushCommand([command]))
        {
            return false;
        }

        var executedCommand = ExecuteCommand(command);

        // we consider it succeeded if the command that
        // was executed, is the command the had been
        // commanded to execute. we may reconsider this
        // later on, if maybe substitution is useful
        return executedCommand.Command == command.Command;
    }

    private SequencerCommand ExecuteCommand(SequencerCommand command, bool isReplay = false)
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
            _arenaWindow.MdiParent = MdiParent;
            _arenaWindow.Show();
        }
    }

    private void frmGame_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;

            var command = ValidateInput();
            if(command.isValid)
            {
                try
                {
                    txtOomph.ReadOnly = true;
                    txtCommand.ReadOnly = true;
                    if (PushAndExecuteCommand(command.input))
                    {
                        txtCommand.Clear();
                        txtOomph.Clear();
                    }
                }
                finally
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
