using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScorchGore.Klassen
{
    internal static class ZeugFallenlassen
    {
        private const int fallProFrame = 2;
        private const int augenDioptrien = 3;

        public static void FallZuBoden(Control woBinIch, Bitmap woSchaueIch, Graphics zeichenFlaeche, Sprite fallendesObjekt)
        {
            var weiterFallen = true;
            var himmelsFarbe = Farbverwaltung.HimmelsfarbeAlsInt;
            while (weiterFallen)
            {
                for (
                    var schauenX = Math.Max(0, fallendesObjekt.X - fallendesObjekt.HalbeBreite);
                    schauenX <= fallendesObjekt.X + fallendesObjekt.HalbeBreite && schauenX < woSchaueIch.Width;
                    schauenX += ZeugFallenlassen.augenDioptrien
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
