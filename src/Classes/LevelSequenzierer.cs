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
        var levelBeschreibung = new LevelBeschreibung 
        { 
            LevelNummer = laufendeLevelNummer,
            IsBuiltin = true
        };

        switch (laufendeLevelNummer)
        {
            case 0:
                /* das ist (sind) das (die) übungslevel */
                break;

            case 1:
                levelBeschreibung.IsBuiltin = true;
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
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";
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
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";
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
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";
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
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 5:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 1;
                levelBeschreibung.LevelNummerInMission = 5;
                levelBeschreibung.NameEn = "Crosswise and Helical";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 6:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 1;
                levelBeschreibung.LevelNummerInMission = 6;
                levelBeschreibung.NameEn = "Not of advantage";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 7:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 1;
                levelBeschreibung.LevelNummerInMission = 7;
                levelBeschreibung.NameEn = "Outside the box";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 8:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 2;
                levelBeschreibung.LevelNummerInMission = 1;
                levelBeschreibung.NameEn = "Desert of Crimson, Red and Rust";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 9:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 2;
                levelBeschreibung.LevelNummerInMission = 2;
                levelBeschreibung.NameDe = "Waterwesen";
                levelBeschreibung.NameEn = "Water Wall";
                levelBeschreibung.NameFi = "Veden olentoja";
                levelBeschreibung.NameUa = "Істота води";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 10:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 2;
                levelBeschreibung.LevelNummerInMission = 3;
                levelBeschreibung.NameEn = "Musical Pond";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 11:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 2;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.NameEn = "Route Six";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 12:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 3;
                levelBeschreibung.LevelNummerInMission = 1;
                levelBeschreibung.NameDe = "Vertrackt";
                levelBeschreibung.NameEn = "Entangled";
                levelBeschreibung.NameFi = "Sotkenut";
                levelBeschreibung.NameUa = "Заплутаний";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 13:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 3;
                levelBeschreibung.LevelNummerInMission = 2;
                levelBeschreibung.NameDe = "Schwere";
                levelBeschreibung.NameEn = "Gravity";
                levelBeschreibung.NameFi = "Painovoima";
                levelBeschreibung.NameUa = "Тяжіння";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 14:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 3;
                levelBeschreibung.LevelNummerInMission = 3;
                levelBeschreibung.NameDe = "Regen";
                levelBeschreibung.NameEn = "Rain";
                levelBeschreibung.NameFi = "Sade";
                levelBeschreibung.NameUa = "Дощ";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 15:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 3;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.NameDe = "Aua";
                levelBeschreibung.NameEn = "Pain";
                levelBeschreibung.NameFi = "Auts";
                levelBeschreibung.NameUa = "Ой";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 16:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 3;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.NameDe = "Gefallen";
                levelBeschreibung.NameEn = "Fallen";
                levelBeschreibung.NameFi = "Pudonnut";
                levelBeschreibung.NameUa = "Впав";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 17:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 1;
                levelBeschreibung.NameDe = "Wal";
                levelBeschreibung.NameEn = "Whale";
                levelBeschreibung.NameFi = "Valas";
                levelBeschreibung.NameUa = "Кит";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 18:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 2;
                levelBeschreibung.NameDe = "Flugsaurier";
                levelBeschreibung.NameEn = "Pterosaur";
                levelBeschreibung.NameFi = "Pterosaur";
                levelBeschreibung.NameUa = "Птерозавр";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 19:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 3;
                levelBeschreibung.NameDe = "Amethyst";
                levelBeschreibung.NameEn = "Amethyst";
                levelBeschreibung.NameFi = "Ametisti";
                levelBeschreibung.NameUa = "Аметист";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 20:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.NameEn = "Doctor's Office";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 21:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 5;
                levelBeschreibung.NameDe = "Geh zu Bett und werde Staub";
                levelBeschreibung.NameEn = "Go To Sleep and Turn to Dust";
                levelBeschreibung.NameFi = "Mene nukkumaan ja muutu pölyksi";
                levelBeschreibung.NameUa = "Засни й творися прах";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 22:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 6;
                levelBeschreibung.NameDe = "Es wird Zeit";
                levelBeschreibung.NameEn = "Time, it's Time";
                levelBeschreibung.NameFi = "Aika—on aika.";
                levelBeschreibung.NameUa = "Пора—пора";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

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
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 24:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 4;
                levelBeschreibung.LevelNummerInMission = 8;
                levelBeschreibung.NameEn = "Wake up and Live";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 25:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 5;
                levelBeschreibung.LevelNummerInMission = 1;
                levelBeschreibung.NameEn = "Snails of Plenty";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 26:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 5;
                levelBeschreibung.LevelNummerInMission = 2;
                levelBeschreibung.NameEn = "Take me to Snurch";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 27:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 5;
                levelBeschreibung.LevelNummerInMission = 3;
                levelBeschreibung.NameEn = "Heracles' Bane";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 28:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 5;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.NameEn = "This Corrosion";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 29:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 6;
                levelBeschreibung.LevelNummerInMission = 1;
                levelBeschreibung.NameEn = "Let there be Light";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 30:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 6;
                levelBeschreibung.LevelNummerInMission = 2;
                levelBeschreibung.NameEn = "Skip the News";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 31:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 6;
                levelBeschreibung.LevelNummerInMission = 3;
                levelBeschreibung.NameEn = "Empty Boats";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 32:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 6;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.NameEn = "Liquid Larry";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 33:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 6;
                levelBeschreibung.LevelNummerInMission = 5;
                levelBeschreibung.NameEn = "The Gray Line";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 34:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 1;
                levelBeschreibung.NameEn = "Pal & Secam";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 35:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 2;
                levelBeschreibung.NameEn = "Father's Favourite";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 36:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 3;
                levelBeschreibung.NameEn = "Teacher's Neck";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 37:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 4;
                levelBeschreibung.NameEn = "Silent Sorrow";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 38:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 5;
                levelBeschreibung.NameEn = "Rat Stampede";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 39:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 6;
                levelBeschreibung.NameEn = "Double Exit";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 40:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 7;
                levelBeschreibung.NameEn = "The Genet Gate";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 41:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 8;
                levelBeschreibung.NameEn = "Memory Mine";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            case 42:
                levelBeschreibung.Width = 862;
                levelBeschreibung.Height = 518;
                levelBeschreibung.MissionsNummer = 7;
                levelBeschreibung.LevelNummerInMission = 9;
                levelBeschreibung.NameEn = "The Waters of Life";
                levelBeschreibung.MaterialThemeKey = "WOTMSTD";

                break;

            default:
                /* spielende */
                return new();
        }

        levelBeschreibung.MisisonsnameSetzen();

        return levelBeschreibung;
    }
}
