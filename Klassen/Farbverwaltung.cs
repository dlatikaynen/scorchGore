using System.Drawing;

namespace ScorchGore.Klassen
{
    internal class Farbverwaltung
    {        
        public static readonly Color Bergfarbe = Color.SlateBlue;
        public static readonly int BergfarbeAlsInt = Farbverwaltung.Bergfarbe.ToArgb();
        public static readonly Pen Bergstift = new Pen(Farbverwaltung.Bergfarbe);
        public static readonly Brush Bergbuerste = new SolidBrush(Farbverwaltung.Bergfarbe);

        public static readonly Color Himmelsfarbe = Color.DarkSlateGray;
        public static readonly int HimmelsfarbeAlsInt = Farbverwaltung.Himmelsfarbe.ToArgb();
        public static readonly Pen Himmelsstift = new Pen(Farbverwaltung.Himmelsfarbe);
        public static readonly Brush Himmelsbuerste = new SolidBrush(Farbverwaltung.Himmelsfarbe);
    }
}
