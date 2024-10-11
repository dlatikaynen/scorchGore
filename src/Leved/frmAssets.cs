using Xlat = ScorchGore.Translation.Translation;

namespace ScorchGore.Leved;

public partial class frmAssets : Form
{
    public frmAssets()
    {
        InitializeComponent();
    }

    private void frmAssets_Load(object sender, EventArgs e)
    {
        tvAssets.Nodes.Clear();
        DesignWorkspace.EnsureDesignWorkspace();

        var builtInAssets = tvAssets.Nodes.Add(
            "1",
            Xlat.µ(81), // Built-in assets
            null
        );

        builtInAssets.Nodes.Add(
            "1.csg",
            Xlat.µ(85), // CSG
            null
        );

        builtInAssets.Nodes.Add(
            "1.prefab",
            Xlat.µ(84), // Prefabs
            null
        );

        builtInAssets.Nodes.Add(
            "1.sfx",
            Xlat.µ(83), // Sfx
            null
        );

        var customAssets = tvAssets.Nodes.Add(
            "69",
            Xlat.µ(82), // My assets
            null
        );
    }
}
