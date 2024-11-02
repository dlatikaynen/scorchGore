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

        dtp = dp.Properties[nameof(LevelBeschreibung.ColorBackground)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(108)); // Background color
        dtp?.SetDescription(Xlat.µ(109)); // Color of the monochrome backdrop. It will be applied in case no backdrop picture asset has been selected
        dtp?.SetCategory(categoryColors);

        dtp = dp.Properties[nameof(LevelBeschreibung.MaterialThemeKey)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(106)); // Material Theme
        dtp?.SetDescription(Xlat.µ(107)); // One of the backdrops defined in the asset manager. Should be 640 x 480 at least. Excess will scroll slower than arena content
        dtp?.SetCategory(categoryColors);

        dtp = dp.Properties[nameof(LevelBeschreibung.BackdropAssetKey)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(95)); // Backdrop
        dtp?.SetDescription(Xlat.µ(96)); // One of the backdrops defined in the asset manager. Should be 640 x 480 at least. Excess will scroll slower than arena content
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelBeschreibung.Zufallszahl)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(41)); // MountainRandomSeed
        dtp?.SetDescription(Xlat.µ(23)); // Randomizer seed for procedural terrain generators
        dtp?.SetCategory(categoryBasics);

        dtp = dp.Properties[nameof(LevelBeschreibung.BeschreibungsSkript)] as RuntimePropertyDescriptor.DynamicProperty;
        dtp?.SetDisplayName(Xlat.µ(119)); // Scene script
        dtp?.SetDescription(Xlat.µ(120)); // Program to control the composition of the level
        dtp?.SetCategory(categoryBasics);

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
