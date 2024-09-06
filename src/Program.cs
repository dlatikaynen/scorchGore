using ScorchGore.Configuration;

namespace Fso.ScorchGore;

internal static class Program
{
    public static int WhichInstanceAmI = 0;

    [STAThread]
    static void Main()
    {
        // see https://aka.ms/applicationconfiguration
        ApplicationConfiguration.Initialize();
        Semaphore mySemaphore = new(int.MaxValue, int.MaxValue, @"Global\Fso.ScorchGore.Executable");
        mySemaphore.WaitOne();
        WhichInstanceAmI = int.MaxValue - mySemaphore.Release();
        mySemaphore.WaitOne();
        
        using var mainWindow = new MainWindow();
       
        InstanceConfiguration.Read();
        if (mainWindow.Prepare())
        {
            Application.Run(mainWindow);
        }

        mySemaphore.Release();
    }
}