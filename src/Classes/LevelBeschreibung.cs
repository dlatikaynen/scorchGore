using ScorchGore.Constants;

namespace ScorchGore.Classes;

public class LevelBeschreibung
{
    public LevelBeschreibung()
    {
        SpielerPosition1 = Point.Empty;
        SpielerPosition2 = Point.Empty;
        Plateaus = [];
        IstBerg = true;
    }

    /* Beschreibung eines normalen Berges */
    public int BergZufallszahl { get; set; }
    public int BergMinHoeheProzent { get; set; }
    public int BergMaxHoeheProzent { get; set; }
    public int BergRauhheitProzent { get; set; }

    /* Beschreibung des zweiten Höhenzugs im Falle eine Höhle */
    public bool IstBerg { get; set; }
    public bool IstHoehle { get; set; }
    public bool IstGeskriptet => BeschreibungsSkript != null;
    public int HoehleMinHoeheProzent { get; set; }
    public int HoehleMaxHoeheProzent { get; set; }
    public int HoehleRauhheitProzent { get; set; }

    /* Besonderheiten der Topologie */
    public Dictionary<int, Plateau> Plateaus { get; private set; }
    public LevelBeschreibungsSkript BeschreibungsSkript { get; set; } = new();

    /* Beschreibung für ein Missionslevel */
    public int MissionsNummer { get; set; } = 0;
    public string MissionsName { get; set; } = string.Empty;

    public int LevelNummer { get; set; } = 0;
    public int LevelNummerInMission { get; set; } = 0;
    public string LevelName { get; set; } = string.Empty;
    public int LevelWidth { get; set; } // logical pixels
    public int LevelHeight { get; set; }

    public Point SpielerPosition1 { get; set; }
    public Point SpielerPosition2 { get; set; }

    internal void MisisonsnameSetzen() => MissionsName = MissionsnameBestimmen(MissionsNummer);

    internal void Plateau(int bodenHoehe, int startX, int endetX) => Plateaus.Add(startX, new Plateau { Elevation = bodenHoehe, StartX = startX, EndetX = endetX });

    public int MinHoeheProzent(ObenUnten obenUnten) => obenUnten == ObenUnten.HoehlenTeil ? HoehleMinHoeheProzent : BergMinHoeheProzent;
    public int MaxHoeheProzent(ObenUnten obenUnten) => obenUnten == ObenUnten.HoehlenTeil ? HoehleMaxHoeheProzent : BergMaxHoeheProzent;
    public int RauhheitProzent(ObenUnten obenUnten) => obenUnten == ObenUnten.HoehlenTeil ? HoehleRauhheitProzent : BergRauhheitProzent;

    private string MissionsnameBestimmen(int missionsNummer)
    {
        switch (missionsNummer)
        {
            case 1: return "Blue Mountains";
        }

        throw new ArgumentOutOfRangeException(
            nameof(missionsNummer),
            missionsNummer,
            "1-?"
        );
    }
}
