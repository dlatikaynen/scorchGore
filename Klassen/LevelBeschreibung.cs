using ScorchGore.Aufzaehlungen;
using System;

namespace ScorchGore.Klassen
{
    internal class LevelBeschreibung
    {
        /// <summary>
        /// Laufzeit-Tracking für das Online-Zusammenspiel
        /// </summary>
        public MitspielerFindenStatus MitspielerStatus { get; set; }

        /* Beschreibung eines normalen Berges */
        public int BergZufallszahl { get; set; }
        public int BergMinHoeheProzent { get; set; }
        public int BergMaxHoeheProzent { get; set; }
        public int BergRauhheitProzent { get; set; }

        /* Beschreibung des zweiten Höhenzugs im Falle eine Höhle */
        public bool IstHoehle { get; set; }
        public int HoehleMinHoeheProzent { get; set; }
        public int HoehleMaxHoeheProzent { get; set; }
        public int HoehleRauhheitProzent { get; set; }

        /* Beschreibung für ein Missionslevel */
        public int MissionsNummer { get; set; }
        public string MissionsName { get; set; }

        public int LevelNummer { get; set; }
        public int LevelNummerInMission { get; set; }
        public string LevelName { get; set; }

        internal void MisisonsnameSetzen() => this.MissionsName = this.MissionsnameBestimmen(this.MissionsNummer);

        private string MissionsnameBestimmen(int missionsNummer)
        {
            switch(missionsNummer)
            {
                case 1: return "Blue Mountains";
            }

            return null;
        }
    }
}
