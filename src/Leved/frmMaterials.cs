using ScorchGore.Constants;
using ScorchGore.Forms;
using Xlat = ScorchGore.Translation.Translation;

namespace ScorchGore.Leved;

public partial class frmMaterials : Form
{
    public frmMaterials()
    {
        InitializeComponent();
    }

    private void frmMaterials_Load(object sender, EventArgs e)
    {
        tvSets.Nodes.Clear();

        var builtInSets = tvSets.Nodes.Add(
            "1",
            Xlat.µ(68), // Built-in sets of materials
            null
        );

        var firstSet = builtInSets.Nodes.Add(
            "1.WOTMSTD",
            "WOTMSTD", // TODO: xlat/dynamically load
            "mat",
            "mat"
        );

        builtInSets.ExpandAll();
        tvSets.SelectedNode = firstSet;
        firstSet.EnsureVisible();

        var customSets = tvSets.Nodes.Add(
            "69",
            Xlat.µ(70), // My material sets
            null
        );

        _ = customSets.Nodes.Add(
            "69.*",
            Xlat.µ(71), // My set of materials
            "mat",
            "mat"
        );
    }

    private void tvSets_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        var matSetId = MaterialSetIdentifierFromNode(e.Node);

        if (matSetId != null)
        {
            using var matSetEditor = new frmMaterialPalette();

            matSetEditor.Prepare(
            [
                new(Medium.Cave,
                [
                    new("EGA0", Color.FromArgb(0,0,0))
                ])
            ]);

            matSetEditor.ShowDialog(this);
        }
    }

    private static string? MaterialSetIdentifierFromNode(TreeNode node)
    {
        var parts = node.Name.Split('.', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 2 && parts[1].Length > 0)
        {
            return parts[1];
        }

        return null;
    }
}
