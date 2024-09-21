using ScorchGore.Constants;

namespace ScorchGore.Arena;

internal abstract class Sprite : IDisposable
{
    public int Width = 0;
    public int Height = 0;
    public int AnchorX = 0;
    public int AnchorY = 0;
    public Anchorage Anchorage = Anchorage.DeadCenter;

    private Bitmap? BackingBitmap;
    private Bitmap? DingPic;
    private bool disposedValue;
    private Rectangle? _physicalBounds;

    internal abstract Color PrimaryBodyColor { get; }

    protected abstract void Draw(Graphics g);

    protected Rectangle PhysicalBounds 
    {
        get
        {
            if (_physicalBounds != null)
            {
                return _physicalBounds.Value;
            }

            switch(Anchorage)
            {
                case Anchorage.TopLeft:
                    _physicalBounds = new(AnchorX, AnchorY, Width, Height);
                    break;

                case Anchorage.TopCenter:
                    _physicalBounds = new(AnchorX - Width / 2, AnchorY, Width, Height);
                    break;

                case Anchorage.TopRight:
                    _physicalBounds = new(AnchorX - Width, AnchorY, Width, Height);
                    break;

                case Anchorage.MiddleLeft:
                    _physicalBounds = new(AnchorX, AnchorY - Height / 2, Width, Height);
                    break;

                case Anchorage.MiddleRight:
                    _physicalBounds = new(AnchorX - Width, AnchorY - Height / 2, Width, Height);
                    break;

                case Anchorage.BottomRight:
                    _physicalBounds = new(AnchorX - Width, AnchorY - Height, Width, Height);
                    break;

                case Anchorage.BottomLeft:
                    _physicalBounds = new(AnchorX, AnchorY - Height, Width, Height);
                    break;

                case Anchorage.BottomCenter:
                    _physicalBounds = new(AnchorX - Width / 2, AnchorY - Height, Width, Height);
                    break;

                case Anchorage.DeadCenter:
                    _physicalBounds = new(AnchorX - Width / 2, AnchorY - Height / 2, Width, Height);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(Anchorage), Anchorage, "invalid value");
            }

            return _physicalBounds.Value;
        }
    }

    public void Emplace(Image arena)
    {
        if (Width == 0 || Height == 0)
        {
#if DEBUG
            throw new NullReferenceException("Attempt to emplace an uninitialized sprite");
#else
            return;
#endif
        }

        // capture the background
        BackingBitmap = new Bitmap(Width, Height);
        using (var g = Graphics.FromImage(BackingBitmap))
        {
            g.DrawImage(
                arena,
                destRect: new Rectangle(0, 0, Width, Height),
                srcRect: PhysicalBounds,
                GraphicsUnit.Pixel
            );
        }

        // draw the current state of the sprite onto
        // its foreground caching bitmap
        DingPic = new Bitmap(Width, Height);
        using (var gd = Graphics.FromImage(DingPic))
        {
            Draw(gd);
        }

        // blit that to the arena
        using var ga = Graphics.FromImage(arena);
#if DEBUG
        ga.DrawRectangle(Pens.WhiteSmoke, PhysicalBounds);
        ga.FillRectangle(Brushes.WhiteSmoke, AnchorX - 1, AnchorY - 1, 3, 3);
#endif
        ga.DrawImageUnscaled(
            DingPic,
            PhysicalBounds
        );
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                DingPic?.Dispose();
                BackingBitmap?.Dispose();
            }

            DingPic = null;
            BackingBitmap = null;
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
