namespace ScorchGore.Classes;

public class AssetPlacement
{
    public string AssetKey { get; set; } = string.Empty;

    public Point Location { get; set; } = Point.Empty;

    public bool OrientedRtl { get; set; } = false; // facing right

    public Dictionary<string, uint> ParamsUInt { get; set; } = [];

    public Dictionary<string, int> ParamsInt { get; set; } = [];

    public Dictionary<string, bool> ParamsFlags { get; set; } = [];

    public Dictionary<string, string> ParamsString { get; set; } = [];
}
