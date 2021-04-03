namespace ScorchGore.Klassen
{
    internal class Treffer
    {
        public SchussErgebnis Ergebnis { get; set; }
        public int EinschlagsKoordinateX { get; set; }
        public int EinschlagsKoordinateY { get; set; }

        public Treffer Setzen(int einschlagX, int einschlagY, SchussErgebnis ergebnis)
        {
            this.EinschlagsKoordinateX = einschlagX;
            this.EinschlagsKoordinateY = einschlagY;
            this.Ergebnis = ergebnis;
            return this;
        }
    }
}
