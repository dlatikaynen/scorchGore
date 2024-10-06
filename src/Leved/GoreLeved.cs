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

        EditedLevel = level;
        Target.SetupBackbuffer((int)EditedLevel.Width, (int)EditedLevel.Height);
        LevelZeichner.Zeichne(Target.Image, EditedLevel, Target.BackBuffer);
    }
}
