namespace ScorchGore.Klassen
{
    public class Treffer
    {
        public SchussErgebnis Ergebnis { get; set; }
        public int EinschlagsKoordinateX { get; set; }
        public int EinschlagsKoordinateY { get; set; }

        internal int GespieltesLevel { get; set; }
        internal Spieler GetroffenerSpieler { get; set; }
        internal Spieler ObsiegenderSpieler { get; set; }

        public Treffer Setzen(int einschlagX, int einschlagY, SchussErgebnis ergebnis)
        {
            this.EinschlagsKoordinateX = einschlagX;
            this.EinschlagsKoordinateY = einschlagY;
            this.Ergebnis = ergebnis;
            return this;
        }
    }
}
