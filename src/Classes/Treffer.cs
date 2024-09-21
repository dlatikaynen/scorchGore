using ScorchGore.Constants;

namespace ScorchGore.Classes;

internal class Treffer
{
    public SchussErgebnis Ergebnis { get; set; }
    public int EinschlagsKoordinateX { get; set; }
    public int EinschlagsKoordinateY { get; set; }

    internal int GespieltesLevel { get; set; }
    internal int GetroffenerSpieler { get; set; }
    internal int ObsiegenderSpieler { get; set; }

    public Treffer Setzen(int einschlagX, int einschlagY, SchussErgebnis ergebnis)
    {
        EinschlagsKoordinateX = einschlagX;
        EinschlagsKoordinateY = einschlagY;
        Ergebnis = ergebnis;

        return this;
    }
}