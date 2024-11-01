using ScorchGore.Constants;
using ScorchGore.Leved;
using ScorchGore.Resources;
using System.Reflection;
using System.Text;

namespace ScorchGore.Classes;

public class LevelBeschreibungsSkript
{
    private const string kommentarPrefix = @"//";
    private const string abschnittBERG = "BERG";
    private const string abschnittGRAS = "GRAS";
    private const string abschnittHIMMEL = "HIMMEL";
    private const string abschnittSPIELER = "SPIELER";

    private StringBuilder _source = new();

    public List<LevelArchitekturPfad> Pfade { get; protected set; }

    public LevelBeschreibungsSkript()
    {
        Pfade = [];
    }

    public string Source => _source.ToString();

    internal void SetSource(string source)
    {
        _source.Clear();
        _source.Append(source);
    }

    internal static LevelBeschreibungsSkript Laden(LevelBeschreibung levelBeschreibung)
    {
        var levelSkript = new LevelBeschreibungsSkript();
        levelSkript.LevelDateiLaden(levelBeschreibung);

        return levelSkript;
    }

    /// <summary>
    /// Extracts the list of materials needed by the scene that the script describes
    /// </summary>
    internal static List<(Medium medium, string materialKey)> GetBOM(LevelBeschreibung levelBeschreibung)
    {
        var result = new List<(Medium medium, string materialKey)>();
        var script = Laden(levelBeschreibung);

        foreach (var pfad in script.Pfade)
        {
            if (!string.IsNullOrEmpty(pfad.materialKey))
            {
                result.Add((pfad.medium, pfad.materialKey));
            }
        }

        return result.Distinct().ToList();
    }

    public static string LoadLevelBeschreibungSourceCode(int levelNummer)
    {
        var levelDateiName = GetLevelDateiname(levelNummer);

        if (levelDateiName != null)
        {
            using var levelDatei = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                typeof(ResourceProxy),
                $@"Levels.{levelDateiName}"
            )!;

            using var levelReader = new StreamReader(levelDatei);

            return levelReader.ReadToEnd().Trim();
        }

        return string.Empty;
    }

    private void LevelDateiLaden(LevelBeschreibung levelBeschreibung)
    {
        if (!string.IsNullOrWhiteSpace(levelBeschreibung.BeschreibungsSkript))
        {
            using var levelReader = new StringReader(levelBeschreibung.BeschreibungsSkript);
            string levelZeile;
            var aktuellesMedium = Medium.Berg;
            var aktuellesMaterial = string.Empty;
            var desiredFarbe = Color.Empty;
            var theme = DesignWorkspace.MaterialThemes.Where(t => t.Name == levelBeschreibung.MaterialThemeKey).SingleOrDefault();

            _source.Clear();
            while (!string.IsNullOrEmpty((levelZeile = levelReader.ReadLine() ?? string.Empty)))
            {
                levelZeile = levelZeile.Trim();
                if (!levelZeile.StartsWith(kommentarPrefix))
                {
                    var levelZeileTeile = levelZeile.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (Enum.TryParse(levelZeileTeile[0], ignoreCase: true, out Medium neuesMedium))
                    {
                        aktuellesMedium = neuesMedium;
                        aktuellesMaterial = string.Empty;
                        desiredFarbe = Color.Empty;

                        if (levelZeileTeile.Length > 1)
                        {
                            if (theme == null)
                            {
                                throw new Exception("Cannot use material palettes without a theme on the level");
                            }

                            aktuellesMaterial = levelZeileTeile[1].ToUpper();

                            if(levelZeileTeile.Length == 3)
                            {
                                if (Enum.TryParse<KnownColor>(levelZeileTeile[2], out var color))
                                {
                                    desiredFarbe = Color.FromKnownColor(color);
                                }
                            }

                            MaterialTheme.AllocateMaterial(theme, aktuellesMedium, aktuellesMaterial, desiredFarbe);
                        }
                    }
                    else
                    {
                        Pfade.Add(LevelArchitekturPfad.AusLevelDatei(levelBeschreibung.Materials, aktuellesMedium, aktuellesMaterial, levelZeile));
                    }
                }

                _source.AppendLine(levelZeile);
            }
        }
    }

    private static string GetLevelDateiname(int levelNummer) => $@"Level{levelNummer.ToString().PadLeft(3, '0')}.dat";
}
