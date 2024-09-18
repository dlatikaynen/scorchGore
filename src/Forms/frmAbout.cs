namespace ScorchGore.Forms;

public partial class frmAbout : Form
{
    public frmAbout()
    {
        InitializeComponent();
    }

    private void frmAbout_Load(object sender, EventArgs e)
    {
        pnlAbout.Top = 0;
    }

    private void frmAbout_KeyDown(object sender, KeyEventArgs e)
    {
        if(e.KeyCode==Keys.Escape)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;
            Close();
        }
    }
}
