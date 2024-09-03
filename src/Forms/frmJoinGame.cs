namespace ScorchGore.Forms;

public partial class frmJoinGame : Form
{
    public frmJoinGame()
    {
        InitializeComponent();
    }

    private void btnPaste_Click(object sender, EventArgs e)
    {
        var text = Clipboard.GetText();
        if (Guid.TryParseExact(text, "N", out _))
        {
            txtToken.Text = text;
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        if (txtToken.ReadOnly)
        {
            txtToken.Clear();
            txtToken.ReadOnly = false;
            txtToken.Focus();
            btnPaste.Enabled = true;
        }
        else
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

    private void txtToken_TextChanged(object sender, EventArgs e)
    {
        if (Guid.TryParseExact(txtToken.Text, "N", out var token))
        {
            txtToken.ReadOnly = true;
            btnPaste.Enabled = false;
            pgbWaitJoin.Enabled = true;

            // initiate
            DialogResult = DialogResult.OK;
            Close();

        }
    }
}
