using ScorchGore.Classes;

namespace ScorchGore.Arena;

public class GoreArena
{
    public LevelBeschreibung CurrentLevel = new();
    public Panel? Target { get; set; }
    public Bitmap Image { get { return (Target!.BackgroundImage as Bitmap)!; } }

    public void Initialize(int levelNr)
    {
        if(Target == null)
        {
            throw new NullReferenceException(nameof(Target));
        }

        CurrentLevel = LevelSequenzierer.ErzeugeLevelBeschreibung(levelNr);
        Target.BackgroundImage = new Bitmap(CurrentLevel.LevelWidth, CurrentLevel.LevelHeight);

        using var canvas = Graphics.FromImage(Image);
        LevelZeichner.Zeichne(Image, CurrentLevel, canvas);
    }
}
