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
        private readonly GoodieWirkung welchesGoodie;
        private readonly Goodies goodieSpeicher;

        public Goodie(Control woBinIch, Bitmap woSchaueIch, Goodies goodieSpeicher, GoodieWirkung welchesGoodie) : base(woBinIch,woSchaueIch)
        {
            this.goodieSpeicher = goodieSpeicher;
            this.welchesGoodie = welchesGoodie;
        }

        public override int Breite => 33;

        protected int Hoehe => this.Breite;

        protected override bool HatEinenFallschirm => true;

        public override void Zeichnen(Graphics zeichenFlaeche, int fallProFrame = 0)
        {
            /* das über dem spieler, wo er gefallen ist, wieder mit himmelsfarbe übermalen */
            var ueberMalenVonY = Math.Max(0, this.Y - (this.Hoehe * (this.HatEinenFallschirm ? 3 : 1)) - fallProFrame);
            zeichenFlaeche.FillRectangle(
                Farbverwaltung.Himmelsbuerste,
                this.X - this.HalbeBreite,
                ueberMalenVonY,
                this.Breite,
                this.Y - ueberMalenVonY + 1
            );

            /* das goodie selbst zeichnen */
            zeichenFlaeche.DrawImageUnscaled(
                this.goodieSpeicher.BildHolen(this.welchesGoodie),
                this.X - this.HalbeBreite,
                this.Y - this.Hoehe
            );

            /* den fallschirm, an dem es haengt */
            if(this.HatEinenFallschirm)
            {
                Sprite.FallschirmZeichnen(zeichenFlaeche, this.X, this.Y - this.Hoehe * 3, this.Breite * 2, fallProFrame);
            }
        }
    }
}
