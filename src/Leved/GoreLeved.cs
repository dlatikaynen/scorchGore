using ScorchGore.Arena;
using ScorchGore.Classes;

namespace ScorchGore.Leved;

public class GoreLeved
{
    public LevelBeschreibung EditedLevel = new();
    public frmLeved? Target { get; set; }

    public void Initialize(LevelBeschreibung level)
    {
        if (Target == null)
        {
            throw new NullReferenceException(nameof(Target));
        }

        if (!ReferenceEquals(EditedLevel, level))
        {
            LevedEvents.LevedPropertyChanged -= ListenPropertyChange;
        }

        EditedLevel = level;
        Target.SetupBackbuffer((int)EditedLevel.Width, (int)EditedLevel.Height);
        LevelZeichner.Zeichne(Target.Image, EditedLevel, Target.BackBuffer);
        LevedEvents.LevedPropertyChanged += ListenPropertyChange;
    }

    private void ListenPropertyChange(object sender, LevedEvents.LevedPropertyChangedEventArgs e)
    {
        if (Target == null)
        {
            return;
        }

        LevelZeichner.Zeichne(Target.Image, EditedLevel, Target.BackBuffer);
    }
}
