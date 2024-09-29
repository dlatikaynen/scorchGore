using ScorchGore.Classes;

namespace ScorchGore.Leved;

public class GoreLeved
{
    public LevelBeschreibung CurrentLevel = new();
    public frmLeved? Target { get; set; }

    public void Initialize(int levelNr)
    {
        if (Target == null)
        {
            throw new NullReferenceException(nameof(Target));
        }

        CurrentLevel = LevelSequenzierer.ErzeugeLevelBeschreibung(levelNr);
        Target.SetupBackbuffer(CurrentLevel.LevelWidth, CurrentLevel.LevelHeight);
    }
}
