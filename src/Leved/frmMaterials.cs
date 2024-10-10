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
        DesignWorkspace.EnsureDesignWorkspace();

        var builtInSets = tvSets.Nodes.Add(
            "1",
            Xlat.µ(68), // Built-in sets of materials
            null
        );

        TreeNode? firstSet = null;

        foreach (var theme in DesignWorkspace.MaterialThemes)
        {
            firstSet = builtInSets.Nodes.Add(
                $"1.{theme.Name}",
                theme.Name,
                "mat",
                "mat"
            );
        }

        builtInSets.ExpandAll();
        if (firstSet != null)
        {
            tvSets.SelectedNode = firstSet;
            firstSet.EnsureVisible();
        }

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
        var themeId = MaterialThemeIdentifierFromNode(e.Node);

        if (themeId != null)
        {
            using var matSetEditor = new frmMaterialPalette();
            var theme = DesignWorkspace.MaterialThemes.Where(t => t.Name == themeId).SingleOrDefault();

            if (theme != null)
            {
                matSetEditor.Prepare(theme);
                matSetEditor.ShowDialog(this);
            }
        }
    }

    private static string? MaterialThemeIdentifierFromNode(TreeNode node)
    {
        var parts = node.Name.Split('.', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 2 && parts[1].Length > 0)
        {
            return parts[1];
        }

        return null;
    }
}
