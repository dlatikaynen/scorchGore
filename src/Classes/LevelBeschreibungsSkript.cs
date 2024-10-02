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

    internal static LevelBeschreibungsSkript Laden(LevelBeschreibung levelBeschreibung)
    {
        var levelSkript = new LevelBeschreibungsSkript();
        levelSkript.LevelDateiLaden(levelBeschreibung.LevelNummer);

        return levelSkript;
    }

    private void LevelDateiLaden(int levelNummer)
    {
        var levelDateiName = GetLevelDateiname(levelNummer);
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
                    if (Enum.TryParse<Medium>(levelZeileTeile[0], ignoreCase: true, out Medium neuesMedium))
                    {
                        aktuellesMaterial = neuesMedium;
                    }
                    else
                    {
                        Pfade.Add(LevelArchitekturPfad.AusLevelDatei(aktuellesMaterial, levelZeile));
                    }
                }
            }
        }
    }

    private static string GetLevelDateiname(int levelNummer) => $@"Level{levelNummer.ToString().PadLeft(3, '0')}.dat";
}
