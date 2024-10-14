namespace ScorchGore.Classes;

internal interface IOncePerSceneAsset { }

[AttributeUsage(AttributeTargets.Class)]
internal class BuiltInAssetCsgAttribute(string assetKey): Attribute
{
    public string AssetKey => assetKey;
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

internal class Asset(AssetClass assetClass, Guid id, string name)
{
    public Guid Id => id;
    public AssetClass Class => assetClass;
    public string Name => name;

    public virtual string MaterialKey { get; set; } = string.Empty;

    public byte[] Icon = [];
    public byte[] Thumb = [];
}

[BuiltInAssetCsg("WOTM_BERG")]
internal class CsgAssetBerg(Guid id, string name) 
    : Asset(AssetClass.Csg, id, name), IOncePerSceneAsset
{
    public override string MaterialKey { get => "MAT_BERG"; set => base.MaterialKey = value; }

    /// <summary>
    /// 0 means inherit from level beschreibungs skript
    /// </summary>
    public uint BergZufallszahl { get; set; } = 0;

    public uint BergMinHoeheProzent { get; set; } = 10;

    public uint BergMaxHoeheProzent { get; set; } = 39;

    public uint BergRauhheitProzent { get; set; } = 19;
}

[BuiltInAssetCsg("WOTM_CAVECEIL")]
internal class CsgAssetHoehlendecke(Guid id, string name)
    : Asset(AssetClass.Csg, id, name), IOncePerSceneAsset
{
    public override string MaterialKey { get => "MAT_CAVE"; set => base.MaterialKey = value; }

    /// <summary>
    /// 0 means inherit from level beschreibungs skript
    /// </summary>
    public uint HoehleZufallszahl { get; set; } = 0;

    public uint HoehleMinHoeheProzent { get; set; } = 13;

    public uint HoehleMaxHoeheProzent { get; set; } = 48;

    public uint HoehleRauhheitProzent { get; set; } = 50;
}
