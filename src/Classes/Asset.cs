using ScorchGore.Constants;

namespace ScorchGore.Classes;

internal interface IOncePerSceneAsset { }

[AttributeUsage(AttributeTargets.Class)]
internal class BuiltInAssetCsgAttribute(string assetKey, string id): Attribute
{
    public string AssetKey => assetKey;
    public Guid Id => Guid.Parse(id);
}

internal enum AssetClass 
{ 
    Unknown = 0,
    Csg = 1, // constructive solid geometry, procedural
    Prefab = 2,
    Backdrop = 3,
    Sfx = 4,
    Moosic = 5
}

internal class Asset(AssetClass assetClass, Guid id, bool isBuiltin, string name)
{
    public Guid Id => id;
    public AssetClass Class => assetClass;
    public bool IsBuiltin => isBuiltin;
    public string Name => name;

    public virtual Medium Medium { get; set; } = Medium.Berg;
    public virtual string[] MaterialKeys { get; set; } = [];

    public byte[] Icon = [];
    public byte[] Thumb = [];
}

[BuiltInAssetCsg("WOTM_BERG", "{39B1E120-3AC5-44A0-9215-4BA741B4E507}")]
internal class CsgAssetBerg(Guid id, string name) 
    : Asset(AssetClass.Csg, id, isBuiltin: true, name), IOncePerSceneAsset
{
    public override string[] MaterialKeys { get => ["MAT_BERG"]; set => base.MaterialKeys = value; }

    /// <summary>
    /// 0 means inherit from level beschreibungs skript
    /// </summary>
    public uint BergZufallszahl { get; set; } = 0;

    public uint BergMinHoeheProzent { get; set; } = 10;

    public uint BergMaxHoeheProzent { get; set; } = 39;

    public uint BergRauhheitProzent { get; set; } = 19;
}

[BuiltInAssetCsg("WOTM_CAVECEIL", "{C5C2520C-1821-45BB-8D76-2AE1634E78B6}")]
internal class CsgAssetHoehlendecke(Guid id, string name)
    : Asset(AssetClass.Csg, id, isBuiltin: true, name), IOncePerSceneAsset
{
    public override string[] MaterialKeys { get => ["MAT_CAVE"]; set => base.MaterialKeys = value; }

    /// <summary>
    /// 0 means inherit from level beschreibungs skript
    /// </summary>
    public uint HoehleZufallszahl { get; set; } = 0;

    public uint HoehleMinHoeheProzent { get; set; } = 13;

    public uint HoehleMaxHoeheProzent { get; set; } = 48;

    public uint HoehleRauhheitProzent { get; set; } = 50;
}

[BuiltInAssetCsg("WOTM_GRAS", "{96E3DC6A-5140-4B64-AC65-1EBA50AD2401}")]
internal class CsgAssetGras(Guid id, string name)
    : Asset(AssetClass.Csg, id, isBuiltin: true, name)
{
    public override string[] MaterialKeys
    { 
        get => ["MAT_GRASH", "MAT_GRASM", "MAT_GRASD", "MAT_GRASA"]; 
        set => base.MaterialKeys = value; 
    }
}
