using ScorchGore.Constants;
using System.Drawing.Drawing2D;

namespace ScorchGore.Classes;

public class LevelArchitekturPfad
{
    public Materials Materials { get; init; }

    protected internal const char kennzeichenFigur = ':';
    protected internal const char kennzeichenDicke = '*';
    protected internal const string modifiziererRechteck = "B";
    protected internal const string modifiziererFuellung = "F";
    protected internal const string modifiziererVollesRechteck = "BF";

    protected internal readonly List<Point> promilleKoordinaten;
    protected internal Medium terrainMaterial = Medium.Berg;
    protected internal ZeichnungsBefehl zeichnungBefehl = ZeichnungsBefehl.Pfad;
    protected internal bool wirdRechteck;
    protected internal bool hatFuellung;
    protected internal int stiftDicke;

    public LevelArchitekturPfad(Materials materials)
    {
        Materials = materials;
        promilleKoordinaten = [];
    }

    public bool IstPunkt => promilleKoordinaten.Count() == 1;
    public bool IstLinie => promilleKoordinaten.Count() == 2;
    public bool IstRechteck => wirdRechteck;
    public bool IstGefuellt => hatFuellung;
    public int StiftDicke => stiftDicke;

    public GraphicsPath AlsGrafikPfad(int absoluteWidth, int absoluteHeight)
    {
        var grafikPfad = new GraphicsPath();
        var vorDividierteBreit = (float)absoluteWidth / 1000f;
        var vorDividierteHoehe = (float)absoluteHeight / 1000f;
        if (promilleKoordinaten.Any())
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

    internal static LevelArchitekturPfad AusLevelDatei(Materials materials, Medium aktuellesMaterial, string levelZeile)
    {
        var architekturPfad = new LevelArchitekturPfad(materials)
        {
            terrainMaterial = aktuellesMaterial
        };

        var kommandoTeile = levelZeile.Split(kennzeichenFigur);
        string figurZeile;
        if (kommandoTeile.Length == 1)
        {
            figurZeile = kommandoTeile[0].Trim();
        }
        else
        {
            figurZeile = kommandoTeile[1].Trim();
            if (Enum.TryParse(kommandoTeile[0], ignoreCase: true, out ZeichnungsBefehl zeichnungBefehl))
            {
                architekturPfad.zeichnungBefehl = zeichnungBefehl;
            }
        }

        var figurTeile = figurZeile.Split(kennzeichenDicke);
        if (figurTeile.Length > 1 && int.TryParse(figurTeile[1].Trim(), out int stiftDicke))
        {
            architekturPfad.stiftDicke = stiftDicke;
        }

        var figurDefinition = figurTeile[0].Trim();
        if (figurDefinition.ToUpperInvariant().EndsWith(modifiziererVollesRechteck))
        {
            architekturPfad.wirdRechteck = true;
            architekturPfad.hatFuellung = true;
            figurDefinition = figurDefinition.Substring(0, figurDefinition.Length - LevelArchitekturPfad.modifiziererVollesRechteck.Length);
        }
        else if (figurDefinition.ToUpperInvariant().EndsWith(modifiziererRechteck))
        {
            architekturPfad.wirdRechteck = true;
            figurDefinition = figurDefinition.Substring(0, figurDefinition.Length - LevelArchitekturPfad.modifiziererRechteck.Length);
        }
        else if (figurDefinition.ToUpperInvariant().EndsWith(modifiziererFuellung))
        {
            architekturPfad.hatFuellung = true;
            figurDefinition = figurDefinition.Substring(0, figurDefinition.Length - LevelArchitekturPfad.modifiziererFuellung.Length);
        }

        if (figurDefinition.EndsWith(";"))
        {
            figurDefinition = figurDefinition.Substring(0, figurDefinition.Length - ";".Length);
        }

        var geleseneKoordinaten = figurDefinition.Split(';').Select(koordinatenPaar =>
        {
            var koordinatenTeile = koordinatenPaar.Split(',');
            return new Point(int.Parse(koordinatenTeile[0]), int.Parse(koordinatenTeile[1]));
        });

        architekturPfad.promilleKoordinaten.AddRange(geleseneKoordinaten);
        return architekturPfad;
    }
}
