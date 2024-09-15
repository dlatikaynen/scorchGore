using ScorchGore.ApiClient;

namespace ScorchGore.Forms;

public partial class frmApiMessages : Form
{
    public frmApiMessages()
    {
        InitializeComponent();
        txtOutput.Clear();
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
}
