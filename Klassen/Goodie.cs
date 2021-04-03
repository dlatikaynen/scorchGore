using ScorchGore.Aufzaehlungen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScorchGore.Klassen
{
    internal class Goodie : Sprite
    {
        private readonly Control woBinIch;
        private readonly GoodieWirkung welchesGoodie;

        public Goodie(Control woBinIch, GoodieWirkung welchesGoodie)
        {
            this.woBinIch = woBinIch;
            this.welchesGoodie = welchesGoodie;
        }

        public override int Breite => 24;

        public override void Zeichnen(Graphics zeichenFlaeche, int fallProFrame = 0)
        {
            throw new NotImplementedException();
        }
    }
}
