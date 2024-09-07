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
    }

    public void Immerse()
    {
        using var arena = new frmArena();

        arena.ShowDialog();
    }
}
