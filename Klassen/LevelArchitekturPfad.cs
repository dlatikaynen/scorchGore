using ScorchGore.Aufzaehlungen;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace ScorchGore.Klassen
{
    internal class LevelArchitekturPfad
    {
        protected internal const string modifiziererRechteck = "B";
        protected internal const string modifiziererFuellung = "F";
        protected internal const string modifiziererVollesRechteck = "BF";

        protected internal readonly List<Point> promilleKoordinaten;
        protected internal Medium terrainMaterial = Medium.Berg;
        protected internal ZeichnungsBefehl zeichnungBefehl = ZeichnungsBefehl.Pfad;
        protected internal bool wirdRechteck;
        protected internal bool hatFuellung;
        protected internal int stiftDicke;

        public LevelArchitekturPfad() => this.promilleKoordinaten = new List<Point>();
        public bool IstPunkt => this.promilleKoordinaten.Count() == 1;
        public bool IstLinie => this.promilleKoordinaten.Count() == 2;
        public bool IstRechteck => this.wirdRechteck;
        public bool IstGefuellt => this.hatFuellung;
        public int StiftDicke => this.stiftDicke;

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

            var kommandoTeile = levelZeile.Split('*');
            if (kommandoTeile.Length > 1 && int.TryParse(kommandoTeile[1].Trim(), out int stiftDicke))
            {
                architekturPfad.stiftDicke = stiftDicke;
            }

            var kommandoZeile = kommandoTeile[0].Trim();
            if (kommandoZeile.ToUpperInvariant().EndsWith(LevelArchitekturPfad.modifiziererVollesRechteck))
            {
                architekturPfad.wirdRechteck = true;
                architekturPfad.hatFuellung = true;
                kommandoZeile = kommandoZeile.Substring(0, kommandoZeile.Length - LevelArchitekturPfad.modifiziererVollesRechteck.Length);
            }
            else if (kommandoZeile.ToUpperInvariant().EndsWith(LevelArchitekturPfad.modifiziererRechteck))
            {
                architekturPfad.wirdRechteck = true;
                kommandoZeile = kommandoZeile.Substring(0, kommandoZeile.Length - LevelArchitekturPfad.modifiziererRechteck.Length);
            }
            else if(kommandoZeile.ToUpperInvariant().EndsWith(LevelArchitekturPfad.modifiziererFuellung))
            {
                architekturPfad.hatFuellung = true;
                kommandoZeile = kommandoZeile.Substring(0, kommandoZeile.Length - LevelArchitekturPfad.modifiziererFuellung.Length);
            }

            if(kommandoZeile.EndsWith(";"))
            {
                kommandoZeile = kommandoZeile.Substring(0, kommandoZeile.Length - ";".Length);
            }

            var geleseneKoordinaten = kommandoZeile.Split(';').Select(koordinatenPaar =>
            {
                var koordinatenTeile = koordinatenPaar.Split(',');
                return new Point(int.Parse(koordinatenTeile[0]), int.Parse(koordinatenTeile[1]));
            });

            architekturPfad.promilleKoordinaten.AddRange(geleseneKoordinaten);
            return architekturPfad;
        }
    }
}
