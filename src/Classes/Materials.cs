using ScorchGore.Constants;

namespace ScorchGore.Classes;

public class Materials: IDisposable
{
    private bool disposedValue;

    private readonly Pen penHimmel;
    private readonly Brush brushHimmel;

    private readonly Pen penBerg;
    private readonly Brush brushBerg;

    private readonly Pen penHoehle;
    private readonly Brush brushHoehle;

    private readonly Pen penStahl;
    private readonly Brush brushStahl;

    private readonly Pen penGrasHell;
    private readonly Brush brushGrasHell;

    private readonly Pen penGrasMittel;
    private readonly Brush brushGrasMittel;

    private readonly Pen penGrasAlternativ;
    private readonly Brush brushGrasAlternativ;

    private readonly Pen penGrasDunkler;
    private readonly Brush brushGrasDunkler;

    public Materials()
    {
        penHimmel = new Pen(Color.DarkSlateGray);
        brushHimmel = new SolidBrush(Color.DarkSlateGray);

        penBerg = new Pen(Color.SlateBlue);
        brushBerg = new SolidBrush(Color.SlateBlue);

        penHoehle = new Pen(Color.SlateBlue);
        brushHoehle = new SolidBrush(Color.SlateBlue);

        penStahl = new Pen(Color.LightSteelBlue);
        brushStahl = new SolidBrush(Color.LightSteelBlue);

        penGrasHell = new Pen(Color.GreenYellow);
        brushGrasHell = new SolidBrush(Color.Chartreuse);

        penGrasMittel = new Pen(Color.LawnGreen);
        brushGrasMittel = new SolidBrush(Color.LightGreen);

        penGrasAlternativ = new Pen(Color.Lime);
        brushGrasAlternativ = new SolidBrush(Color.SpringGreen);

        penGrasDunkler = new Pen(Color.LimeGreen);
        brushGrasDunkler = new SolidBrush(Color.ForestGreen);
    }

    public Medium Medium { get; set; }

    public Color Bergfarbe
    {
        get
        {
            return penBerg.Color;
        }
        set
        {
            penBerg.Color = value;
        }
    }

    public Pen Bergstift => penBerg;

    public Color Himmelsfarbe
    {
        get
        {
            return penHimmel.Color;
        }
        set
        {
            penHimmel.Color = value;
        }
    }

    public Pen Himmelsstift => penHimmel;

    public Color Stahlfarbe
    {
        get
        {
            return penStahl.Color;
        }
        set
        {
            penStahl.Color = value;
        }
    }

    public Pen Stahlstift => penStahl;

    public Brush Bergbuerste => brushBerg;

    public int HimmelsfarbeAlsInt => Himmelsfarbe.ToArgb();
    public Brush Himmelsbuerste => brushHimmel;

    public Brush Stahlbuerste => brushStahl;

    public Brush GrasBuersteHell => brushGrasHell;
    public Pen GrasStiftHell => penGrasHell;

    public Brush GrasBuersteMittel => brushGrasMittel;
    public Pen GrasStiftMittel => penGrasMittel;

    public Brush GrasBuersteAlternativ => brushGrasAlternativ;
    public Pen GrasStiftAlternativ => penGrasAlternativ;

    public Brush GrasBuersteDunkler => brushGrasDunkler;
    public Pen GrasStiftDunkler => penGrasDunkler;

    public Brush GrasBuerste(int nullBisDrei)
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

    public Pen GrasStift(int nullBisDrei)
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

    public Color FarbeVonMedium(Medium vonMedium)
    {
        return StiftVonMedium(vonMedium).Color;
    }

    public Brush BuersteVonMedium(Medium vonMedium)
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

    public Pen StiftVonMedium(Medium vonMedium, int stiftDicke = 0)
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
        else if (derStift.Width != 1f)
        {
            derStift.Width = 1f;
        }

        return derStift;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                penHimmel.Dispose();
                brushHimmel.Dispose();

                penBerg.Dispose();
                brushBerg.Dispose();

                penHoehle.Dispose();
                brushHoehle.Dispose();

                penStahl.Dispose();
                brushStahl.Dispose();

                penGrasHell.Dispose();
                brushGrasHell.Dispose();

                penGrasMittel.Dispose();
                brushGrasMittel.Dispose();

                penGrasAlternativ.Dispose();
                brushGrasAlternativ.Dispose();

                penGrasDunkler.Dispose();
                brushGrasDunkler.Dispose();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
