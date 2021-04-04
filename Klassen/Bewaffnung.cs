using ScorchGore.Aufzaehlungen;

namespace ScorchGore.Klassen
{
    internal class Bewaffnung
    {
        public Waffengattung Gattung { get; protected set; }
        public int SchadensPunkte { get;protected set; }

        public static readonly Bewaffnung PixelKanone = new Bewaffnung(Waffengattung.Pixelkanone);

        public Bewaffnung(Waffengattung waffenGattung)
        {
            this.Gattung = waffenGattung;
            this.GenerierenMitStandard();
        }

        private void GenerierenMitStandard()
        {
            switch(this.Gattung)
            {
                case Waffengattung.Pixelkanone:
                    this.SchadensPunkte = 3;
                    break;
            }
        }
    }
}
