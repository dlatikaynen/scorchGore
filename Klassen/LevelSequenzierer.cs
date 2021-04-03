using ScorchGore.OnlineMultiplayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorchGore.Klassen
{
    internal static class LevelSequenzierer
    {
        private const int zufallsZahlenGenerator = 316685421;

        /// <summary>
        /// Das Zufallslevel im "Übungsmodus" hat die Nummer 0
        /// </summary>
        public static LevelBeschreibung ErzeugeLevelBeschreibung(int laufendeLevelNummer)
        {
            var levelBeschreibung = new LevelBeschreibung { LevelNummer = laufendeLevelNummer };
            switch(laufendeLevelNummer)
            {
                case 1:
                    levelBeschreibung.MissionsNummer = 1;
                    levelBeschreibung.LevelNummerInMission = 1;
                    levelBeschreibung.LevelName = "The Blue Mountains";
                    levelBeschreibung.BergMinHoeheProzent = 13;
                    levelBeschreibung.BergMaxHoeheProzent = 48;
                    levelBeschreibung.BergRauhheitProzent = 21;
                    levelBeschreibung.BergZufallszahl = LevelSequenzierer.zufallsZahlenGenerator;
                    levelBeschreibung.Plateau(645 - 460, 82, 200);
                    levelBeschreibung.SpielerPosition1 = new Point(112, Main.spielerBasisHoehe);
                    levelBeschreibung.Plateau(645 - 415, 638, 700);
                    levelBeschreibung.SpielerPosition2 = new Point(673, Main.spielerBasisHoehe);
                    break;
            }

            levelBeschreibung.MisisonsnameSetzen();
            return levelBeschreibung;
        }
    }
}
