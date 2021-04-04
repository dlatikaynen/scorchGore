using ScorchGore.Aufzaehlungen;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ScorchGore.Klassen
{
    internal class LevelBeschreibung
    {
        public LevelBeschreibung()
        {
            this.SpielerPosition1 = Point.Empty;
            this.SpielerPosition2 = Point.Empty;
            this.Plateaus = new Dictionary<int, Plateau>();
        }

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

        /* Besonderheiten der Topologie */
        public Dictionary<int, Plateau> Plateaus { get; private set; }

        /* Beschreibung für ein Missionslevel */
        public int MissionsNummer { get; set; }
        public string MissionsName { get; set; }

        public int LevelNummer { get; set; }
        public int LevelNummerInMission { get; set; }
        public string LevelName { get; set; }

        public Point SpielerPosition1 { get; set; }
        public Point SpielerPosition2 { get; set; }

        internal void MisisonsnameSetzen() => this.MissionsName = this.MissionsnameBestimmen(this.MissionsNummer);

        internal void Plateau(int bodenHoehe, int startX, int endetX) => this.Plateaus.Add(startX, new Plateau { Elevation = bodenHoehe, StartX = startX, EndetX = endetX });

        public int MinHoeheProzent(ObenUnten obenUnten) => obenUnten == ObenUnten.HoehlenTeil ? this.HoehleMinHoeheProzent : this.BergMinHoeheProzent;
        public int MaxHoeheProzent(ObenUnten obenUnten) => obenUnten == ObenUnten.HoehlenTeil ? this.HoehleMaxHoeheProzent : this.BergMaxHoeheProzent;
        public int RauhheitProzent(ObenUnten obenUnten) => obenUnten == ObenUnten.HoehlenTeil ? this.HoehleRauhheitProzent : this.BergRauhheitProzent;

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
