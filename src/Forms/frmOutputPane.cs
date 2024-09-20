using ScorchGore.ApiClient;
using ScorchGore.Platform;

namespace ScorchGore.Forms;

public partial class frmOutputPane : Form
{
    private const int SYSMENU_CLEAR_ID = 0x1;

    public frmOutputPane()
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

        GoreApiClient.RestCommunication += (sender, e) =>
        {
            Invoke(() =>
            {
                txtOutput.AppendText($@"{DateTime.Now:HH:mm:ss.fff} {e.Method} {e.Controller} {e.Status} ""{e.Response}""{Environment.NewLine}");
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

    private void frmOutputPane_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Modifiers.HasFlag(Keys.Control) && e.KeyCode == Keys.Delete)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;
            txtOutput.Clear();
        }
    }
}
