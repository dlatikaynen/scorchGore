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

        public static Brush GrasBuersteHell => Brushes.Chartreuse;
        public static Pen GrasStiftHell => Pens.GreenYellow;

        public static Brush GrasBuersteMittel => Brushes.LightGreen;
        public static Pen GrasStiftMittel => Pens.LawnGreen;

        public static Brush GrasBuersteAlternativ => Brushes.SpringGreen;
        public static Pen GrasStiftAlternativ => Pens.Lime;

        public static Brush GrasBuersteDunkler => Brushes.ForestGreen;
        public static Pen GrasStiftDunkler => Pens.LimeGreen;

        public static Brush GrasBuerste(int nullBisDrei)
        {
            switch(nullBisDrei)
            {
                case 0:
                    return Farbverwaltung.GrasBuersteHell;

                case 1:
                    return Farbverwaltung.GrasBuersteDunkler;

                case 2:
                    return Farbverwaltung.GrasBuersteMittel;

                default:
                    return Farbverwaltung.GrasBuersteAlternativ;
            }
        }
           
        public static Pen GrasStift(int nullBisDrei)
        {
            switch (nullBisDrei)
            {
                case 0:
                    return Farbverwaltung.GrasStiftHell;

                case 1:
                    return Farbverwaltung.GrasStiftDunkler;

                case 2:
                    return Farbverwaltung.GrasStiftMittel;

                default:
                    return Farbverwaltung.GrasStiftAlternativ;
            }

        }

        public static Brush BuersteVonMedium(Medium vonMedium)
        {
            switch(vonMedium)
            {
                case Medium.Berg:
                    return Farbverwaltung.Bergbuerste;

                case Medium.Stahl:
                    return Farbverwaltung.Stahlbuerste;
                
                case Medium.Himmel:
                    return Farbverwaltung.Himmelsbuerste;

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

                case Medium.Himmel:
                    derStift = Farbverwaltung.Himmelsstift;
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
