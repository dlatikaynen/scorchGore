using ScorchGore.Classes;

namespace ScorchGore.Leved;

public partial class frmPickMediumMaterialsPalette : Form
{
    public frmPickMediumMaterialsPalette()
    {
        InitializeComponent();
    }

    internal void Prepare(SetOfMaterials? self)
    {
        // list all materials.
        // if used as a picker to copy from
        // one palette into the currently edited
        // one, suppress "self" as a choice
        tvSets.Nodes.Clear();
    }
}
