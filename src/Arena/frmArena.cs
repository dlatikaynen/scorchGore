using System.Drawing.Imaging;
using System.Reflection;

namespace ScorchGore.Arena;

public partial class frmArena : Form
{
    private readonly GoreArena _arena;
    private int viewportOffsetX = 0;
    private int viewportOffsetY = 0;

    public frmArena(GoreArena arena)
    {
        _arena = arena;
        InitializeComponent();
        _arena.Target = pnlViewport;

#if DEBUG
        TopMost = false;
#endif
    }

    //private Bitmap Image => _arena.Image;

    private void frmArena_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Right)
        {
            viewportOffsetX += 2;
            viewportOffsetY -= 1;
            pnlViewport.Invalidate();
        }
    }

    private void frmArena_Load(object sender, EventArgs e)
    {
        typeof(Panel).InvokeMember(
            nameof(DoubleBuffered),
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null,
            pnlViewport, 
            [true]
        );
    }
}
