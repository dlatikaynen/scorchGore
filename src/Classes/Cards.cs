using System.Runtime.InteropServices;

namespace ScorchGore.Classes;

internal partial class Cards
{
    [LibraryImport("cards.dll", EntryPoint = "cdtInit")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool CdtInit(ref int width, ref int height);
}
