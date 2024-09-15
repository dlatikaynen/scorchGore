using ScorchGore.Classes;

namespace ScorchGore.Arena;

public class GoreArena
{
    public LevelBeschreibung CurrentLevel = new();
    public Bitmap Image = new(1, 1);

    public void Initialize(int levelNr)
    {
        CurrentLevel = LevelSequenzierer.ErzeugeLevelBeschreibung(levelNr);
        Image = new(CurrentLevel.LevelWidth, CurrentLevel.LevelHeight);

        using var canvas = Graphics.FromImage(Image);
        LevelZeichner.Zeichne(Image, CurrentLevel, canvas);
    }
}
