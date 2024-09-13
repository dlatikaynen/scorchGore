using System.Drawing.Imaging;
using System.Reflection;

namespace ScorchGore.Arena;

public partial class frmArena : Form
{
    private Bitmap image = new(2000, 2000);
    private CachedBitmap? cachedImage = null;
    private int viewportOffsetX = 0;
    private int viewportOffsetY = 0;

    public frmArena()
    {
        InitializeComponent();

#if DEBUG
        TopMost = false;
#endif
    }

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
        using (var canvas = Graphics.FromImage(image))
        {
            canvas.FillEllipse(Brushes.Chocolate, 0, 0, 2000, 2000);
        }

        typeof(Panel).InvokeMember(
            nameof(DoubleBuffered),
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null,
            pnlViewport, 
            [true]
        );
    }

    private void pnlViewport_Paint(object sender, PaintEventArgs e)
    {
        if(cachedImage == null)
        {
            cachedImage = new(image, e.Graphics);
        }

        e.Graphics.DrawCachedBitmap(cachedImage, viewportOffsetX, viewportOffsetY);
    }
}
