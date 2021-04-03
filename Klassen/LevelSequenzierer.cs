using ScorchGore.OnlineMultiplayer;
using System;
using System.Collections.Generic;
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
                    break;
            }

            levelBeschreibung.MisisonsnameSetzen();
            return levelBeschreibung;
        }
    }
}
