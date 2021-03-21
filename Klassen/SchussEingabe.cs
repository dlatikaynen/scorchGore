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
            }

            return $"{ trajektorienPrefix }{ this.SchussWinkel },{ this.SchussKraft }";
        }
    }
}
