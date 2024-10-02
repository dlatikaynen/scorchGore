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
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
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
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 1;
                levelBeschreibung.LevelNummerInMission = 3;
                levelBeschreibung.LevelName = "Rock Bottom";
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
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 1;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.LevelName = "Vahta Morgana";

                break;

            case 5:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 1;
                levelBeschreibung.LevelNummerInMission = 5;
                levelBeschreibung.LevelName = "Crosswise and Helical";

                break;

            case 6:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 1;
                levelBeschreibung.LevelNummerInMission = 6;
                levelBeschreibung.LevelName = "Not of advantage";

                break;

            case 7:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 1;
                levelBeschreibung.LevelNummerInMission = 7;
                levelBeschreibung.LevelName = "Outside the box";

                break;

            case 8:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 2;
                levelBeschreibung.LevelNummerInMission = 1;
                levelBeschreibung.LevelName = "Desert of Crimson, Red and Rust";

                break;

            case 9:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 2;
                levelBeschreibung.LevelNummerInMission = 2;
                levelBeschreibung.LevelName = "Water Wall";

                break;

            case 10:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 2;
                levelBeschreibung.LevelNummerInMission = 3;
                levelBeschreibung.LevelName = "Musical Pond";

                break;

            case 11:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 2;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.LevelName = "Route Six";

                break;

            case 12:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 3;
                levelBeschreibung.LevelNummerInMission = 1;
                levelBeschreibung.LevelName = "Entangled";

                break;

            case 13:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 3;
                levelBeschreibung.LevelNummerInMission = 2;
                levelBeschreibung.LevelName = "Gravity stumbles";

                break;

            case 14:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 3;
                levelBeschreibung.LevelNummerInMission = 3;
                levelBeschreibung.LevelName = "Rain";

                break;

            case 15:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 3;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.LevelName = "Pain";

                break;

            case 16:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 3;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.LevelName = "Fallen";

                break;

            case 17:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 1;
                levelBeschreibung.LevelName = "Whale";

                break;

            case 18:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 2;
                levelBeschreibung.LevelName = "Pterosaur";

                break;

            case 19:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 3;
                levelBeschreibung.LevelName = "Amethyst";

                break;

            case 20:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.LevelName = "Doctor's Office";

                break;

            case 21:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 5;
                levelBeschreibung.LevelName = "Go To Sleep and Turn to Dust";

                break;

            case 22:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 6;
                levelBeschreibung.LevelName = "Time, it's Time";

                break;

            case 23:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 7;
                levelBeschreibung.LevelName = "Wake up and Live";

                break;

            case 24:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 5;
                levelBeschreibung.LevelNummerInMission = 1;
                levelBeschreibung.LevelName = "Snails of Plenty";

                break;

            case 25:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 5;
                levelBeschreibung.LevelNummerInMission = 2;
                levelBeschreibung.LevelName = "Take me to Snurch";

                break;

            case 26:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 5;
                levelBeschreibung.LevelNummerInMission = 3;
                levelBeschreibung.LevelName = "Heracles' Bane";

                break;

            case 27:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 5;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.LevelName = "This Corrosion";

                break;

            case 28:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 5;
                levelBeschreibung.LevelNummerInMission = 5;
                levelBeschreibung.LevelName = "Garden of Ridiculously Poisonous Plants";

                break;

            case 29:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 6;
                levelBeschreibung.LevelNummerInMission = 1;
                levelBeschreibung.LevelName = "Let there be Light";

                break;

            case 30:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 6;
                levelBeschreibung.LevelNummerInMission = 2;
                levelBeschreibung.LevelName = "Skip the News";

                break;

            case 31:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 6;
                levelBeschreibung.LevelNummerInMission = 3;
                levelBeschreibung.LevelName = "Empty Boats";

                break;

            case 32:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 6;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.LevelName = "Liquid Larry";

                break;

            case 33:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 6;
                levelBeschreibung.LevelNummerInMission = 5;
                levelBeschreibung.LevelName = "The Gray Line";

                break;

            case 34:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 1;
                levelBeschreibung.LevelName = "Pal & Secam";

                break;

            case 35:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 2;
                levelBeschreibung.LevelName = "Father's Favourite";

                break;

            case 36:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 3;
                levelBeschreibung.LevelName = "Teacher's Neck";

                break;

            case 37:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.LevelName = "Silent Sorrow";

                break;

            case 38:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 5;
                levelBeschreibung.LevelName = "Rat Stampede";

                break;

            case 39:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 6;
                levelBeschreibung.LevelName = "Double Exit";

                break;

            case 40:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 7;
                levelBeschreibung.LevelName = "The Genet Gate";

                break;

            case 41:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 8;
                levelBeschreibung.LevelName = "Memory Mine";

                break;

            case 42:
                levelBeschreibung.LevelWidth = 862;
                levelBeschreibung.LevelHeight = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 9;
                levelBeschreibung.LevelName = "The Waters of Life";

                break;

            default:
                /* spielende */
                return new();
        }

        levelBeschreibung.MisisonsnameSetzen();

        return levelBeschreibung;
    }
}
