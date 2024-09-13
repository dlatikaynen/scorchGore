using ScorchGore.Constants;
using ScorchGore.Extensions;
using ScorchGore.GameSession;

namespace ScorchGore.Forms;

public partial class frmJoinGame : Form
{
    public GoreSession JoinedSession = new();

    private bool cancelRequested = false;
    private bool cancelAcknowledged = true;

    public frmJoinGame()
    {
        InitializeComponent();
    }

    private void btnPaste_Click(object sender, EventArgs e)
    {
        var text = Clipboard.GetText();
        if (GuidExtensions.TryParseGore(text, out _))
        {
            txtToken.Text = text;
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        cancelRequested = true;
        while(!cancelAcknowledged)
        {
            Thread.Sleep(333);
        }

        pgbWaitJoin.Style = ProgressBarStyle.Continuous;
        cancelRequested = false;
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
        if (GuidExtensions.TryParseGore(txtToken.Text, out var token))
        {
            txtToken.ReadOnly = true;
            btnPaste.Enabled = false;
            pgbWaitJoin.Enabled = true;
            pgbWaitJoin.Style = ProgressBarStyle.Marquee;
            cancelAcknowledged = false;

            var mySsp = SSP.None;

            if (optScissors.Checked)
            {
                mySsp = SSP.Scissors;
            }
            else if (optStone.Checked)
            {
                mySsp = SSP.Stone;
            }
            else if (optPaper.Checked)
            {
                mySsp = SSP.Paper;
            }
            else if (optWell.Checked)
            {
                mySsp = SSP.Well;
            }

            ThreadPool.QueueUserWorkItem((_) =>
            {
                do
                {
                    if (JoinedSession.Join(token, mySsp))
                    {
                        Invoke(() =>
                        {
                            DialogResult = DialogResult.OK;
                            Close();
                        });

                        break;
                    }

                    Thread.Sleep(333);
                } while (!cancelRequested);

                cancelAcknowledged = true;
            });
        }
    }
}
