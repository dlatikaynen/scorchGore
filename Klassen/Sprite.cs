using System.Drawing;
using System.Drawing.Drawing2D;
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

        protected virtual bool HatEinenFallschirm => false;

        public abstract void Zeichnen(Graphics zeichenFlaeche, int fallProFrame = 0);

        public void FallenLassen(Graphics zeichenFlaeche) => ZeugFallenlassen.FallZuBoden(woBinIch, woSchaueIch, zeichenFlaeche, this);

        protected static void FallschirmZeichnen(Graphics zeichenFlaeche, int xMitte, int yOben, int gesamtBreite, int fallProFrame = 0)
        {
            var goldeneHoehe = 0.61f * gesamtBreite;
            var halbeHoehe = goldeneHoehe / 2f;
            var linksAussen = (float)xMitte - (float)gesamtBreite / 2f;
            var fifthWidth = gesamtBreite / 5f;
            var fifthRadius = fifthWidth / 2f;
            var fudgeFactor = 2f / 66f * (float)gesamtBreite;
            var clipPath = new GraphicsPath();
            clipPath.StartFigure();
            clipPath.AddArc((float)xMitte - (float)gesamtBreite / 2f, (float)yOben, (float)gesamtBreite, goldeneHoehe, 180f, 180f);
            for (int i = 1; i <= 5; ++i)
            {
                clipPath.AddArc(linksAussen + fifthWidth * i - fifthWidth, (float)yOben + halbeHoehe - fifthRadius, fifthWidth, fifthWidth, 180f, 180f);
            }

            clipPath.CloseFigure();
            var clipRegion = new Region(clipPath);
            var previousClip = zeichenFlaeche.Clip;
            if (fallProFrame > 0)
            {
                zeichenFlaeche.FillRectangle(
                    Farbverwaltung.Himmelsbuerste,
                    linksAussen,
                    yOben,
                    gesamtBreite,
                    goldeneHoehe
                );
            }

            zeichenFlaeche.FillRegion(Brushes.NavajoWhite, clipRegion);
            zeichenFlaeche.Clip = clipRegion;
            zeichenFlaeche.FillEllipse(Brushes.Green, linksAussen + fifthWidth, (float)yOben, 3f * fifthWidth, goldeneHoehe);
            var halbeSeite = new RectangleF(linksAussen, yOben, (float)gesamtBreite / 2f, goldeneHoehe);
            var unmaskedClip = zeichenFlaeche.Clip;
            clipRegion.Exclude(halbeSeite);
            zeichenFlaeche.Clip = clipRegion;
            zeichenFlaeche.FillEllipse(Brushes.SaddleBrown, (float)xMitte - (float)gesamtBreite / 2f, (float)yOben, (float)gesamtBreite, goldeneHoehe);
            zeichenFlaeche.FillEllipse(Brushes.Orange, linksAussen + fifthWidth, (float)yOben, 3f * fifthWidth, goldeneHoehe);
            zeichenFlaeche.Clip = unmaskedClip;
            zeichenFlaeche.FillEllipse(Brushes.Azure, linksAussen + 2f * fifthWidth, (float)yOben, fifthWidth, goldeneHoehe);
            zeichenFlaeche.Clip = previousClip;
            for (int i = 1; i <= 5; ++i)
            {
                /* die ersten fünf fallschirmleinen */
                zeichenFlaeche.DrawLine(
                    Pens.NavajoWhite,
                    linksAussen + fifthWidth * (i - 1) + (i == 1 ? fudgeFactor : 0f),
                    yOben + halbeHoehe - fudgeFactor,
                    xMitte,
                    yOben + goldeneHoehe
                );
            }

            /* die letzte fallschirmleine */
            zeichenFlaeche.DrawLine(
                Pens.WhiteSmoke,
                linksAussen + (float)gesamtBreite - fudgeFactor,
                yOben + halbeHoehe - fudgeFactor,
                xMitte,
                yOben + goldeneHoehe
            );

            /* die mittlere verbindung vom knoten runter zum fallenden objekt */
            zeichenFlaeche.DrawLine(
                Pens.WhiteSmoke,
                xMitte,
                yOben + goldeneHoehe,
                xMitte,
                yOben + 1.5f * goldeneHoehe
            );
        }
    }
}
