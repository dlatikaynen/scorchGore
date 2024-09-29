using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Reflection;

namespace ScorchGore.Leved;

public partial class frmLeved : Form
{
    public Bitmap Image;
    public Graphics BackBuffer;

    private readonly GoreLeved _viewport;
    private readonly Keyboard kybd = new();
    private readonly Stopwatch stopWatch = new();

    private Point[] gridPoints = [];
    private Point mitMausVerschiebenAnfang;
    private bool mitMausVerschieben;
    private int viewportOffsetX = 0;
    private int viewportOffsetY = 0;
    private long frames = 0;
    private long time = 0;

    public frmLeved(GoreLeved viewport)
    {
        _viewport = viewport;
        InitializeComponent();
        _viewport.Target = this;
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
        // NOP
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

        BackBuffer.FillRectangle(color, 10, 10, 30, 30);
        e.Graphics.DrawImage(
            Image,
            destRect: new(0, 0, Image.Width, Image.Height),
            srcRect: new(viewportOffsetX, viewportOffsetY, Image.Width, Image.Height),
            GraphicsUnit.Pixel
        );

        var w = Image.Width;
        var h = Image.Height;

        if(gridPoints.Length == 0)
        {
            SetupGrid(w, h);
        }

        BackBuffer.DrawLines(Pens.AntiqueWhite, gridPoints);

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

    private void SetupGrid(int w, int h)
    {
        var points = new List<Point>
        {
            new(49, -1)
        };

        for (var x = 49; x < w; x += 49)
        {
            points.Add(new(x, h + 1));
            points.Add(new(x + 49, h + 1));
            points.Add(new(x + 49, -1));
        }

        points.Add(new(w + 1, 49));
        for (var y = 49; y < h; y += 49)
        {
            points.Add(new(-1, y));
            points.Add(new(-1, y + 49));
            points.Add(new(w + 1, y + 49));
        }

        gridPoints = points.ToArray();
    }

    private void frmLeved_Load(object sender, EventArgs e)
    {
        typeof(Form).InvokeMember(
            nameof(DoubleBuffered),
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null,
            this,
            [true]
        );
    }

    private void frmLeved_KeyDown(object sender, KeyEventArgs e)
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

    private void frmLeved_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.ControlKey)
        {
            Cursor = Cursors.Default;
        }
    }

    private void frmLeved_MouseDown(object sender, MouseEventArgs e)
    {
        mitMausVerschieben = true;
        mitMausVerschiebenAnfang = e.Location;
    }

    private void frmLeved_MouseMove(object sender, MouseEventArgs e)
    {
        if (mitMausVerschieben)
        {
            if (kybd.CtrlKeyDown)
            {
                var desiredPos = new Point(
                    (e.X - mitMausVerschiebenAnfang.X) - viewportOffsetX,
                    (e.Y - mitMausVerschiebenAnfang.Y) - viewportOffsetY
                );

                if (desiredPos.X > 0)
                {
                    desiredPos.X = 0;
                }

                if (desiredPos.Y > 0)
                {
                    desiredPos.Y = 0;
                }

                if (-desiredPos.X > (Image.Width - Width))
                {
                    desiredPos.X = -(Image.Width - Width);
                }

                if (-desiredPos.Y > (Image.Height - Height))
                {
                    desiredPos.Y = -(Image.Height - Height);
                }

                viewportOffsetX = -desiredPos.X;
                viewportOffsetY = -desiredPos.Y;
            }
            else
            {
                Location = new Point(
                    (Location.X - mitMausVerschiebenAnfang.X) + e.X,
                    (Location.Y - mitMausVerschiebenAnfang.Y) + e.Y
                );

                Update();
            }
        }
    }

    private void frmLeved_MouseUp(object sender, MouseEventArgs e)
    {
        mitMausVerschieben = false;
    }
}
