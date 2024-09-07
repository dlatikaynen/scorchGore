using ScorchGore.Configuration;
using System.ComponentModel;

namespace ScorchGore.Forms;

public partial class frmEditPlayerProfile : Form
{
    public frmEditPlayerProfile()
    {
        InitializeComponent();

        txtName.Text = InstanceSettings.PlayerName;
    }

    public string PlayerName => txtName.Text.Trim();

    public string PlayerNameNormalized => txtName.Text.Trim().ToUpperInvariant();

    private void txtName_Validating(object sender, CancelEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            Validator.SetError(txtName, "Enter a name");
            e.Cancel = true;
        }
        else if (PlayerName.Any(c => !char.IsAscii(c)))
        {
            Validator.SetError(txtName, "No fancy characters, private. What are you, greek?");
            e.Cancel = true;
        }
#if !DEBUG
        else if (PlayerNameNormalized == "DLATIKAY")
        {
            Validator.SetError(txtName, "This name is reserved for the author of the game");
        }
        else if (PlayerNameNormalized == "LLATIKAY" || PlayerNameNormalized == "LUKAS" || PlayerNameNormalized == "LUKAS SASCHA")
        {
            Validator.SetError(txtName, "This name is reserved for one of the contributors to the game");
        }
        else if (PlayerNameNormalized == "JLATIKAY" || PlayerNameNormalized == "JONAS" || PlayerNameNormalized == "JONAS MIKA")
        {
            Validator.SetError(txtName, "This name is reserved for one of the contributors of the game");
        }
#endif
        else
        {
            Validator.SetError(txtName, null);
        }
    }

    private void cmdOk_Click(object sender, EventArgs e)
    {
        if (ValidateChildren())
        {
            InstanceSettings.PlayerName = PlayerName;
            InstanceConfiguration.Write();
            DialogResult = DialogResult.OK;
            Close();
        }
        else
        {
            DialogResult = DialogResult.None;
        }
    }
}
