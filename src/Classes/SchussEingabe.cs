using ScorchGore.Constants;

namespace ScorchGore.Classes;

internal class SchussEingabe
{
    public TrajektorienArt Trajektorie;
    public int SchussWinkel;
    public int SchussKraft;

    public SchussEingabe()
    {
        /* normalerweise nehmen wir einen planeten mit erdähnlicher
         * schwerkraft an, in dem geschossene projektile einer
         * parabelbahn (quadratischen kurve) folgen. */
        Trajektorie = TrajektorienArt.Parabolisch;
    }

    public string Serialisieren()
    {
        var trajektorienPrefix = string.Empty;

        switch(Trajektorie)
        {
            case TrajektorienArt.Brachistochron:
                trajektorienPrefix = "b";
                break;
            case TrajektorienArt.Kreisfoermig:
                trajektorienPrefix = "o";
                break;

            case TrajektorienArt.Kubisch:
                trajektorienPrefix = "c";
                break;

            case TrajektorienArt.SinusDaempfer:
                trajektorienPrefix = "sd";
                break;

            case TrajektorienArt.Spiralenfoermig:
                trajektorienPrefix = "s";
                break;

            case TrajektorienArt.Schwarm:
                trajektorienPrefix = "sw";
                break;
        }

        return $"{ trajektorienPrefix }{ SchussWinkel },{ SchussKraft }";
    }

    public bool Deserialisieren(string gespeicherteWerte)
    {
        var gegebeneWerte = gespeicherteWerte.Split(',');
        var winkelText = gegebeneWerte[0];
        var ladungText = gegebeneWerte[1];
        if (winkelText.StartsWith('c'))
        {
            Trajektorie = TrajektorienArt.Kubisch;
            winkelText = winkelText["c".Length..];
        }
        else if (winkelText.StartsWith("sd"))
        {
            Trajektorie = TrajektorienArt.SinusDaempfer;
            winkelText = winkelText["sd".Length..];
        }
        else if (winkelText.StartsWith("sw"))
        {
            Trajektorie = TrajektorienArt.Schwarm;
            winkelText = winkelText.Substring("sw".Length);
        }
        else
        {
            Trajektorie = TrajektorienArt.Parabolisch;
        }

        if (int.TryParse(winkelText, out int winkelWert)
            && int.TryParse(ladungText, out int ladungWert)
            && winkelWert >= 0
            && winkelWert < 90
            && ladungWert > 0
            && ladungWert <= 200
        )
        {
            SchussWinkel = winkelWert;
            SchussKraft = ladungWert;

            return true;
        }

        return false;
    }
}
