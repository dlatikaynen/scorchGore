using ScorchGore.Classes;
using Xlat = ScorchGore.Translation.Translation;

namespace ScorchGore.Leved;

public partial class frmLevelProp : Form
{
    internal LevelBeschreibung EditedLevel = new();

    public frmLevelProp()
    {
        InitializeComponent();
        ppgTable.PropertyValueChanged += InvokeOnChangedEvent;
    }

    internal void Prepare(LevelBeschreibung properties)
    {
        EditedLevel = properties;
        ppgTable.SelectedObjects = [];

        // here, each property gets its current value
        var dt = new RuntimePropertyDescriptor(typeof(LevelBeschreibung));
        var dp = dt.FromComponent(properties);

        // prepare property category translations
        var categoryNaming = Xlat.µ(15); // Naming
        var categoryBasics = Xlat.µ(20); // Basics
        var categoryColors = Xlat.µ(32); // Colors

        // here, each property gets its proper descriptions
        var dtp = dp.Properties[nameof(LevelBeschreibung.NameDe)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(36)); // Name (German)
        dtp?.SetDescription(Xlat.µ(17)); // The German translation of the level's name
        dtp?.SetCategory(categoryNaming);

        dtp = dp.Properties[nameof(LevelBeschreibung.NameEn)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(35)); // Name (English)
        dtp?.SetDescription(Xlat.µ(16)); // The English translation of the level's name
        dtp?.SetCategory(categoryNaming);

        dtp = dp.Properties[nameof(LevelBeschreibung.NameFi)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(37)); // Name (Finnish)
        dtp?.SetDescription(Xlat.µ(18)); // The Finnish translation of the level's name
        dtp?.SetCategory(categoryNaming);

        dtp = dp.Properties[nameof(LevelBeschreibung.NameUa)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(38)); // Name (Ukrainian)
        dtp?.SetDescription(Xlat.µ(19)); // The Ukrainian translation of the level's name
        dtp?.SetCategory(categoryNaming);

        dtp = dp.Properties[nameof(LevelBeschreibung.Width)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(39)); // Width
        dtp?.SetDescription(Xlat.µ(21)); // The width of the level canvas' rectangular bounding box
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelBeschreibung.Height)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(40)); // Height
        dtp?.SetDescription(Xlat.µ(22)); // The height of the level canvas' rectangular bounding box
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelBeschreibung.BackdropAssetKey)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(95)); // Backdrop
        dtp?.SetDescription(Xlat.µ(96)); // One of the backdrops defined in the asset manager. Should be 640 x 480 at least. Excess will scroll slower than arena content
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelBeschreibung.BergZufallszahl)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(41)); // MountainRandomSeed
        dtp?.SetDescription(Xlat.µ(23)); // Randomizer seed for procedural terrain generators
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelBeschreibung.IsMountain)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(42)); // Mountain ridge
        dtp?.SetDescription(Xlat.µ(24)); // Activate to generate a mountain range
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelBeschreibung.BergMinHoeheProzent)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(43)); // Mountain min height %
        dtp?.SetDescription(Xlat.µ(25)); // Minimum mountain range height in percent of available height
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelBeschreibung.BergMaxHoeheProzent)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(44)); // Mountain max height %
        dtp?.SetDescription(Xlat.µ(26)); // Maximum mountain range height in percent of available height
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelBeschreibung.BergRauhheitProzent)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(45)); // Mountain ruggedness %
        dtp?.SetDescription(Xlat.µ(27)); // Mountain range ruggedness factor as a percentage of something I don't remember
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelBeschreibung.IsCave)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(46)); // Cave ceiling
        dtp?.SetDescription(Xlat.µ(28)); // Activate to generate a cave roof
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelBeschreibung.HoehleMinHoeheProzent)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(47)); // Cave min height %
        dtp?.SetDescription(Xlat.µ(29)); // Cave roof minimum height measured from the top, in percent of available height
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelBeschreibung.HoehleMaxHoeheProzent)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(48)); // Cave max height %
        dtp?.SetDescription(Xlat.µ(30)); // Cave roof maximum height measured from the top, in percent of available height
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelBeschreibung.HoehleRauhheitProzent)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(49)); // Cave ruggedness %
        dtp?.SetDescription(Xlat.µ(31)); // Cave roof ruggedness factor as a percentage of something I don't remember
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelBeschreibung.ColorMountain)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(50)); // Mountain color
        dtp?.SetDescription(Xlat.µ(33)); // Define the color of the mountain range
        dtp?.SetCategory(categoryColors);

        dtp = dp.Properties[nameof(LevelBeschreibung.ColorCave)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(51)); // Cave ceiling color
        dtp?.SetDescription(Xlat.µ(34)); // Define the color of the cave roof
        dtp?.SetCategory(categoryColors);

        // now tell that the property grid
        ppgTable.SelectedObjects = [dp];
        ppgTable.Refresh();
    }

    private void InvokeOnChangedEvent(object? _s, PropertyValueChangedEventArgs _e)
    {
        LevedEvents.OnLevedPropertyChanged(new(EditedLevel));
    }

    private void frmLevelProp_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            Hide();
            e.Cancel = true;
        }
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        ppgTable.PropertyValueChanged -= InvokeOnChangedEvent;
    }
}
