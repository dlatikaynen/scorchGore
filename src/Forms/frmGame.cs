using ScorchGore.Arena;

namespace ScorchGore.Forms;

public partial class frmGame : Form
{
    public frmGame()
    {
        InitializeComponent();
    }

    public void Immerse()
    {
        using var arena = new frmArena();

        arena.ShowDialog();
    }
}
