using System.Drawing;
using System.Windows.Forms;

namespace ScorchGore.Klassen
{
    internal static class ZeugFallenlassen
    {
        private const int fallProFrame = 2;

        public static void FallZuBoden(Control woBinIch, Bitmap woSchaueIch, Graphics zeichenFlaeche, Sprite fallendesObjekt)
        {
            var weiterFallen = true;
            var himmelsFarbe = Farbverwaltung.HimmelsfarbeAlsInt;
            while (weiterFallen)
            {
                for (
                    var schauenX = fallendesObjekt.X - fallendesObjekt.HalbeBreite;
                    schauenX <= fallendesObjekt.X + fallendesObjekt.HalbeBreite;
                    schauenX += 3
                )
                {
                    if (woSchaueIch.GetPixel(schauenX, fallendesObjekt.Y + 1).ToArgb() != himmelsFarbe)
                    {
                        weiterFallen = false;
                        return;
                    }
                }

                if (weiterFallen)
                {
                    fallendesObjekt.Y += fallProFrame;
                    fallendesObjekt.Zeichnen(zeichenFlaeche, fallProFrame);
                }
                else
                {
                    fallendesObjekt.Zeichnen(zeichenFlaeche);
                }

                if (woBinIch != null)
                {
                    woBinIch.Refresh();
                }
            }
        }
    }
}
