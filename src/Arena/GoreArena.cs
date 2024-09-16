using ScorchGore.Classes;

namespace ScorchGore.Arena;

public class GoreArena
{
    public LevelBeschreibung CurrentLevel = new();
    public Panel? Target { get; set; }
    public Bitmap Image { get { return (Target!.BackgroundImage as Bitmap)!; } }

    internal Sprite Player1 = new SpritePlayer(Brushes.Black);
    internal Sprite Player2 = new SpritePlayer(Brushes.Maroon);

    public void Initialize(int levelNr)
    {
        if (Target == null)
        {
            throw new NullReferenceException(nameof(Target));
        }

        CurrentLevel = LevelSequenzierer.ErzeugeLevelBeschreibung(levelNr);
        Target.BackgroundImage = new Bitmap(CurrentLevel.LevelWidth, CurrentLevel.LevelHeight);

        using var canvas = Graphics.FromImage(Image);
        LevelZeichner.Zeichne(Image, CurrentLevel, canvas);
        Player1.AnchorX = 60;
        Player1.AnchorY = 60;
        Player2.AnchorX = 90;
        Player2.AnchorY = 90;
        Player2.Emplace(Image);
        Player1.Emplace(Image);
    }
}
