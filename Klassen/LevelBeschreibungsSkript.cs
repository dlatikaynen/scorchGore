using System;
using System.Collections.Generic;

namespace ScorchGore.Klassen
{
    internal class LevelBeschreibungsSkript
    {
        public List<LevelArchitekturPfad> Pfade { get; protected set; }

        public LevelBeschreibungsSkript()
        {
            this.Pfade = new List<LevelArchitekturPfad>();
        }

        internal static LevelBeschreibungsSkript Laden(LevelBeschreibung levelBeschreibung)
        {


            return null;
        }

        internal class LevelArchitekturPfad
        {

        }
    }
}
