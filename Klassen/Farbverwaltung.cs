using ScorchGore.Aufzaehlungen;
using System;
using System.Drawing;

namespace ScorchGore.Klassen
{
    internal class Farbverwaltung
    {
        public static Color Bergfarbe { get; set; } = Color.SlateBlue;
        public static Pen Bergstift { get; set; } = new Pen(Farbverwaltung.Bergfarbe);

        public static Color Himmelsfarbe { get; set; } = Color.DarkSlateGray;
        public static Pen Himmelsstift { get; set; } = new Pen(Farbverwaltung.Himmelsfarbe);

        public static Color Stahlfarbe { get; set; } = Color.LightSteelBlue;
        public static Pen Stahlstift { get; set; } = new Pen(Farbverwaltung.Stahlfarbe);

        public static int BergfarbeAlsInt => Farbverwaltung.Bergfarbe.ToArgb();
        public static Brush Bergbuerste => new SolidBrush(Farbverwaltung.Bergfarbe);

        public static int HimmelsfarbeAlsInt => Farbverwaltung.Himmelsfarbe.ToArgb();
        public static Brush Himmelsbuerste => new SolidBrush(Farbverwaltung.Himmelsfarbe);

        public static int StahlfarbeAlsInt => Farbverwaltung.Stahlfarbe.ToArgb();
        public static Brush Stahlbuerste => new SolidBrush(Farbverwaltung.Stahlfarbe);

        public static Brush BuersteVonMedium(Medium vonMedium)
        {
            switch(vonMedium)
            {
                case Medium.Berg:
                    return Farbverwaltung.Bergbuerste;

                case Medium.Stahl:
                    return Farbverwaltung.Stahlbuerste;

                default:
                    throw new ArgumentOutOfRangeException(nameof(vonMedium), vonMedium, nameof(Medium));
            }
        }

        public static Pen StiftVonMedium(Medium vonMedium, int stiftDicke = 0)
        {
            Pen derStift;
            switch (vonMedium)
            {
                case Medium.Berg:
                    derStift = Farbverwaltung.Bergstift;
                    break;

                case Medium.Stahl:
                    derStift = Farbverwaltung.Stahlstift;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(vonMedium), vonMedium, nameof(Medium));
            }

            if (stiftDicke > 1)
            {
                derStift.Width = (float)stiftDicke;
            }
            else
            {
                derStift.Width = 1f;
            }

            return derStift;
        }
    }
}
