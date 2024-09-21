namespace ScorchGore.Arena;

internal class SpritePlayer : Sprite
{
    private readonly Brush _color;

    internal SpritePlayer(Brush color)
    {
        _color = color;
        Width = 30;
        Height = 30;
        Anchorage = Constants.Anchorage.BottomCenter;
    }

    internal override Color PrimaryBodyColor => ((SolidBrush)_color).Color;

    protected override void Draw(Graphics g)
    {
        g.FillPie(
            _color,
            0,
            Height / 2 + 1,
            Width,
            Height,
            0f,
            -180f
        );
    }
}
