using ScorchGore.Constants;
using ScorchGore.Extensions;
using ScorchGore.Platform;
using ScorchGore.Sequencer;

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
                            cancelAcknowledged = true;
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

    private bool cancelReentrant = false;
    private void btnCancel_Click(object sender, EventArgs e)
    {
        if (cancelReentrant)
        {
            return;
        }

        cancelReentrant = true;
        try
        {
            if (cancelAcknowledged)
            {
                if (e is FormClosingEventArgs efca)
                {
                    efca.Cancel = false;
                }

                Close();

                return;
            }

            cancelRequested = true;
            while (!cancelAcknowledged)
            {
                PlatformWindows.SoftWait();
            }

            pgbWaitJoin.Style = ProgressBarStyle.Continuous;
            cancelRequested = false;
            if (txtToken.ReadOnly)
            {
                txtToken.Clear();
                txtToken.ReadOnly = false;
                txtToken.Focus();
                btnPaste.Enabled = true;

                if (e is FormClosingEventArgs efca2)
                {
                    efca2.Cancel = false;
                }
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
        finally
        {
            cancelReentrant = false;
        }
    }

    private void frmJoinGame_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!cancelRequested && !cancelReentrant)
        {
            e.Cancel = true;
            btnCancel_Click(sender, e);
        }
    }
}
