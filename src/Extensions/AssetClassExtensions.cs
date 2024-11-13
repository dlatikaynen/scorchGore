using ScorchGore.Classes;
using Xlat = ScorchGore.Translation.Translation;

namespace ScorchGore.Extensions;

internal static class AssetClassExtensions
{
    public static string GetTranslatedName(this AssetClass assetClass)
    {
        return assetClass switch
        {
            AssetClass.Prefab => Xlat.µ(130),// pre-fab 
            AssetClass.Backdrop => Xlat.µ(129),// backdrop
            AssetClass.Sfx => Xlat.µ(128),// sound effect
            AssetClass.Moosic => Xlat.µ(127),// music 
            AssetClass.Csg => Xlat.µ(85),// CSG
            _ => throw new ArgumentOutOfRangeException(nameof(assetClass), assetClass, "undefined value"),
        };
    }
}
