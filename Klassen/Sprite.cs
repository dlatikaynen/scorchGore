using System.Drawing;
using System.Windows.Forms;

namespace ScorchGore.Klassen
{
    internal abstract class Sprite
    {
        public int X;
        public int Y;

        public abstract int Breite { get; }

        public int HalbeBreite => this.Breite / 2;

        public abstract void Zeichnen(Graphics zeichenFlaeche, int fallProFrame = 0);

        public void FallenLassen(Control woBinIch, Bitmap woSchaueIch, Graphics zeichenFlaeche) => ZeugFallenlassen.FallZuBoden(woBinIch, woSchaueIch, zeichenFlaeche, this);
    }
}
