using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScorchGore.Klassen
{
    class Explosion
    {
        private readonly Color explosionsFarbe;
        private readonly int radius;

        public Explosion(Color farbe, int radius)
        {
            this.explosionsFarbe = farbe;
            this.radius = radius;
        }

        public void Noobsplosion(Control wasbinich, Bitmap levelBild, Bitmap eingefrorenerBerg, int pixelX, int pixelY)
        {
            var hangRutschung = new Hangrutschung(wasbinich);
            using (var zeichnung = Graphics.FromImage(levelBild))
            {
                var durchMesser = 2 * this.radius;
                for (var explosionsBreite = 1; explosionsBreite < durchMesser; explosionsBreite += 2)
                {
                    zeichnung.DrawEllipse(new Pen(this.explosionsFarbe), pixelX - explosionsBreite / 2, pixelY - explosionsBreite / 2, explosionsBreite, explosionsBreite);
                    wasbinich.Refresh();
                }

                zeichnung.FillEllipse(Farbverwaltung.Himmelsbuerste, pixelX - this.radius, pixelY - this.radius, 2 * this.radius, 2 * this.radius);
                hangRutschung.Bergsturz(
                    levelBild,
                    pixelX - this.radius,
                    pixelX + this.radius,
                    pixelY,
                    this.radius
                );

                hangRutschung.Zeichnen(zeichnung, mitAnimation: true);
            }

            using (var bildKopieren = Graphics.FromImage(eingefrorenerBerg))
            {
                bildKopieren.FillEllipse(Farbverwaltung.Himmelsbuerste, pixelX - 50, pixelY - 50, 100, 100);
                hangRutschung.Zeichnen(bildKopieren, mitAnimation: false);
            }
        }

    }
}
