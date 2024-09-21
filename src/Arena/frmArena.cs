using System.Reflection;

namespace ScorchGore.Arena;

public partial class frmArena : Form
{
    private readonly GoreArena _arena;
    private int viewportOffsetX = 0;
    private int viewportOffsetY = 0;
    private bool IsIdle = false;
    private readonly CancellationTokenSource cancelSource = new();

    public frmArena(GoreArena arena)
    {
        _arena = arena;
        InitializeComponent();
        _arena.Target = this;
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        var cancelToken = cancelSource.Token;
        Application.Idle += Application_Idle;
        Task.Factory.StartNew((_) =>
        {
            while (!IsIdle)
            {
                Task.Delay(100).Wait();
            }

            BackgroundImage = _arena.Image;

            while (IsIdle && !cancelToken.IsCancellationRequested)
            {
                try
                {
                    while (!cancelToken.IsCancellationRequested)
                    {
                        if (InvokeRequired)
                        {
                            Invoke(() => Refresh());
                        }
                        else
                        {
                            Refresh();
                        }

                        Task.Delay(32).Wait();
                        if (!ReferenceEquals(BackgroundImage, _arena.Image))
                        {
                            Invoke(() =>
                            {
                                BackgroundImage = _arena.Image;
                            });
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

    private void frmArena_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Right)
        {
            viewportOffsetX += 2;
            viewportOffsetY -= 1;
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
}
