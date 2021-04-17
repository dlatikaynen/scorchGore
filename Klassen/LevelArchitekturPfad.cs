using ScorchGore.Aufzaehlungen;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace ScorchGore.Klassen
{
    internal class LevelArchitekturPfad
    {
        protected internal readonly List<Point> promilleKoordinaten;
        protected internal Medium terrainMaterial = Medium.Berg;
        protected internal ZeichnungsBefehl zeichnungBefehl = ZeichnungsBefehl.Pfad;

        public LevelArchitekturPfad() => this.promilleKoordinaten = new List<Point>();

        public GraphicsPath AlsGrafikPfad(int absoluteWidth, int absoluteHeight)
        {
            var grafikPfad = new GraphicsPath();
            var vorDividierteBreit = (float)absoluteWidth / 1000f;
            var vorDividierteHoehe = (float)absoluteHeight / 1000f;
            if (this.promilleKoordinaten.Any())
            {
                grafikPfad.AddLines(this.promilleKoordinaten.Select
                (
                    pK => new Point(
                        (int)(vorDividierteBreit * (float)pK.X),
                        (int)(vorDividierteHoehe * (float)pK.Y)
                    )
                ).ToArray());
            }

            grafikPfad.CloseAllFigures();
            return grafikPfad;
        }

        internal static LevelArchitekturPfad AusLevelDatei(Medium aktuellesMaterial, string levelZeile)
        {
            var architekturPfad = new LevelArchitekturPfad
            {
                terrainMaterial = aktuellesMaterial
            };

            var geleseneKoordinaten = levelZeile.Split(';').Select(koordinatenPaar =>
            {
                var koordinatenTeile = koordinatenPaar.Split(',');
                return new Point(int.Parse(koordinatenTeile[0]), int.Parse(koordinatenTeile[1]));
            });

            architekturPfad.promilleKoordinaten.AddRange(geleseneKoordinaten);
            return architekturPfad;
        }
    }
}
