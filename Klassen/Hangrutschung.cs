using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ScorchGore.Klassen
{
    internal class Hangrutschung
    {
        private readonly Control woBinIch;
        private readonly List<int> stuerzendeX;
        private readonly List<Linie> himmelsLinien;
        private readonly List<Linie> gebirgsLinien;

        private int startPixelX;
        private int endetPixelX;
        private int einschlagY;

        public Hangrutschung(Control woBinIch)
        {
            this.woBinIch = woBinIch;
            this.stuerzendeX = new List<int>();
            this.himmelsLinien = new List<Linie>();
            this.gebirgsLinien = new List<Linie>();
        }

        public void Bergsturz(Bitmap levelBild, int startX, int endetX, int einschlagY, int sprengRadius)
        {
            var bergFarbe = Color.SlateBlue.ToArgb();
            this.startPixelX = Math.Max(0, startX);
            this.endetPixelX = Math.Min(levelBild.Width, endetX);
            this.einschlagY = einschlagY;
            var xRichtung = this.startPixelX <= this.endetPixelX ? 1 : -1;
            for (
                int x = this.startPixelX, i = 0, kreisX = -sprengRadius;
                x <= this.endetPixelX;
                x += xRichtung, ++i, ++kreisX
            )
            {
                /* kreisgleichung:
                 * x² + y² = r²
                 * deshalb
                 * y² = r² - x²
                 * deshalb
                 * y = sqrt(r² - x²) */
                var yAbstand = (int)Math.Sqrt(sprengRadius * sprengRadius - kreisX * kreisX);
                for (var ySpuereOben = this.einschlagY - yAbstand; ySpuereOben >= 0; --ySpuereOben)
                {
                    if (levelBild.GetPixel(x, ySpuereOben).ToArgb() == bergFarbe)
                    {
                        this.stuerzendeX.Add(i);
                        for (var yBergBisOben = ySpuereOben - 1; yBergBisOben >= 0; --yBergBisOben)
                        {
                            if (yBergBisOben == 0 || levelBild.GetPixel(x, yBergBisOben).ToArgb() != bergFarbe)
                            {
                                this.himmelsLinien.Add(new Linie { oberesY = yBergBisOben, unteresY = ySpuereOben });
                                var unterstesY = this.einschlagY + yAbstand;
                                this.gebirgsLinien.Add(new Linie { oberesY = unterstesY - (ySpuereOben - yBergBisOben), unteresY = unterstesY });
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public void Zeichnen(Graphics zeichnung, bool mitAnimation)
        {
            var xRichtung = this.startPixelX <= this.endetPixelX ? 1 : -1;
            var linienIndex = 0;
            for (
                int x = this.startPixelX, i = 0;
                x <= this.endetPixelX; x += xRichtung, 
                ++i
            )
            {
                if (this.stuerzendeX.Contains(i))
                {
                    var linieNr = linienIndex++;
                    zeichnung.DrawLine(Pens.SlateBlue, x, this.gebirgsLinien[linieNr].oberesY, x, this.gebirgsLinien[linieNr].unteresY);
                    zeichnung.DrawLine(Pens.DarkSlateGray, x, this.himmelsLinien[linieNr].oberesY, x, this.himmelsLinien[linieNr].unteresY);
                    if (mitAnimation && i % 2 == 0 && woBinIch != null)
                    {
                        woBinIch.Refresh();
                    }
                }
            }
        }

        private class Linie
        {
            public int oberesY;
            public int unteresY;
        }
    }
}
