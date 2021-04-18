using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorchGore.Klassen
{
    /// <summary>
    /// Eine Implementierung des Bresenham Linienalgorithmus
    /// basierend auf einer Idee von https://stackoverflow.com/a/11683720/1132334
    /// </summary>
    internal class LinienFolger
    {
        public static IEnumerable<Point> Bresenham(int startX, int startY, int endX, int endY)
        {
            var w = endX - startX;
            var h = endY - startY;
            var dx1 = Math.Sign(w);
            var dy1 = Math.Sign(h);
            var dx2 = dx1;
            var dy2 = 0;
            var longest = Math.Abs(w);
            var shortest = Math.Abs(h);
            if (longest <= shortest)
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                dx2 = 0;
                dy2 = Math.Sign(h);
            }

            var numerator = longest >> 1;
            for (var i = 0; i <= longest; ++i)
            {
                yield return new Point(startX, startY);
                numerator += shortest;
                if (numerator < longest)
                {
                    startX += dx2;
                    startY += dy2;
                }
                else
                {
                    numerator -= longest;
                    startX += dx1;
                    startY += dy1;
                }
            }
        }
    }
}
