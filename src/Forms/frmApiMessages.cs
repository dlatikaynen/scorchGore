using ScorchGore.ApiClient;
using ScorchGore.Platform;

namespace ScorchGore.Forms;

public partial class frmApiMessages : Form
{
    private const int SYSMENU_CLEAR_ID = 0x1;

    public frmApiMessages()
    {
        InitializeComponent();
        txtOutput.Clear();
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        IntPtr hSysMenu = PlatformWindows.GetSystemMenu(Handle, false);
        PlatformWindows.AppendMenu(hSysMenu, PlatformWindows.MF_SEPARATOR, 0, string.Empty);
        PlatformWindows.AppendMenu(
            hSysMenu,
            PlatformWindows.MF_STRING,
            SYSMENU_CLEAR_ID,
            "Clea&r\tCtrl+Del"
        );

        GoreApiClient.ApiMessages += (sender, e) =>
        {
            Invoke(() =>
            {
                txtOutput.AppendText($@"{DateTime.Now:HH:mm:ss.fff} {e.Method} {e.Player} {e.Turn} ({e.Token}):{Environment.NewLine}");

                foreach (var line in e.Payload)
                {
                    txtOutput.AppendText($"  {line}{Environment.NewLine}");
                }
            });
        };
    }

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if ((m.Msg == PlatformWindows.WM_SYSCOMMAND) && ((int)m.WParam == SYSMENU_CLEAR_ID))
        {
            txtOutput.Clear();
        }
    }

    private void frmApiMessages_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Modifiers.HasFlag(Keys.Control) && e.KeyCode == Keys.Delete)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;
            txtOutput.Clear();
        }
    }

    private void frmApiMessages_FormClosing(object sender, FormClosingEventArgs e)
    {
        switch (e.CloseReason)
        {
            case CloseReason.TaskManagerClosing:
            case CloseReason.FormOwnerClosing:
            case CloseReason.MdiFormClosing:
            case CloseReason.ApplicationExitCall:
                return;
        }

        e.Cancel = true;
        Hide();
    }
}
