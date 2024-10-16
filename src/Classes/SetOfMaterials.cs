using ScorchGore.Constants;
using ScorchGore.Extensions;

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
}