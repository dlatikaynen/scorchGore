using ScorchGore.Klassen;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScorchGore
{
    internal class Spieler : Sprite
    {
        public string Name;
        public Brush Farbe;

        public Spieler(Control woBinIch, Bitmap woSchaueIch) : base(woBinIch, woSchaueIch)
        {
            /* jeder bekommt am anfang die hälfte der möglichen halbherzen,
             * die jeweils halbherzig wachsen oder zugrunde gehen können */
            this.Lebenspunkte = 3;
        }

        public override int Breite => Main.spielerBreite;
        public int Lebenspunkte { protected set; get; }

        public override void Zeichnen(Graphics zeichenFlaeche, int fallProFrame = 0)
        {
            /* das über dem spieler, wo er gefallen ist, wieder mit himmelsfarbe übermalen */
            var ueberMalenVonY = Math.Max(0, this.Y - Main.spielerBasisHoehe - fallProFrame);
            zeichenFlaeche.FillRectangle(
                Farbverwaltung.Himmelsbuerste,
                this.X - this.HalbeBreite,
                ueberMalenVonY,
                this.Breite,
                this.Y - ueberMalenVonY + 1
            );

            /* den spieler selbst neu zeichnen: ein gefüllter halbkreis mit rundung oben */
            zeichenFlaeche.FillPie(
                this.Farbe,
                this.X - this.HalbeBreite,
                this.Y - Main.spielerBasisHoehe + 1,
                this.Breite,
                2 * Main.spielerBasisHoehe,
                0f,
                -180f
            );
        }

        internal void Positionieren(Point spielerPosition, int standardX)
        {
            if(spielerPosition.IsEmpty)
            {
                this.X = standardX;
                this.Y = Main.spielerBasisHoehe;
            }
            else
            {
                this.X = spielerPosition.X;
                this.Y = spielerPosition.Y;
            }
        }
    }
}