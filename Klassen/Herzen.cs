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

        public Herzen(Control woBinIch, Goodies bilderVorladen)
        {
            this.hohlesHerz = bilderVorladen.BildHolen(Aufzaehlungen.GoodieWirkung.Hohlesherz);
            this.halbesHerz = bilderVorladen.BildHolen(Aufzaehlungen.GoodieWirkung.HalbesHerz);
            this.rechtsHerz = bilderVorladen.BildHolen(Aufzaehlungen.GoodieWirkung.RechtsHerz);
            this.ganzesHerz = bilderVorladen.BildHolen(Aufzaehlungen.GoodieWirkung.GanzesHerz);
            var herzBreite = this.hohlesHerz.Width;
            var herzHoehe = this.hohlesHerz.Height;
            this.positionsRasterLinks = new RectangleF[3];
            this.positionsRasterRechts = new RectangleF[3];
            for(var i=0;i<this.positionsRasterLinks.Length;++i)
            {
                this.positionsRasterLinks[i] = new RectangleF(
                    9 + i * (herzBreite + 3),
                    4,
                    herzBreite,
                    herzHoehe
                );

                /* die rechtsseitigen herzen sind gespiegelt */
                this.positionsRasterRechts[i] = new RectangleF(
                    woBinIch.Width - this.positionsRasterLinks[i].X - herzBreite,
                    this.positionsRasterLinks[i].Y,
                    herzBreite,
                    herzHoehe
                );
            }
        }

        internal void Zeichnen(Control woBinIch, Graphics zeichnung, Spieler spielerLinks, Spieler spielerRechts)
        {
            var verbrauchtLinks = 0;
            var verbrauchtRechts = 0;
            for (var i = 0; i < this.positionsRasterLinks.Length; ++i)
            {
                if (spielerLinks != null)
                {
                    var linksUebrig = spielerLinks.Lebenspunkte - verbrauchtLinks;
                    var herzFuerLinkes = this.FindePassendesHerz(linksUebrig);
                    zeichnung.FillRectangle(Farbverwaltung.Himmelsbuerste, this.positionsRasterLinks[i]);
                    zeichnung.DrawImageUnscaled(herzFuerLinkes, (int)this.positionsRasterLinks[i].X, (int)this.positionsRasterLinks[i].Y);
                    verbrauchtLinks += 2;
                }

                if (spielerRechts != null)
                {
                    var rechtsUebrig = spielerRechts.Lebenspunkte - verbrauchtRechts;
                    var herzFuerRechts = this.FindePassendesHerz(rechtsUebrig, fuerRechts: true);
                    zeichnung.FillRectangle(Farbverwaltung.Himmelsbuerste, this.positionsRasterRechts[i]);
                    zeichnung.DrawImageUnscaled(herzFuerRechts, (int)this.positionsRasterRechts[i].X, (int)this.positionsRasterRechts[i].Y);
                    verbrauchtRechts += 2;
                }
            }
        }

        private Image FindePassendesHerz(int uebrigeLebenspunkte, bool fuerRechts = false)
        {
            if (uebrigeLebenspunkte <= 0)
            {
                return this.hohlesHerz;
            }
            else if (uebrigeLebenspunkte == 1)
            {
                return fuerRechts ? this.rechtsHerz : this.halbesHerz;
            }

            return this.ganzesHerz;
        }
    }
}
