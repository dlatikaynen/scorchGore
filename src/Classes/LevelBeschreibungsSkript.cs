using ScorchGore.Constants;
using ScorchGore.Resources;
using System.Reflection;

namespace ScorchGore.Classes;

public class LevelBeschreibungsSkript
{
    private const string kommentarPrefix = @"//";
    private const string abschnittBERG = "BERG";
    private const string abschnittGRAS = "GRAS";
    private const string abschnittHIMMEL = "HIMMEL";
    private const string abschnittSPIELER = "SPIELER";

    public List<LevelArchitekturPfad> Pfade { get; protected set; }

    public LevelBeschreibungsSkript()
    {
        Pfade = [];
    }

    public string Source => string.Empty;

    internal static LevelBeschreibungsSkript Laden(LevelBeschreibung levelBeschreibung)
    {
        var levelSkript = new LevelBeschreibungsSkript();
        levelSkript.LevelDateiLaden(levelBeschreibung);

        return levelSkript;
    }

    private void LevelDateiLaden(LevelBeschreibung levelBeschreibung)
    {
        var levelDateiName = GetLevelDateiname(levelBeschreibung.LevelNummer);
        if (levelDateiName != null)
        {
            using var levelDatei = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                typeof(ResourceProxy),
                $@"Levels.{levelDateiName}"
            )!;

            using var levelReader = new StreamReader(levelDatei);
            string levelZeile;
            var aktuellesMaterial = Medium.Berg;

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
            }
        }
    }

    private static string GetLevelDateiname(int levelNummer) => $@"Level{levelNummer.ToString().PadLeft(3, '0')}.dat";
}
