namespace ScorchGore.Extensions;

internal static class ControlExtensions
{
    public static void Center(this Control controlToCenter, Control parentContainer)
    {
        controlToCenter.Location = new Point(
            parentContainer.Width / 2 - controlToCenter.Width / 2,
            parentContainer.Height / 2 - controlToCenter.Height / 2
        );
    }
}
