using ScorchGore.Constants;
using ScorchGore.GameSession;

namespace ScorchGore.Forms;

public partial class frmInitiateGame : Form
{
    private bool cancelRequested = false;
    private bool cancelAcknowledged = true;
    internal readonly GoreSession NewGame = new();

    public frmInitiateGame()
    {
        InitializeComponent();

        lblToken.Text = string.Empty;
        pgbWaitJoin.Style = ProgressBarStyle.Continuous;
    }

    private void optScissors_CheckedChanged(object sender, EventArgs e) => InitiateNow();
    private void optStone_CheckedChanged(object sender, EventArgs e) => InitiateNow();
    private void optPaper_CheckedChanged(object sender, EventArgs e) => InitiateNow();
    private void optWell_CheckedChanged(object sender, EventArgs e) => InitiateNow();

    private void InitiateNow()
    {
        var mySsp = SSP.None;

        if (optPaper.Checked)
        {
            mySsp = SSP.Paper;
        }
        else if (optScissors.Checked)
        {
            mySsp = SSP.Scissors;
        }
        else if (optStone.Checked)
        {
            mySsp = SSP.Stone;
        }
        else if (optWell.Checked)
        {
            mySsp = SSP.Well;
        }

        optPaper.Enabled = false;
        optScissors.Enabled = false;
        optStone.Enabled = false;
        optWell.Enabled = false;
        pgbWaitJoin.Style = ProgressBarStyle.Marquee;
        ThreadPool.QueueUserWorkItem((_) =>
        {
            cancelAcknowledged = false;
            if (NewGame.Initiate())
            {
                Invoke(() =>
                {
                    lblToken.Text = NewGame.GameToken.ToString("N").ToUpperInvariant();
                    btnCopy.Enabled = true;
                });

                // now we wait until they join, or we're canceled
                do
                {
                    Thread.Sleep(333);
                    if(NewGame.HasPeerJoined(mySsp))
                    {
                        Invoke(() =>
                        {
                            DialogResult = DialogResult.OK;
                            Close();
                        });

                        return;
                    }
                } while (!cancelRequested);
            }

            cancelAcknowledged = true;
        });
    }

    private void btnCopy_Click(object sender, EventArgs e)
    {
        Clipboard.SetText(lblToken.Text);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        cancelRequested = true;
        btnCancel.Enabled = false;
        pgbWaitJoin.Style = ProgressBarStyle.Continuous;
        do
        {
            Thread.SpinWait(10);
        } while (!cancelAcknowledged);
    }
}
