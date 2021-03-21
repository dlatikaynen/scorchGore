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
            "Dörte", "Eberhard",
            "CASE", "TARS",
            "Mac", "Cheese",
            "Alice", "Bob",
            "Batman", "Robin",
            "Marlin", "Dory",
            "Kelvin", "Celsius",
            "Tesla", "Edison",
            "Fast", "Furious",
            "Romeo", "Juliet",
            "Homer", "Ulysses",
            "Donald", "Daisy",
            "Sculder", "Molly",
            "Mick", "Rorty",
            "Doctor", "Dalek",
            "Anna", "Elsa", 
            "Simon", "Furuncle",
            "Scritchy", "Atchy",
            "Thelma", "Louise",
            "Stan", "Kyle",
            "Link", "Ravioli",
            "Naruto", "Sasuke",
            "Sasuke", "Ponyo",
            "Cynthia", "Henry",
            "Hermaphrodites", "Salmacis",
            "Marie", "Pierre",
            "Peter", "Paul",
            "Bojack", "Carolyn",
            "Venus", "Serena",
            "Orville", "Wilbur",
            "Adolf", "Josef",
            "Nicolae", "Elena",
            "Elisa", "Madeleine",
            "David", "Goliath",
            "Cain", "Abel",
            "Eve", "Adam",
            "Lot", "Edith",
            "Mei", "Satsuki",
            "Sophie", "Haku",
            "Bart", "Lisa",
            "Yin", "Yang",
            "Feng", "Shui",
            "Hund", "Katze",
            "Rose", "Jack",
            "Cathy", "Heathcliff",
            "Sally", "Angie"
        };

        protected static int AnzahlNamenspaare => SpielerNamen.namensPaare.Length / 2;

        public static Tuple<string, string> ZufallsNamenspaar => SpielerNamen.NamensPaar(new Random().Next(SpielerNamen.AnzahlNamenspaare));

        private static Tuple<string, string> NamensPaar(int namensIndex) => new Tuple<string, string>(
            SpielerNamen.namensPaare[namensIndex * 2],
            SpielerNamen.namensPaare[namensIndex * 2 + 1]
        );
    }
}
