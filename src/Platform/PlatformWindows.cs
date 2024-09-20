using System.Runtime.InteropServices;

namespace ScorchGore.Platform;

internal static partial class PlatformWindows
{
    internal const int WM_SYSCOMMAND = 0x112;
    internal const int MF_STRING = 0x0;
    internal const int MF_SEPARATOR = 0x800;

    [LibraryImport("user32.dll", EntryPoint = "GetSystemMenu", SetLastError = true)]
    internal static partial IntPtr GetSystemMenu(IntPtr hWnd, [MarshalAs(UnmanagedType.Bool)] bool bRevert);

    [LibraryImport("user32.dll", EntryPoint = "AppendMenuW", SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool AppendMenu(IntPtr hMenu, int uFlags, int uIDNewItem, string lpNewItem);

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
}
