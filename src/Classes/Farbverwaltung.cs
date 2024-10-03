using ScorchGore.Constants;

namespace ScorchGore.Classes;

internal class Farbverwaltung
{
    public static Color Bergfarbe { get; set; } = Color.SlateBlue;
    public static Pen Bergstift { get; set; } = new Pen(Bergfarbe);

    public static Color Himmelsfarbe { get; set; } = Color.DarkSlateGray;
    public static Pen Himmelsstift { get; set; } = new Pen(Himmelsfarbe);

    public static Color Stahlfarbe { get; set; } = Color.LightSteelBlue;
    public static Pen Stahlstift { get; set; } = new Pen(Stahlfarbe);

    public static int BergfarbeAlsInt => Bergfarbe.ToArgb();
    public static Brush Bergbuerste => new SolidBrush(Bergfarbe);

    public static int HimmelsfarbeAlsInt => Himmelsfarbe.ToArgb();
    public static Brush Himmelsbuerste => new SolidBrush(Himmelsfarbe);

    public static int StahlfarbeAlsInt => Stahlfarbe.ToArgb();
    public static Brush Stahlbuerste => new SolidBrush(Stahlfarbe);

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
        switch (nullBisDrei)
        {
            case 0:
                return GrasBuersteHell;

            case 1:
                return GrasBuersteDunkler;

            case 2:
                return GrasBuersteMittel;

            default:
                return GrasBuersteAlternativ;
        }
    }

    public static Pen GrasStift(int nullBisDrei)
    {
        switch (nullBisDrei)
        {
            case 0:
                return GrasStiftHell;

            case 1:
                return GrasStiftDunkler;

            case 2:
                return GrasStiftMittel;

            default:
                return GrasStiftAlternativ;
        }

    }

    public static Brush BuersteVonMedium(Medium vonMedium)
    {
        switch (vonMedium)
        {
            case Medium.Berg:
                return Bergbuerste;

            case Medium.Stahl:
                return Stahlbuerste;

            case Medium.Himmel:
                return Himmelsbuerste;

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
                derStift = Bergstift;
                break;

            case Medium.Stahl:
                derStift = Stahlstift;
                break;

            case Medium.Himmel:
                derStift = Himmelsstift;
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(vonMedium), vonMedium, nameof(Medium));
        }

        if (stiftDicke > 1)
        {
            derStift.Width = stiftDicke;
        }
        else
        {
            derStift.Width = 1f;
        }

        return derStift;
    }
}
