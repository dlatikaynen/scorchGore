using ScorchGore.GameSession;

namespace ScorchGore.Forms;

public partial class frmInitiateGame : Form
{
    private bool isFirstActivation = true;
    internal readonly GoreSession NewGame = new();

    public frmInitiateGame()
    {
        InitializeComponent();

        lblToken.Text = string.Empty;
        pgbWaitJoin.Style = ProgressBarStyle.Continuous;
    }

    private void frmInitiateGame_Activated(object sender, EventArgs e)
    {
        if (!isFirstActivation)
        {
            return;
        }

        isFirstActivation = false;
        pgbWaitJoin.Style = ProgressBarStyle.Marquee;
        ThreadPool.QueueUserWorkItem((_) =>
        {
            if(NewGame.Initiate())
            {
                Invoke(() =>
                {
                    pgbWaitJoin.Style = ProgressBarStyle.Continuous;
                    lblToken.Text = NewGame.GameToken.ToString("N").ToUpperInvariant();
                    btnCopy.Enabled = true;
                });
            }
        });
    }

    private void btnCopy_Click(object sender, EventArgs e)
    {
        Clipboard.SetText(lblToken.Text);
    }
}
