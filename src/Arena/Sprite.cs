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

    protected abstract void Draw(Graphics g);

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
                srcRect: new Rectangle(AnchorX, AnchorY, Width, Height),
                GraphicsUnit.Pixel
            );
        }

        // draw the current state of the sprite onto
        // it foreground caching bitmap
        DingPic = new Bitmap(Width, Height);
        using (var gd = Graphics.FromImage(DingPic))
        {
            Draw(gd);
        }

        // blit it to the arena
        using var ga = Graphics.FromImage(arena);
        ga.DrawImageUnscaled(
            DingPic,
            new Rectangle(AnchorX, AnchorY, Width, Height)
        );

        ga.DrawRectangle(Pens.WhiteSmoke, AnchorX, AnchorY, Width, Height);
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
