namespace ScorchGore.Classes;

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

    public byte[] Icon = [];
    public byte[] Thumb = [];
}
