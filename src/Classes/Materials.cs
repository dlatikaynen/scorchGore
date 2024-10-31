using ScorchGore.Constants;
using ScorchGore.Leved;
using System.Diagnostics;

namespace ScorchGore.Classes;

public class Materials: IDisposable
{
    private bool disposedValue;

    private readonly List<Pen> penises = [];
    private readonly List<SolidBrush> bushes = [];
    private readonly Dictionary<Medium, Dictionary<string, int>> catalog = [];

/*
        penGrasDunkler = new Pen(Color.LimeGreen);
        brushGrasDunkler = new SolidBrush(Color.ForestGreen);
*/

    /// <summary>
    /// Creates a pen and a brush for every material
    /// that the level uses
    /// </summary>
    public void PrepareForLevel(LevelBeschreibung lvl)
    {
        var theme = DesignWorkspace.MaterialThemes.Single(mt => mt.Name == lvl.MaterialThemeKey);

        if(theme == null)
        {
#if DEBUG
            Debugger.Break();

#endif
            return;
        }

        var assetKeysOfRelevance = lvl.AssetPlacement.Select(ap => ap.AssetKey);
        foreach (var assetKey in assetKeysOfRelevance)
        {
            var asset = DesignWorkspace.Assets.SingleOrDefault(a => a.Name == assetKey);

            if (asset == null)
            {
#if DEBUG
                // no asset definition in design workspace.
                // this is a problem, we cannot simply make one up
                Debugger.Break();

#endif
                continue;
            }

            foreach (var materialKey in asset.MaterialKeys)
            {
                var set = theme.SetsOfMaterials.SingleOrDefault(s => s.Medium == asset.Medium);

                if (set == null)
                {
                    // now this is not a problem actually, we simply allocate it
                    set = new SetOfMaterials(asset.Medium, []);
                    theme.SetsOfMaterials.Add(set);
                    DesignWorkspace.SetDirty();
                }

                var mat = set.Materials.SingleOrDefault(m => m.Name == materialKey);

                if (mat == null)
                {
                    // now this is not a problem really, we just allocate it
                    // we might even know the correct color if it is a built-in
                    var color = asset.DefaultColorOf(materialKey);
                    mat = theme.AllocateMaterial(set, materialKey, color);
                }

                var nextIndex = penises.Count; // shame this is not an array
                var doAdd = true;

                if(catalog.TryGetValue(asset.Medium, out var palette))
                {
                    if (palette.ContainsKey(materialKey))
                    {
                        doAdd = false;
                    }
                    else
                    {
                        palette.Add(materialKey, nextIndex);
                    }
                }
                else
                {
                    catalog.Add(asset.Medium, new Dictionary<string, int>() { { materialKey, nextIndex } });
                }

                if (doAdd)
                {
                    penises.Add(new Pen(mat.Color));
                    bushes.Add(new SolidBrush(mat.Color));
                }
            }
        }
    }

    public Pen StiftVonMedium(Medium medium, string materialKey, int width)
    {
        var pen = penises[catalog[medium][materialKey]];

        pen.Width = width;

        return pen;
    }

    public SolidBrush BuersteVonMedium(Medium medium, string materialKey)
    {
        return bushes[catalog[medium][materialKey]];
    }

    public Color FarbeVonMedium(Medium vonMedium, string materialKey)
    {
        return penises[catalog[vonMedium][materialKey]].Color;
    }

    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                foreach(var pen in penises)
                {
                    pen.Dispose();
                }

                foreach (var bush in bushes)
                {
                    bush.Dispose();
                }

                catalog.Clear();
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
