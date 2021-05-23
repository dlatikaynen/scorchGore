using ScorchGore.Aufzaehlungen;

namespace ScorchGore
{
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
            this.Trajektorie = TrajektorienArt.Parabolisch;
        }

        public string Serialisieren()
        {
            var trajektorienPrefix = string.Empty;
            switch(this.Trajektorie)
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

            return $"{ trajektorienPrefix }{ this.SchussWinkel },{ this.SchussKraft }";
        }

        public bool Deserialisieren(string gespeicherteWerte)
        {
            var gegebeneWerte = gespeicherteWerte.Split(',');
            var winkelText = gegebeneWerte[0];
            var ladungText = gegebeneWerte[1];
            if (winkelText.StartsWith("c"))
            {
                this.Trajektorie = TrajektorienArt.Kubisch;
                winkelText = winkelText.Substring("c".Length);
            }
            else if (winkelText.StartsWith("sd"))
            {
                this.Trajektorie = TrajektorienArt.SinusDaempfer;
                winkelText = winkelText.Substring("sd".Length);
            }
            else if (winkelText.StartsWith("sw"))
            {
                this.Trajektorie = TrajektorienArt.Schwarm;
                winkelText = winkelText.Substring("sw".Length);
            }
            else
            {
                this.Trajektorie = TrajektorienArt.Parabolisch;
            }

            if (int.TryParse(winkelText, out int winkelWert)
                && int.TryParse(ladungText, out int ladungWert)
                && winkelWert >= 0
                && winkelWert < 90
                && ladungWert > 0
                && ladungWert <= 200
            )
            {
                this.SchussWinkel = winkelWert;
                this.SchussKraft = ladungWert;
                return true;
            }

            return false;
        }
    }
}
