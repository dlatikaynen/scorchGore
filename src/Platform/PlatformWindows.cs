using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace ScorchGore.Platform;

internal static partial class PlatformWindows
{
    internal const int WM_SYSCOMMAND = 0x112;
    internal const int MF_STRING = 0x0;
    internal const int MF_SEPARATOR = 0x800;

    private const int SC_SCREENSAVE = 0xF140;

    [LibraryImport("user32.dll", EntryPoint = "GetSystemMenu", SetLastError = true)]
    internal static partial IntPtr GetSystemMenu(IntPtr hWnd, [MarshalAs(UnmanagedType.Bool)] bool bRevert);

    [LibraryImport("user32.dll", EntryPoint = "AppendMenuW", SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool AppendMenu(IntPtr hMenu, int uFlags, int uIDNewItem, string lpNewItem);

    [LibraryImport("user32.dll", EntryPoint = "GetDesktopWindow", SetLastError = true)]
    private static partial IntPtr GetDesktopWindow();

    [LibraryImport("user32.dll", EntryPoint = "SendMessageW", SetLastError = true)]
    private static partial IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// This is a way of colorfully shooting ourselves,
    /// the user, and the operating system in the foot
    /// with four different guns
    /// </summary>
    internal static void SoftWait()
    {
        for (var i = 1; i < 10; ++i)
        {
            Thread.SpinWait(10);
            Thread.Sleep(30);
            Thread.Yield();
            Application.DoEvents();
        }
    }

    internal static void RunScr()
    {
        var desktop = GetDesktopWindow();
        nint error = Marshal.GetLastWin32Error();

        if (error != 0)
        {
            return;
        }

        _ = SendMessage(
            desktop,
            WM_SYSCOMMAND,
            wParam: SC_SCREENSAVE,
            lParam: 0
        );
    }

    internal static void OpenUrlInBrowser(string slug)
    {
        var ruri = slug.Replace("-", "").Trim('{', '}');
        var buri = Convert.FromBase64String($"{ruri}=");
        var suri = Encoding.ASCII.GetString(buri);

        Process.Start(new ProcessStartInfo(suri)
        {
            UseShellExecute = true
        });
    }
}
