using ScorchGore.Constants;

namespace ScorchGore.Classes;

internal static class LevelSequenzierer
{
    private const int zufallsZahlenGenerator = 316685421;

    /// <summary>
    /// Das Zufallslevel im "Übungsmodus" hat die Nummer 0
    /// </summary>
    public static LevelBeschreibung ErzeugeLevelBeschreibung(int laufendeLevelNummer)
    {
        var levelBeschreibung = new LevelBeschreibung { LevelNummer = laufendeLevelNummer };
        switch (laufendeLevelNummer)
        {
            case 0:
                /* das ist (sind) das (die) übungslevel */
                break;

            case 1:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 1;
                levelBeschreibung.LevelNummerInMission = 1;
                levelBeschreibung.LevelName = "The Blue Mountains";
                levelBeschreibung.BergMinHoeheProzent = 13;
                levelBeschreibung.BergMaxHoeheProzent = 48;
                levelBeschreibung.BergRauhheitProzent = 21;
                levelBeschreibung.BergZufallszahl = zufallsZahlenGenerator;
                levelBeschreibung.Plateau(645 - 460, 82, 200);
                levelBeschreibung.SpielerPosition1 = new Point(112, levelBeschreibung.LevelHeight - 185);
                levelBeschreibung.Plateau(645 - 415, 638, 700);
                levelBeschreibung.SpielerPosition2 = new Point(673, levelBeschreibung.LevelHeight - 230);
                break;

            case 2:
                levelBeschreibung.MissionsNummer = 1;
                levelBeschreibung.LevelNummerInMission = 2;
                levelBeschreibung.LevelName = "The Blue Cave";
                levelBeschreibung.BergMinHoeheProzent = 10;
                levelBeschreibung.BergMaxHoeheProzent = 39;
                levelBeschreibung.BergRauhheitProzent = 19;
                levelBeschreibung.HoehleMinHoeheProzent = 13;
                levelBeschreibung.HoehleMaxHoeheProzent = 48;
                levelBeschreibung.HoehleRauhheitProzent = 50;
                levelBeschreibung.IstHoehle = true;
                levelBeschreibung.BergZufallszahl = zufallsZahlenGenerator;
                levelBeschreibung.SpielerPosition1 = new Point(GameLogicConstants.SpielerBreite, 300);
                levelBeschreibung.SpielerPosition2 = new Point(800 - GameLogicConstants.SpielerBreite, 300);
                break;

            case 3:
                levelBeschreibung.MissionsNummer = 1;
                levelBeschreibung.LevelNummerInMission = 3;
                levelBeschreibung.LevelName = "Dalí";
                levelBeschreibung.IstBerg = true;
                levelBeschreibung.BergZufallszahl = zufallsZahlenGenerator;
                levelBeschreibung.BergMinHoeheProzent = 3;
                levelBeschreibung.BergMaxHoeheProzent = 17;
                levelBeschreibung.BergRauhheitProzent = 8;
                levelBeschreibung.BeschreibungsSkript = LevelBeschreibungsSkript.Laden(levelBeschreibung);
                levelBeschreibung.SpielerPosition1 = new Point(112, GameLogicConstants.SpielerBasisHoehe);
                levelBeschreibung.SpielerPosition2 = new Point(673, GameLogicConstants.SpielerBasisHoehe);
                break;

            case 4:
                levelBeschreibung.MissionsNummer = 2;
                levelBeschreibung.LevelNummerInMission = 1;
                levelBeschreibung.LevelName = "Vah Miaw";

                break;

            default:
                /* spielende */
                return new();
        }

        levelBeschreibung.MisisonsnameSetzen();

        return levelBeschreibung;
    }
}
