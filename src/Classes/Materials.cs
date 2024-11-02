using ScorchGore.Constants;
using ScorchGore.Leved;
using System.Diagnostics;

namespace ScorchGore.Classes;

public class Materials: IDisposable
{
    private bool disposedValue;

    private Pen? skyPen;
    private SolidBrush? skyBrush;
    private readonly List<Pen> penises = [];
    private readonly List<SolidBrush> bushes = [];
    private readonly Dictionary<Medium, Dictionary<string, int>> catalog = [];

    /// <summary>
    /// Creates a pen and a brush for every material
    /// that the level uses
    /// </summary>
    public void PrepareForLevel(LevelBeschreibung lvl)
    {
        FreeGdiRessources();
        var theme = DesignWorkspace.MaterialThemes.Single(mt => mt.Name == lvl.MaterialThemeKey);

        if(theme == null)
        {
#if DEBUG
            Debugger.Break();

#endif
            return;
        }

        if (string.IsNullOrEmpty(lvl.BackdropAssetKey) && lvl.ColorBackground != Color.Empty)
        {
            if (!theme.SetsOfMaterials.Any(som => som.Medium == Medium.Himmel))
            {
                theme.SetsOfMaterials.Add(new SetOfMaterials(Medium.Himmel, []));
                DesignWorkspace.SetDirty();
            }

            if (!catalog.ContainsKey(Medium.Himmel))
            {
                catalog.Add(Medium.Himmel, []);
            }

            skyBrush = new SolidBrush(lvl.ColorBackground);
            skyPen = new Pen(lvl.ColorBackground);
        }
        else
        {
            // when we have a background bitmap, then the sky color will make that show through
            var eraser = Color.FromArgb(0, Color.Black);

            skyBrush = new SolidBrush(eraser);
            skyPen = new Pen(eraser);
        }

        // some required material keys may come from the level beschreibungs script,
        // which can mention some without using an asset ("STAHL MAT_KEY #colorname" syntax)
        var sceneMaterials = LevelBeschreibungsSkript.GetBOM(lvl);

        foreach ((var medium, var materialKey) in sceneMaterials)
        {
            ProvisionMaterial(theme, medium, materialKey, Color.Empty);
        }

        // the rest of the material keys that we need will come from the placed assets
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
                ProvisionMaterial(theme, asset.Medium, materialKey, asset.DefaultColorOf(materialKey));
            }
        }
    }

    private void ProvisionMaterial(MaterialTheme theme, Medium medium, string materialKey, Color desiredColor)
    {
        var set = theme.SetsOfMaterials.SingleOrDefault(s => s.Medium == medium);

        if (set == null)
        {
            // now this is not a problem actually, we simply allocate it
            set = new SetOfMaterials(medium, []);
            theme.SetsOfMaterials.Add(set);
            DesignWorkspace.SetDirty();
        }

        var mat = set.Materials.SingleOrDefault(m => m.Name == materialKey);

        if (mat == null)
        {
            // now this is not a problem really, we just allocate it
            // we might even know the correct color if it is a built-in
            var color = desiredColor;
            mat = MaterialTheme.AllocateMaterial(set, materialKey, color);
        }

        var nextIndex = penises.Count; // shame this is not an array
        var doAdd = true;

        if (catalog.TryGetValue(medium, out var palette))
        {
            if (!palette.TryAdd(materialKey, nextIndex))
            {
                doAdd = false;
            }
        }
        else
        {
            catalog.Add(medium, new Dictionary<string, int>() { { materialKey, nextIndex } });
        }

        if (doAdd)
        {
            penises.Add(new Pen(mat.Color));
            bushes.Add(new SolidBrush(mat.Color));
        }
    }

    public Pen StiftVonMedium(Medium medium, string materialKey, int width)
    {
        Pen pen;

        if (catalog.TryGetValue(medium, out var materials) && materials.TryGetValue(materialKey, out var material))
        {
            pen = penises[material];
        }
        else if (medium == Medium.Himmel)
        {
            pen = skyPen!;
        }
        else
        {
            pen = penises[materials![materialKey]];
        }

        pen.Width = width;

        return pen;
    }

    public SolidBrush BuersteVonMedium(Medium medium, string materialKey)
    {
        if (catalog.TryGetValue(medium, out var materials) && materials.TryGetValue(materialKey, out var material))
        {
            return bushes[material];
        }

        if (medium == Medium.Himmel)
        {
            return skyBrush!;
        }

        return bushes[materials![materialKey]];
    }

    public Color FarbeVonMedium(Medium vonMedium, string materialKey)
    {
        return BuersteVonMedium(vonMedium, materialKey).Color;
    }

    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                FreeGdiRessources();
            }

            disposedValue = true;
        }
    }

    private void FreeGdiRessources()
    {
        skyPen?.Dispose();
        skyBrush?.Dispose();

        foreach (var pen in penises)
        {
            pen.Dispose();
        }

        foreach (var bush in bushes)
        {
            bush.Dispose();
        }

        catalog.Clear();
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
