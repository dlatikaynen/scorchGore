using ScorchGore.Classes;

namespace ScorchGore.Forms;

public partial class frmAssetPlacement : Form
{
    internal LevelBeschreibung EditedLevel = new();

    public frmAssetPlacement()
    {
        InitializeComponent();
    }

    internal void Prepare(LevelBeschreibung level)
    {
        EditedLevel = level;
        tvPlacement.Nodes.Clear();

        var lvl = tvPlacement.Nodes.Add("lvl", EditedLevel.LevelName, imageKey: "level", selectedImageKey: "level");

        var placementIndex = 0;
        TreeNode? lastPlacement = null;

        foreach(var placement in level.AssetPlacement)
        {
            lastPlacement = lvl.Nodes.Add($"lvl.{placementIndex}", placement.AssetKey, imageKey: "asset", selectedImageKey: "asset");
        }

        if (lastPlacement != null)
        {
            tvPlacement.SelectedNode = lastPlacement;
            lastPlacement.EnsureVisible();
        }
    }

    private void frmAssetPlacement_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            Hide();
            e.Cancel = true;
        }
    }
}