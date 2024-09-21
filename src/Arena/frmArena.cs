using Microsoft.VisualBasic.Devices;
using System.Reflection;

namespace ScorchGore.Arena;

public partial class frmArena : Form
{
    private bool mitMausVerschieben;
    private Point mitMausVerschiebenAnfang;
    private readonly GoreArena _arena;
    private int viewportOffsetX = 0;
    private int viewportOffsetY = 0;
    private bool IsIdle = false;
    private readonly CancellationTokenSource cancelSource = new();
    private readonly Keyboard kybd = new();

    public frmArena(GoreArena arena)
    {
        _arena = arena;
        InitializeComponent();
        _arena.Target = pnlArena;
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        var cancelToken = cancelSource.Token;
        Application.Idle += Application_Idle;
        Task.Factory.StartNew((_) =>
        {
            while (!IsIdle || _arena.Image.Width == 1)
            {
                Task.Delay(100).Wait();
            }

            SetupArena();
            while (IsIdle && !cancelToken.IsCancellationRequested)
            {
                try
                {
                    while (!cancelToken.IsCancellationRequested)
                    {
                        if (pnlArena.InvokeRequired)
                        {
                            pnlArena.Invoke(() => pnlArena.Refresh());
                        }
                        else
                        {
                            pnlArena.Refresh();
                        }

                        Task.Delay(32).Wait();
                        if (!ReferenceEquals(pnlArena.BackgroundImage, _arena.Image))
                        {
                            SetupArena();
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    continue;
                }
            }
        }, cancelToken, TaskCreationOptions.LongRunning);
    }

    private void SetupArena()
    {
        if (pnlArena.InvokeRequired)
        {
            pnlArena.Invoke(() =>
            {
                SetupArenaInternal();
            });
        }
        else
        {
            SetupArenaInternal();
        }
    }

    private void SetupArenaInternal()
    {
        pnlArena.Size = _arena.Image.Size;
        pnlArena.Location = new Point(
            (Width - pnlArena.Width) / 2,
            (Height - pnlArena.Height) / 2
        );

        pnlArena.BackgroundImage = _arena.Image;
    }

    private void frmArena_KeyDown(object sender, KeyEventArgs e)
    {
        if(e.KeyCode == Keys.ControlKey)
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

    private void Application_Idle(object? sender, EventArgs e)
    {
        IsIdle = true;
    }

    private void frmArena_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!cancelSource.IsCancellationRequested)
        {
            cancelSource.Cancel();
        }
    }

    private void pnlArena_MouseDown(object sender, MouseEventArgs e)
    {
        mitMausVerschieben = true;
        mitMausVerschiebenAnfang = e.Location;
    }

    private void pnlArena_MouseMove(object sender, MouseEventArgs e)
    {
        if (mitMausVerschieben)
        {
            if (kybd.CtrlKeyDown)
            {
                var desiredPos = new Point(
                    pnlArena.Left + (e.X - mitMausVerschiebenAnfang.X),
                    pnlArena.Top + (e.Y - mitMausVerschiebenAnfang.Y)
                );

                if(desiredPos.X > 0)
                {
                    desiredPos.X = 0;
                }

                if(desiredPos.Y > 0)
                {
                    desiredPos.Y = 0;
                }

                if (-desiredPos.X > (pnlArena.Width - Width))
                {
                    desiredPos.X = -(pnlArena.Width - Width);
                }

                if (-desiredPos.Y > (pnlArena.Height - Height))
                {
                    desiredPos.Y = -(pnlArena.Height - Height);
                }

                pnlArena.Location = desiredPos;
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

    private void pnlArena_MouseUp(object sender, MouseEventArgs e)
    {
        mitMausVerschieben = false;
    }
}
