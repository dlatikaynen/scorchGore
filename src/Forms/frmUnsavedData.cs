using Xlat = ScorchGore.Translation.Translation;

namespace ScorchGore.Forms;

public partial class frmUnsavedData : Form
{
    public frmUnsavedData()
    {
        InitializeComponent();
        DialogResult = DialogResult.Cancel;
        Text = Xlat.µ(112); // Unsaved Data
        lblHint.Text = Xlat.µ(113); // There is ephemeral stuff, little islands of order in a vast sea of entropy, only tethered to reality by infinitesimally small bits of charge in leaky capacitors. Shall we move those to a place where they are a little safer?
        cmdYes.Text = Xlat.µ(114); // SAVE IT NOW
        cmdNo.Text = Xlat.µ(115); // Lost, it will be
        cmdCancel.Text = Xlat.µ(116); // Hold your horses
    }

    private void cmdNo_MouseEnter(object sender, EventArgs e)
    {
        if (cmdNo.Left > Width / 2)
        {
            cmdNo.Left = cmdYes.Left;
        }
        else
        {
            cmdNo.Left = ClientRectangle.Width - cmdNo.Width - cmdYes.Left;
        }
    }
}
