namespace ScorchGore.Forms;

public partial class frmInitiateGame : Form
{
    public frmInitiateGame()
    {
        InitializeComponent();

        lblToken.Text = Guid.NewGuid().ToString("N").ToUpperInvariant();
    }

    private void btnCopy_Click(object sender, EventArgs e)
    {
        Clipboard.SetText(lblToken.Text);
    }
}
