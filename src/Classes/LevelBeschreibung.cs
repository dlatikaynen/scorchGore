using ScorchGore.Configuration;
using ScorchGore.Constants;
using ScorchGore.Leved;
using System.ComponentModel;
using Xlat = ScorchGore.Translation.Translation;

namespace ScorchGore.Classes;

public class LevelBeschreibung
{
    public LevelBeschreibung()
    {
        SpielerPosition1 = Point.Empty;
        SpielerPosition2 = Point.Empty;
        Plateaus = [];
        IsMountain = true;
        Materials = new();
    }

    [Browsable(false)]
    public bool IsBuiltin { get; set; } = false;

    #region Editable Properties
    public string NameEn { get; set; } = string.Empty;

    public string NameDe { get; set; } = string.Empty;

    public string NameFi { get; set; } = string.Empty;

    public string NameUa { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;
    
    public uint Width { get; set; } = 640;

    public uint Height { get; set; } = 480;

    public uint BergZufallszahl { get; set; } = 58008;

    public Point SpielerPosition1 { get; set; }

    public Point SpielerPosition2 { get; set; }

    public bool IsMountain { get; set; } = false;

    public uint BergMinHoeheProzent { get; set; } = 10;

    public uint BergMaxHoeheProzent { get; set; } = 39;

    public uint BergRauhheitProzent { get; set; } = 19;

    public bool IsCave { get; set; } = false;

    public uint HoehleMinHoeheProzent { get; set; } = 13;

    public uint HoehleMaxHoeheProzent { get; set; } = 48;

    public uint HoehleRauhheitProzent { get; set; } = 50;

    public Color ColorBackground { get; set; } = Color.Empty;

    public Color ColorMountain { get; set; } = Color.Empty;

    public Color ColorCave { get; set; } = Color.Empty;

    [TypeConverter(typeof(BackdropAssetDropdownTypeConverter))]
    public string BackdropAssetKey { get; set; } = string.Empty;
    #endregion

    /* Besonderheiten der Topologie */
    public Dictionary<int, Plateau> Plateaus { get; private set; }
    public LevelBeschreibungsSkript BeschreibungsSkript { get; set; } = new();

    [Browsable(false)]
    public Materials Materials { get; set; }

    [Browsable(false)]
    public bool IstGeskriptet => BeschreibungsSkript != null;

    /* Beschreibung für ein Missionslevel */
    [Browsable(false)]
    public int MissionsNummer { get; set; } = 0;

    [Browsable(false)]
    public string MissionsName { get; set; } = string.Empty;

    [Browsable(false)]
    public int LevelNummer { get; set; } = 0;

    [Browsable(false)]
    public int LevelNummerInMission { get; set; } = 0;

    internal void MisisonsnameSetzen() => MissionsName = MissionsnameBestimmen(MissionsNummer);

    internal void Plateau(int bodenHoehe, int startX, int endetX) => Plateaus.Add(startX, new Plateau { Elevation = bodenHoehe, StartX = startX, EndetX = endetX });

    [Browsable(false)]
    public uint MinHoeheProzent(ObenUnten obenUnten) => obenUnten == ObenUnten.HoehlenTeil ? HoehleMinHoeheProzent : BergMinHoeheProzent;

    [Browsable(false)]
    public uint MaxHoeheProzent(ObenUnten obenUnten) => obenUnten == ObenUnten.HoehlenTeil ? HoehleMaxHoeheProzent : BergMaxHoeheProzent;

    [Browsable(false)]
    public uint RauhheitProzent(ObenUnten obenUnten) => obenUnten == ObenUnten.HoehlenTeil ? HoehleRauhheitProzent : BergRauhheitProzent;

    [Browsable(false)]
    internal string LevelName
    {
        get
        {
            switch(InstanceSettings.Language)
            {
                case "de":
                    return NameDe;

                case "fi":
                    return NameFi;

                case "ua":
                    return NameUa;

                default:
                    return NameEn;
            }
        }
    }

    internal static string MissionsnameBestimmen(int missionsNummer)
    {
        return missionsNummer switch
        {
            1 => Xlat.µ(4),  // Siniset vuoret
            2 => Xlat.µ(5),  // Zatychlo pid snihom
            3 => Xlat.µ(6),  // Paratrouper
            4 => Xlat.µ(7),  // Dzvonyat' dzvony
            5 => Xlat.µ(8),  // Deadly Nightshade
            6 => Xlat.µ(9),  // Usses and Thems
            7 => Xlat.µ(10), // Mid-size Nightmares
            _ => throw new ArgumentOutOfRangeException(
                nameof(missionsNummer),
                missionsNummer,
                "1-?"
            )
        };
    }

    public class BackdropAssetDropdownTypeConverter : TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext? context) => true;
        
        public override StandardValuesCollection? GetStandardValues(ITypeDescriptorContext? context)
        {
            var list = DesignWorkspace
                .Assets
                .Where(a => a.Class == AssetClass.Backdrop)
                .Select(a => a.Name)
                .ToList();

            list.Insert(0, string.Empty);

            return new StandardValuesCollection(list);
        }
    }
}
