using ScorchGore.Classes;
using ScorchGore.Extensions;
using Xlat = ScorchGore.Translation.Translation;

namespace ScorchGore.Leved;

public partial class frmConfirmDeleteUsedAsset : Form
{
    public frmConfirmDeleteUsedAsset()
    {
        InitializeComponent();
    }

    internal void Prepare(string[] usages, AssetClass assetClass, string assetKey)
    {
        Text = Xlat.µ(124); // Delete used asset
        cmdOk.Text = Xlat.µ(125); // Yes
        btnCancel.Text = Xlat.µ(126); // Cancel
        lblUsages.Text = Xlat.µ(122, assetClass.GetTranslatedName(), assetKey); // The {0} asset "{1}" is used:
        lblPrompt.Text = Xlat.µ(123); // Proceed to delete anyway?
        lstUsages.Items.Clear();
        lstUsages.Items.AddRange(usages);
    }
}
