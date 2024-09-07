using ScorchGore.Arena;
using ScorchGore.GameSession;

namespace ScorchGore.Forms;

public partial class frmGame : Form
{
    private readonly GoreSession _session;

    public frmGame(GoreSession session)
    {
        _session = session;

        InitializeComponent();

        /* any newly started (or newly replayed) game has stuff at the beginning
         * that tells us who the opponent is, and who won the SSP. evaluate that now */
    }

    public void DoSomething()
    {
        ReadUp();
        Show();
        if (ShouldAutoImmerse())
        {
            Immerse();
        }
    }

    private void ReadUp()
    {
        foreach (var command in _session.Sequencer.ProcessedCommands)
        {
            switch (command.Command)
            {
                case Sequencer.SequencerCommands.OHAI:
                    if (_session.AmITheInitiatorEven)
                    {
                        Text = command.Arguments;
                    }

                    break;

                case Sequencer.SequencerCommands.HELO:
                    if (_session.AmIThePeerOdd)
                    {
                        Text = command.Arguments;
                    }

                    break;
            }
        }
    }

    private bool ShouldAutoImmerse()
    {
        return false;
    }

    public void Immerse()
    {
        using var arena = new frmArena();

        arena.ShowDialog(this);
    }
}
