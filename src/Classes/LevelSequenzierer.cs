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
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 1;
                levelBeschreibung.LevelNummerInMission = 1;
                levelBeschreibung.NameEn = "The Blue Mountains";
                //levelBeschreibung.ColorMountain = levelBeschreibung.Materials.FarbeVonMedium(Medium.Berg);
                //levelBeschreibung.ColorCave = levelBeschreibung.Materials.FarbeVonMedium(Medium.Berg);
                levelBeschreibung.Plateau(645 - 460, 82, 200);
                levelBeschreibung.SpielerPosition1 = new Point(112, (int)levelBeschreibung.Height - 185);
                levelBeschreibung.Plateau(645 - 415, 638, 700);
                levelBeschreibung.SpielerPosition2 = new Point(673, (int)levelBeschreibung.Height - 230);
                levelBeschreibung.AssetPlacement.Add(new()
                {
                    AssetKey = "WOTM_BERG",
                    ParamsUInt = {
                        { nameof(CsgAssetBerg.BergZufallszahl), zufallsZahlenGenerator },
                        { nameof(CsgAssetBerg.BergMinHoeheProzent), 13 },
                        { nameof(CsgAssetBerg.BergMaxHoeheProzent), 48 },
                        { nameof(CsgAssetBerg.BergRauhheitProzent), 21 }
                    }
                });

                break;

            case 2:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 1;
                levelBeschreibung.LevelNummerInMission = 2;
                levelBeschreibung.NameEn = "The Blue Cave";
                levelBeschreibung.Zufallszahl = zufallsZahlenGenerator;
                //levelBeschreibung.ColorMountain = levelBeschreibung.Materials.FarbeVonMedium(Medium.Berg);
                //levelBeschreibung.ColorCave = levelBeschreibung.Materials.FarbeVonMedium(Medium.Berg);
                levelBeschreibung.SpielerPosition1 = new Point(GameLogicConstants.SpielerBreite, 300);
                levelBeschreibung.SpielerPosition2 = new Point(800 - GameLogicConstants.SpielerBreite, 300);
                levelBeschreibung.AssetPlacement.Add(new()
                {
                    AssetKey = "WOTM_BERG",
                    ParamsUInt = {
                        { nameof(CsgAssetBerg.BergZufallszahl), zufallsZahlenGenerator },
                        { nameof(CsgAssetBerg.BergMinHoeheProzent), 10 },
                        { nameof(CsgAssetBerg.BergMaxHoeheProzent), 39 },
                        { nameof(CsgAssetBerg.BergRauhheitProzent), 19 }
                    }
                });

                levelBeschreibung.AssetPlacement.Add(new()
                {
                    AssetKey = "WOTM_CAVECEIL",
                    ParamsUInt = {
                        { nameof(CsgAssetHoehlendecke.HoehleZufallszahl), zufallsZahlenGenerator },
                        { nameof(CsgAssetHoehlendecke.HoehleMinHoeheProzent), 13 },
                        { nameof(CsgAssetHoehlendecke.HoehleMaxHoeheProzent), 48 },
                        { nameof(CsgAssetHoehlendecke.HoehleRauhheitProzent), 50 }
                    }
                });

                break;

            case 3:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 1;
                levelBeschreibung.LevelNummerInMission = 3;
                levelBeschreibung.NameEn = "Rock Bottom";
                levelBeschreibung.Zufallszahl = zufallsZahlenGenerator;
                //levelBeschreibung.ColorMountain = levelBeschreibung.Materials.FarbeVonMedium(Medium.Berg);
                //levelBeschreibung.ColorCave = levelBeschreibung.Materials.FarbeVonMedium(Medium.Berg);
                levelBeschreibung.BeschreibungsSkript = LevelBeschreibungsSkript.Laden(levelBeschreibung);
                levelBeschreibung.SpielerPosition1 = new Point(112, GameLogicConstants.SpielerBasisHoehe);
                levelBeschreibung.SpielerPosition2 = new Point(673, GameLogicConstants.SpielerBasisHoehe);
                levelBeschreibung.AssetPlacement.Add(new()
                {
                    AssetKey = "WOTM_BERG",
                    ParamsUInt = {
                        { nameof(CsgAssetBerg.BergZufallszahl), zufallsZahlenGenerator },
                        { nameof(CsgAssetBerg.BergMinHoeheProzent), 3 },
                        { nameof(CsgAssetBerg.BergMaxHoeheProzent), 17 },
                        { nameof(CsgAssetBerg.BergRauhheitProzent), 8 }
                    }
                });
                
                break;

            case 4:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 1;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.NameEn = "Vahta Morgana";

                break;

            case 5:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 1;
                levelBeschreibung.LevelNummerInMission = 5;
                levelBeschreibung.NameEn = "Crosswise and Helical";

                break;

            case 6:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 1;
                levelBeschreibung.LevelNummerInMission = 6;
                levelBeschreibung.NameEn = "Not of advantage";

                break;

            case 7:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 1;
                levelBeschreibung.LevelNummerInMission = 7;
                levelBeschreibung.NameEn = "Outside the box";

                break;

            case 8:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 2;
                levelBeschreibung.LevelNummerInMission = 1;
                levelBeschreibung.NameEn = "Desert of Crimson, Red and Rust";

                break;

            case 9:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 2;
                levelBeschreibung.LevelNummerInMission = 2;
                levelBeschreibung.NameEn = "Water Wall";

                break;

            case 10:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 2;
                levelBeschreibung.LevelNummerInMission = 3;
                levelBeschreibung.NameEn = "Musical Pond";

                break;

            case 11:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 2;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.NameEn = "Route Six";

                break;

            case 12:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 3;
                levelBeschreibung.LevelNummerInMission = 1;
                levelBeschreibung.NameEn = "Entangled";

                break;

            case 13:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 3;
                levelBeschreibung.LevelNummerInMission = 2;
                levelBeschreibung.NameEn = "Gravity stumbles";

                break;

            case 14:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 3;
                levelBeschreibung.LevelNummerInMission = 3;
                levelBeschreibung.NameEn = "Rain";

                break;

            case 15:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 3;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.NameEn = "Pain";

                break;

            case 16:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 3;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.NameEn = "Fallen";

                break;

            case 17:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 1;
                levelBeschreibung.NameEn = "Whale";

                break;

            case 18:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 2;
                levelBeschreibung.NameEn = "Pterosaur";

                break;

            case 19:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 3;
                levelBeschreibung.NameEn = "Amethyst";

                break;

            case 20:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.NameEn = "Doctor's Office";

                break;

            case 21:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 5;
                levelBeschreibung.NameEn = "Go To Sleep and Turn to Dust";

                break;

            case 22:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 6;
                levelBeschreibung.NameEn = "Time, it's Time";

                break;

            case 23:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 8;
                levelBeschreibung.NameDe = "Sind drei Bäume schon ein Wald?";
                levelBeschreibung.NameEn = "Do three trees make a forest?";
                levelBeschreibung.NameFi = "Isä, onko kolme puuta metsää?";
                levelBeschreibung.NameUa = "Татко, а троє дерев – це вже ліс?";

                break;

            case 24:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 8;
                levelBeschreibung.NameEn = "Wake up and Live";

                break;

            case 25:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 5;
                levelBeschreibung.LevelNummerInMission = 1;
                levelBeschreibung.NameEn = "Snails of Plenty";

                break;

            case 26:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 5;
                levelBeschreibung.LevelNummerInMission = 2;
                levelBeschreibung.NameEn = "Take me to Snurch";

                break;

            case 27:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 5;
                levelBeschreibung.LevelNummerInMission = 3;
                levelBeschreibung.NameEn = "Heracles' Bane";

                break;

            case 28:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 5;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.NameEn = "This Corrosion";

                break;

            case 29:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 6;
                levelBeschreibung.LevelNummerInMission = 1;
                levelBeschreibung.NameEn = "Let there be Light";

                break;

            case 30:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 6;
                levelBeschreibung.LevelNummerInMission = 2;
                levelBeschreibung.NameEn = "Skip the News";

                break;

            case 31:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 6;
                levelBeschreibung.LevelNummerInMission = 3;
                levelBeschreibung.NameEn = "Empty Boats";

                break;

            case 32:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 6;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.NameEn = "Liquid Larry";

                break;

            case 33:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 6;
                levelBeschreibung.LevelNummerInMission = 5;
                levelBeschreibung.NameEn = "The Gray Line";

                break;

            case 34:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 1;
                levelBeschreibung.NameEn = "Pal & Secam";

                break;

            case 35:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 2;
                levelBeschreibung.NameEn = "Father's Favourite";

                break;

            case 36:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 3;
                levelBeschreibung.NameEn = "Teacher's Neck";

                break;

            case 37:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.NameEn = "Silent Sorrow";

                break;

            case 38:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 5;
                levelBeschreibung.NameEn = "Rat Stampede";

                break;

            case 39:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 6;
                levelBeschreibung.NameEn = "Double Exit";

                break;

            case 40:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 7;
                levelBeschreibung.NameEn = "The Genet Gate";

                break;

            case 41:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 8;
                levelBeschreibung.NameEn = "Memory Mine";

                break;

            case 42:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 9;
                levelBeschreibung.NameEn = "The Waters of Life";

                break;

            default:
                /* spielende */
                return new();
        }

        levelBeschreibung.MisisonsnameSetzen();

        return levelBeschreibung;
    }
}
