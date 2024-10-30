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
                Debugger.Break();

#endif
                continue;
            }

            foreach (var materialKey in asset.MaterialKeys)
            {
                var set = theme.SetsOfMaterials.SingleOrDefault(s => s.Medium == asset.Medium);

                if(set == null)
                {
#if DEBUG
                    Debugger.Break();

#endif
                    continue;
                }

                var mat = set.Materials.SingleOrDefault(m => m.Name == materialKey);

                if(mat == null)
                {
#if DEBUG
                    Debugger.Break();

#endif
                    continue;
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

    public Color GimmeColor(Medium medium, string materialKey)
    {
        return penises[catalog[medium][materialKey]].Color;
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
