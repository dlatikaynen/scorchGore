using ScorchGore.Configuration;

namespace Fso.ScorchGore;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        // see https://aka.ms/applicationconfiguration
        ApplicationConfiguration.Initialize();
        
        using var mainWindow = new MainWindow();
       
        InstanceConfiguration.Read();
        if (mainWindow.Prepare())
        {
            Application.Run(mainWindow);
        }
    }
}