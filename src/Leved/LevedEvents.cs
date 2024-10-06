using ScorchGore.Classes;

namespace ScorchGore.Leved;

static class LevedEvents
{
    public static object LevedPropertyChangedEventRoot = new();

    public delegate void LevedPropertyChangedEventHandler(object sender, LevedPropertyChangedEventArgs e);

    public class LevedPropertyChangedEventArgs(LevelBeschreibung level) : EventArgs
    {
        public LevelBeschreibung Level => level;
    }

    internal static event LevedPropertyChangedEventHandler? LevedPropertyChanged;

    internal static void OnLevedPropertyChanged(LevedPropertyChangedEventArgs e)
    {
        LevedPropertyChanged?.Invoke(LevedPropertyChangedEventRoot, e);
    }
}
