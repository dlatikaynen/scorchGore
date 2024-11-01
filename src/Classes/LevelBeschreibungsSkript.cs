using ScorchGore.Constants;
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
            var aktuellesMaterial = Medium.Berg;

            _source.Clear();
            while (!string.IsNullOrEmpty((levelZeile = levelReader.ReadLine() ?? string.Empty)))
            {
                levelZeile = levelZeile.Trim();
                if (!levelZeile.StartsWith(kommentarPrefix))
                {
                    var levelZeileTeile = levelZeile.Split(' ');
                    if (Enum.TryParse(levelZeileTeile[0], ignoreCase: true, out Medium neuesMedium))
                    {
                        aktuellesMaterial = neuesMedium;
                    }
                    else
                    {
                        Pfade.Add(LevelArchitekturPfad.AusLevelDatei(levelBeschreibung.Materials, aktuellesMaterial, levelZeile));
                    }
                }

                _source.AppendLine(levelZeile);
            }
        }
    }

    private static string GetLevelDateiname(int levelNummer) => $@"Level{levelNummer.ToString().PadLeft(3, '0')}.dat";
}
