using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Reflection;

namespace ScorchGore.Arena;

public partial class frmArena : Form
{
    public Bitmap Image;
    public Graphics BackBuffer;

    private bool mitMausVerschieben;
    private Point mitMausVerschiebenAnfang;
    private readonly GoreArena _arena;
    private int viewportOffsetX = 0;
    private int viewportOffsetY = 0;
    private readonly CancellationTokenSource cancelSource = new();
    private readonly Keyboard kybd = new();
    private long frames = 0;
    private long time = 0;
    private Stopwatch stopWatch = new();

    public frmArena(GoreArena arena)
    {
        _arena = arena;
        InitializeComponent();
        _arena.Target = this;
        Image = new(1, 1, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        BackBuffer = Graphics.FromImage(Image);
    }

    public void SetupBackbuffer(int width, int height)
    {
        Image = new(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        BackBuffer = Graphics.FromImage(Image);
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
    }

    protected async override void OnPaint(PaintEventArgs e)
    {
        stopWatch.Restart();
        var color = Random.Shared.Next(3) switch
        {
            0 => Brushes.SaddleBrown,
            1 => Brushes.Beige,
            2 => Brushes.BlueViolet,
            _ => throw new NotImplementedException()
        };

        BackBuffer.FillEllipse(color, 10, 10, 30, 30);
        e.Graphics.DrawImageUnscaledAndClipped(
            Image,
            new(0, 0, Image.Width, Image.Height)
        );

        stopWatch.Stop();
        ++frames;
        var frameTime = stopWatch.ElapsedMilliseconds;

        if(frameTime < 16)
        {
            var wait = 16 - frameTime;
            frameTime += wait;

            await Task.Delay((int)wait);
        }

        time += frameTime;
        var rate = (1.0 / frameTime) * 1000f;
        Text = rate.ToString("#0");
        Invalidate();
    }

    private void frmArena_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.ControlKey)
        {
            Cursor = Cursors.NoMove2D;
        }

        if (e.KeyCode == Keys.Right)
        {
            viewportOffsetX += 2;
            viewportOffsetY -= 1;
        }
    }

    private void frmArena_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.ControlKey)
        {
            Cursor = Cursors.Default;
        }
    }

    private void frmArena_Load(object sender, EventArgs e)
    {
        typeof(Form).InvokeMember(
            nameof(DoubleBuffered),
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null,
            this,
            [true]
        );
    }

    private void frmArena_MouseDown(object sender, MouseEventArgs e)
    {
        mitMausVerschieben = true;
        mitMausVerschiebenAnfang = e.Location;
    }

    private void frmArena_MouseMove(object sender, MouseEventArgs e)
    {
        if (mitMausVerschieben)
        {
            //if (kybd.CtrlKeyDown)
            //{
            //    var desiredPos = new Point(
            //        pnlArena.Left + (e.X - mitMausVerschiebenAnfang.X),
            //        pnlArena.Top + (e.Y - mitMausVerschiebenAnfang.Y)
            //    );

            //    if (desiredPos.X > 0)
            //    {
            //        desiredPos.X = 0;
            //    }

            //    if (desiredPos.Y > 0)
            //    {
            //        desiredPos.Y = 0;
            //    }

            //    if (-desiredPos.X > (pnlArena.Width - Width))
            //    {
            //        desiredPos.X = -(pnlArena.Width - Width);
            //    }

            //    if (-desiredPos.Y > (pnlArena.Height - Height))
            //    {
            //        desiredPos.Y = -(pnlArena.Height - Height);
            //    }

            //    pnlArena.Location = desiredPos;
            //}
            //else
            //{
                Location = new Point(
                    (Location.X - mitMausVerschiebenAnfang.X) + e.X,
                    (Location.Y - mitMausVerschiebenAnfang.Y) + e.Y
                );

                Update();
            //}
        }
    }

    private void frmArena_MouseUp(object sender, MouseEventArgs e)
    {
        mitMausVerschieben = false;
    }
}
