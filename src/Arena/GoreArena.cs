using ScorchGore.Classes;

namespace ScorchGore.Arena;

public class GoreArena
{
    public LevelBeschreibung CurrentLevel = new();
    public Panel? Target { get; set; }
    public Bitmap Image { get { return (Target!.BackgroundImage as Bitmap)!; } }

    internal Sprite Player1 = new SpritePlayer(Brushes.YellowGreen);
    internal Sprite Player2 = new SpritePlayer(Brushes.MistyRose);

    private Panel TargetViewport => (Panel)Target!.Parent!;

    public void Initialize(int levelNr)
    {
        if (Target == null)
        {
            throw new NullReferenceException(nameof(Target));
        }

        CurrentLevel = LevelSequenzierer.ErzeugeLevelBeschreibung(levelNr);
        Target.Width = (int)(CurrentLevel.LevelWidth * 1.5);
        Target.Height = (int)(CurrentLevel.LevelHeight * 1.5);
        Target.Left = (TargetViewport.Width - Target.Width) / 2;
        Target.Top = (TargetViewport.Height - Target.Height) / 2;
        Target.BackgroundImage = new Bitmap(CurrentLevel.LevelWidth, CurrentLevel.LevelHeight);

        using var canvas = Graphics.FromImage(Image);
        LevelZeichner.Zeichne(Image, CurrentLevel, canvas);
        Player1.AnchorX = 30;
        Player1.AnchorY = 15;
        Player2.AnchorX = CurrentLevel.LevelWidth - 30;
        Player2.AnchorY = 15;
        Player1.Emplace(Image);
        Player2.Emplace(Image);
    }
}
