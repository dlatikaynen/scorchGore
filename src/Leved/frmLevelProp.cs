using ScorchGore.Classes;
using Xlat = ScorchGore.Translation.Translation;
namespace ScorchGore.Leved;

public partial class frmLevelProp : Form
{
    public frmLevelProp()
    {
        InitializeComponent();
    }

    internal void Prepare(LevelProperties properties)
    {
        // here, each property gets its current value
        var dt = new RuntimePropertyDescriptor(typeof(LevelProperties));
        var dp = dt.FromComponent(properties);

        // prepare property category translations
        var categoryNaming = Xlat.µ(15); // Naming
        var categoryBasics = Xlat.µ(20); // Basics
        var categoryColors = Xlat.µ(32); // Colors

        // here, each property gets its proper descriptions
        var dtp = dp.Properties[nameof(LevelProperties.NameDe)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(0));
        dtp?.SetDescription(Xlat.µ(17)); // The German translation of the level's name
        dtp?.SetCategory(categoryNaming);

        dtp = dp.Properties[nameof(LevelProperties.NameEn)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(0));
        dtp?.SetDescription(Xlat.µ(16)); // The English translation of the level's name
        dtp?.SetCategory(categoryNaming);

        dtp = dp.Properties[nameof(LevelProperties.NameFi)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(0));
        dtp?.SetDescription(Xlat.µ(18)); // The Finnish translation of the level's name
        dtp?.SetCategory(categoryNaming);

        dtp = dp.Properties[nameof(LevelProperties.NameUa)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(0));
        dtp?.SetDescription(Xlat.µ(19)); // The Ukrainian translation of the level's name
        dtp?.SetCategory(categoryNaming);

        dtp = dp.Properties[nameof(LevelProperties.Width)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(0));
        dtp?.SetDescription(Xlat.µ(21)); // The width of the level canvas' rectangular bounding box
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelProperties.Height)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(0));
        dtp?.SetDescription(Xlat.µ(22)); // The height of the level canvas' rectangular bounding box
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelProperties.BergZufallszahl)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(0));
        dtp?.SetDescription(Xlat.µ(23)); // Randomizer seed for procedural terrain generators
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelProperties.IsMountain)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(0));
        dtp?.SetDescription(Xlat.µ(24)); // Activate to generate a mountain range
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelProperties.BergMinHoeheProzent)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(0));
        dtp?.SetDescription(Xlat.µ(25)); // Minimum mountain range height in percent of available height
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelProperties.BergMaxHoeheProzent)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(0));
        dtp?.SetDescription(Xlat.µ(26));
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelProperties.BergRauhheitProzent)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(0));
        dtp?.SetDescription(Xlat.µ(27));
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelProperties.IsCave)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(0));
        dtp?.SetDescription(Xlat.µ(28));
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelProperties.HoehleMinHoeheProzent)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(0));
        dtp?.SetDescription(Xlat.µ(29));
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelProperties.HoehleMaxHoeheProzent)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(0));
        dtp?.SetDescription(Xlat.µ(30));
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelProperties.HoehleRauhheitProzent)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(0));
        dtp?.SetDescription(Xlat.µ(31));
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelProperties.ColorMountain)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(0));
        dtp?.SetDescription(Xlat.µ(33)); // Define the color of the mountain range
        dtp?.SetCategory(categoryColors);

        dtp = dp.Properties[nameof(LevelProperties.ColorCave)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(0));
        dtp?.SetDescription(Xlat.µ(34)); // Define the color of the cave roof
        dtp?.SetCategory(categoryColors);

        // now tell that the property grid
        ppgTable.SelectedObject = dp;
        ppgTable.Refresh();
    }
}
