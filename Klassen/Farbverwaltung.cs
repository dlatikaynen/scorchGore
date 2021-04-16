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
    }
}
