using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScorchGore.Klassen
{
    internal class Herzen
    {
        protected Image ganzesHerz;
        protected Image halbesHerz;
        protected Image rechtsHerz;
        protected Image hohlesHerz;

        private RectangleF[] positionsRasterLinks;
        private RectangleF[] positionsRasterRechts;

        public Herzen(Goodies bilderVorladen)
        {
            this.hohlesHerz = bilderVorladen.BildHolen(Aufzaehlungen.GoodieWirkung.Hohlesherz);
            this.halbesHerz = bilderVorladen.BildHolen(Aufzaehlungen.GoodieWirkung.HalbesHerz);
            this.rechtsHerz = bilderVorladen.BildHolen(Aufzaehlungen.GoodieWirkung.RechtsHerz);
            this.ganzesHerz = bilderVorladen.BildHolen(Aufzaehlungen.GoodieWirkung.GanzesHerz);
            var herzBreite = this.hohlesHerz.Width;
            var herzHoehe = this.hohlesHerz.Height;
            this.positionsRasterLinks = new RectangleF[]
            {
                new RectangleF(1,1,herzBreite,herzHoehe),
                new RectangleF(1,1,herzBreite,herzHoehe),
                new RectangleF(1,1,herzBreite,herzHoehe)
            };

            /* die rechtsseitigen herzen sind gespiegelt */
            this.positionsRasterRechts = new RectangleF[this.positionsRasterLinks.Length];
            for (var i = 0; i < this.positionsRasterRechts.Length; ++i)
            {
                this.positionsRasterRechts[i] = new RectangleF(
                    0,
                    0,
                    this.positionsRasterLinks[i].Width,
                    this.positionsRasterLinks[i].Height
                );
            }
        }

        internal void Zeichnen(Control woBinIch, Graphics zeichnung, Spieler spielerLinks, Spieler spielerRechts)
        {
            zeichnung.DrawImageUnscaled(this.ganzesHerz, 9, 4);
            zeichnung.DrawImageUnscaled(this.halbesHerz, 9 + 19, 4);
            zeichnung.DrawImageUnscaled(this.hohlesHerz, 9 + 2 * 19, 4);
            zeichnung.DrawImageUnscaled(this.rechtsHerz, 9 + 3 * 19, 4);
        }
    }
}
