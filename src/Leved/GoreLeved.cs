using ScorchGore.Arena;
using ScorchGore.Classes;

namespace ScorchGore.Leved;

public class GoreLeved
{
    public LevelBeschreibung EditedLevel = new();
    public frmLeved? Target { get; set; }

    public void Initialize(int levelNr)
    {
        if (Target == null)
        {
            throw new NullReferenceException(nameof(Target));
        }

        EditedLevel = LevelSequenzierer.ErzeugeLevelBeschreibung(levelNr);
        Target.SetupBackbuffer(EditedLevel.LevelWidth, EditedLevel.LevelHeight);
        LevelZeichner.Zeichne(Target.Image, EditedLevel, Target.BackBuffer);
    }
}
