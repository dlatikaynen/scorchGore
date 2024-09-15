using ScorchGore.Arena;
using ScorchGore.GameSession;
using ScorchGore.Sequencer;

namespace ScorchGore.Forms;

public partial class frmGame : Form
{
    private readonly GoreSession _session;
    private readonly GoreArena _arena;

    public frmGame(GoreSession session)
    {
        _session = session;
        _arena = new GoreArena();

        InitializeComponent();

        /* any newly started (or newly replayed) game has stuff at the beginning
         * that tells us who the opponent is, and who won the SSP. evaluate that now */
    }

    public void DoSomething()
    {
        PrepareArenaAndReadUp();
        Show();
        if (ShouldAutoImmerse())
        {
            Immerse();
        }
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

        while( _session.Sequencer.CommandQueue.TryPeek(out var command))
        {
            ExecuteCommand(command, isReplay: false);
        }
    }

    private void ExecuteCommand(SequencerCommand command, bool isReplay = false)
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
        }

        if (!isReplay)
        {
            _session.Sequencer.ConsumeOne();
        }
    }

    private bool ShouldAutoImmerse()
    {
        return true;
    }

    public void Immerse()
    {
        using var arena = new frmArena(_arena);

        arena.ShowDialog(this);
    }
}
