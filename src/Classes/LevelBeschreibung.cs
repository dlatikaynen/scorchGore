using ScorchGore.Configuration;
using ScorchGore.Constants;
using ScorchGore.Leved;
using System.ComponentModel;
using System.Reflection;
using Xlat = ScorchGore.Translation.Translation;

namespace ScorchGore.Classes;

public class LevelBeschreibung
{
    public LevelBeschreibung()
    {
        SpielerPosition1 = Point.Empty;
        SpielerPosition2 = Point.Empty;
        Plateaus = [];
        Materials = new();
    }

    [Browsable(false)]
    private static string? BergAssetKey => typeof(CsgAssetBerg).GetCustomAttribute<BuiltInAssetCsgAttribute>()?.AssetKey;

    [Browsable(false)]
    private static string? HoehleAssetKey => typeof(CsgAssetHoehlendecke).GetCustomAttribute<BuiltInAssetCsgAttribute>()?.AssetKey;

    [Browsable(false)]
    public bool IsMountain => AssetPlacement.Any(p => p.AssetKey == BergAssetKey);

    [Browsable(false)]
    public bool IsCave => AssetPlacement.Any(p => p.AssetKey == HoehleAssetKey);

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

    public uint Zufallszahl { get; set; } = 58008;

    public Point SpielerPosition1 { get; set; }

    public Point SpielerPosition2 { get; set; }

    public Color ColorBackground { get; set; } = Color.Empty;

    [TypeConverter(typeof(BackdropAssetDropdownTypeConverter))]
    public string BackdropAssetKey { get; set; } = string.Empty;
    #endregion

    public List<AssetPlacement> AssetPlacement { get; set; } = new();

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

    internal void SetScriptSource(string scriptSource)
    {
        BeschreibungsSkript ??= new();
        BeschreibungsSkript.SetSource(scriptSource);
    }

    internal void Plateau(int bodenHoehe, int startX, int endetX) => Plateaus.Add(startX, new Plateau { Elevation = bodenHoehe, StartX = startX, EndetX = endetX });

    [Browsable(false)]
    private AssetPlacement? Berg => AssetPlacement.SingleOrDefault(p => p.AssetKey == BergAssetKey);

    [Browsable(false)]
    private AssetPlacement? Hoehle => AssetPlacement.SingleOrDefault(p => p.AssetKey == HoehleAssetKey);

    [Browsable(false)]
    private uint BergAssetZufallszahl => Berg?.ParamsUInt[nameof(CsgAssetBerg.BergZufallszahl)] ?? 0;

    [Browsable(false)]
    public uint BergZufallszahl => BergAssetZufallszahl == 0 ? Zufallszahl : BergAssetZufallszahl;

    [Browsable(false)]
    public uint MinHoeheProzent(ObenUnten obenUnten) => (obenUnten == ObenUnten.HoehlenTeil ? Hoehle?.ParamsUInt[nameof(CsgAssetHoehlendecke.HoehleMinHoeheProzent)] : Berg?.ParamsUInt[nameof(CsgAssetBerg.BergMinHoeheProzent)]) ?? 0;

    [Browsable(false)]
    public uint MaxHoeheProzent(ObenUnten obenUnten) => (obenUnten == ObenUnten.HoehlenTeil ? Hoehle?.ParamsUInt[nameof(CsgAssetHoehlendecke.HoehleMaxHoeheProzent)] : Berg?.ParamsUInt[nameof(CsgAssetBerg.BergMaxHoeheProzent)]) ?? 0;

    [Browsable(false)]
    public uint RauhheitProzent(ObenUnten obenUnten) => (obenUnten == ObenUnten.HoehlenTeil ? Hoehle?.ParamsUInt[nameof(CsgAssetHoehlendecke.HoehleRauhheitProzent)] : Berg?.ParamsUInt[nameof(CsgAssetBerg.BergRauhheitProzent)]) ?? 0;

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

    internal static string MissionsnameBestimmen(int missionsNummer, string? lcid = null)
    {
        return missionsNummer switch
        {
            1 => Xlat.GetSpecificTranslation(lcid ?? InstanceSettings.Language, 4), // Siniset vuoret
            2 => Xlat.GetSpecificTranslation(lcid ?? InstanceSettings.Language, 5),  // Zatychlo pid snihom
            3 => Xlat.GetSpecificTranslation(lcid ?? InstanceSettings.Language, 6),  // Paratrouper
            4 => Xlat.GetSpecificTranslation(lcid ?? InstanceSettings.Language, 7),  // Dzvonyat' dzvony
            5 => Xlat.GetSpecificTranslation(lcid ?? InstanceSettings.Language, 8),  // Deadly Nightshade
            6 => Xlat.GetSpecificTranslation(lcid ?? InstanceSettings.Language, 9),  // Usses and Thems
            7 => Xlat.GetSpecificTranslation(lcid ?? InstanceSettings.Language, 10), // Mid-size Nightmares
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
