using System;

namespace ScorchGore
{
    public class SpielerNamen
    {
        private static string[] namensPaare = {
            "Laurel", "Hardy",
            "Minge", "Bracket",
            "Sherlock", "Watson",
            "Phineas", "Ferb",
            "Finn", "Jake",
            "Lukas", "Jonas",
            "Noob", "Soos",
            "Jürgen", "Rüdiger",
            "Dörte", "Eberhard"
        };

        protected static int AnzahlNamenspaare => SpielerNamen.namensPaare.Length / 2;

        public static Tuple<string, string> ZufallsNamenspaar => SpielerNamen.NamensPaar(new Random().Next(SpielerNamen.AnzahlNamenspaare));

        private static Tuple<string, string> NamensPaar(int namensIndex) => new Tuple<string, string>(
            SpielerNamen.namensPaare[namensIndex * 2],
            SpielerNamen.namensPaare[namensIndex * 2 + 1]
        );
    }
}
