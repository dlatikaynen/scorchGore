using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScorchGore.Klassen
{
    internal static class LevelZeichner
    {
        public static void Zeichne(Control woBinIch, Bitmap levelBild, LevelBeschreibung levelBeschreibung, Graphics zeichenFlaeche)
        {
            var verfuegbareBergHoehe = woBinIch.Height - Main.obererRand;
            var minimumHoehe = Convert.ToInt32(Convert.ToDecimal(verfuegbareBergHoehe) * Convert.ToDecimal(levelBeschreibung.BergMinHoeheProzent) / 100M);
            var maximumHoehe = Convert.ToInt32(Convert.ToDecimal(verfuegbareBergHoehe) * Convert.ToDecimal(levelBeschreibung.BergMaxHoeheProzent) / 100M);
            var steilHeit = Convert.ToInt32(5 + levelBeschreibung.BergRauhheitProzent);
            var rauhHeit = 10M - Convert.ToDecimal(levelBeschreibung.BergRauhheitProzent / 20M);
            var zufallsZahl = new Random(levelBeschreibung.BergZufallszahl);
            var maximumHoehenunterschied = maximumHoehe - minimumHoehe;
            var aktuelleHoehe = Convert.ToDecimal(minimumHoehe + zufallsZahl.Next(maximumHoehenunterschied));
            var aktuelleRichtung = (zufallsZahl.Next(100) % 2) == 0;
            var aktuelleSteilheit = Convert.ToDecimal(Math.Max(1, zufallsZahl.Next(steilHeit)) * 0.22);
            var unveraenderteSteigung = Convert.ToInt32(zufallsZahl.NextDouble() * (double)rauhHeit);
            
            zeichenFlaeche.FillRectangle(Farbverwaltung.Himmelsbuerste, zeichenFlaeche.ClipBounds);
            for (var bergX = 0; bergX < woBinIch.Width; bergX += 2)
            {
                /* berg höhenänderung berechnen */
                var hoehenAenderung = 0M;
                if (aktuelleRichtung)
                {
                    hoehenAenderung += aktuelleSteilheit;
                }
                else
                {
                    hoehenAenderung -= aktuelleSteilheit;
                }

                aktuelleHoehe += hoehenAenderung;
                if (aktuelleHoehe < 0)
                {
                    aktuelleRichtung = true;
                    aktuelleHoehe = aktuelleSteilheit / 2M;
                }
                else if (aktuelleHoehe > maximumHoehenunterschied)
                {
                    aktuelleRichtung = false;
                    aktuelleHoehe = maximumHoehenunterschied - aktuelleSteilheit / 2M;
                }

                /* berg zeichnen */
                var pixelHoehe = minimumHoehe + Convert.ToInt32(aktuelleHoehe);
                zeichenFlaeche.FillRectangle(Farbverwaltung.Bergbuerste, bergX, (float)woBinIch.Height - pixelHoehe, 2f, (float)woBinIch.Height);

                /* zacken in den berg machen */
                if (--unveraenderteSteigung <= 0)
                {
                    woBinIch.Refresh();
                    aktuelleRichtung = (zufallsZahl.Next(100) % 2) == 0;
                    aktuelleSteilheit = Convert.ToDecimal(Math.Max(1, zufallsZahl.Next(steilHeit)) * 0.22);
                    unveraenderteSteigung = Convert.ToInt32(zufallsZahl.NextDouble() * (double)rauhHeit);
                }
            }
        }
    }
}
