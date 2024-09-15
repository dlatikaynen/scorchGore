using ScorchGore.ApiClient;

namespace ScorchGore.Forms;

public partial class frmOutputPane : Form
{
    public frmOutputPane()
    {
        InitializeComponent();
        txtOutput.Clear();
        GoreApiClient.RestCommunication += (sender, e) =>
        {
            Invoke(() =>
            {
                txtOutput.AppendText($@"{DateTime.Now:HH:mm:ss.fff} {e.Method} {e.Controller} {e.Status} ""{e.Response}""{Environment.NewLine}");
            });
        };
    }
}
