using System.Drawing;
using System.Windows.Forms;

namespace ScorchGore.Klassen
{
    internal abstract class Sprite
    {
        public int X;
        public int Y;

        protected readonly Control woBinIch;
        protected readonly Bitmap woSchaueIch;

        public Sprite(Control woBinIch, Bitmap woSchaueIch)
        {
            this.woBinIch = woBinIch;
            this.woSchaueIch = woSchaueIch;
        }

        public abstract int Breite { get; }

        public int HalbeBreite => this.Breite / 2;

        public abstract void Zeichnen(Graphics zeichenFlaeche, int fallProFrame = 0);

        public void FallenLassen(Graphics zeichenFlaeche) => ZeugFallenlassen.FallZuBoden(woBinIch, woSchaueIch, zeichenFlaeche, this);
    }
}
