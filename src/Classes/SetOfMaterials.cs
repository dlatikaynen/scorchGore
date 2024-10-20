using ScorchGore.Constants;
using ScorchGore.Extensions;
using ScorchGore.Forms;
using ScorchGore.Leved;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace ScorchGore.Classes;

internal class Material(string name, Color color)
{
    public string Name => name;
    public Color Color => color;
}

internal class SetOfMaterials(Medium medium, List<Material> materials)
{
    public Medium Medium => medium;
    public List<Material> Materials => materials;

    public override string ToString()
    {
        return MediumExtensions.GetTranslatedName(Medium);
    }
}

internal class MaterialTheme(string name, List<SetOfMaterials> setsOfMaterials)
{
    public bool IsBuiltin { get; set; } = false;
    public string Name => name;
    public List<SetOfMaterials> SetsOfMaterials => setsOfMaterials;

    public override string ToString() => Name;

    internal static bool TryAllocateColor(string themeKey, Medium medium, Color color, [NotNullWhen(true)] out string? materialKey)
    {
        var theme = DesignWorkspace.MaterialThemes.SingleOrDefault(mt => mt.Name == themeKey);

        materialKey = null;
        if (theme == null)
        {
            return false;
        }

        var set = theme.SetsOfMaterials.SingleOrDefault(som => som.Medium == medium);

        if (set == null)
        {
            set = new SetOfMaterials(medium, []);

            theme.SetsOfMaterials.Add(set);
            DesignWorkspace.SetDirty();
        }

        var existingEntry = set.Materials.SingleOrDefault(m => m.Color.ToArgb() == color.ToArgb());

        if (existingEntry == null)
        {
            if (set.Materials.Count == 0xff)
            {
                // palette full
                return false;
            }

            int ordinal = 1;
            var candidateKey = string.Empty;

            do
            {
                candidateKey = $"{medium.ToString().ToUpperInvariant()}{ordinal}";

                ++ordinal;
            } while (set.Materials.Any(m => m.Name == candidateKey));

            materialKey = candidateKey;
            set.Materials.Add(new(materialKey, color));
            DesignWorkspace.SetDirty();
        }
        else
        {
            // TODO: colors must remain unique inside the entire theme!
            materialKey = existingEntry.Name;
        }

        return true;
    }
}