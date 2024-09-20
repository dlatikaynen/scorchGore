namespace ScorchGore.Constants;

internal enum Anchorage
{
    None = 0,
    TopLeft,

    /// <summary>
    /// that's where the parachute normally sits
    /// </summary>
    TopCenter,
    TopRight,
    MiddleLeft,
    MiddleRight,
    DeadCenter,
    BottomLeft,

    /// <summary>
    /// that's what the howitzers normally are
    /// </summary>
    BottomCenter,
    BottomRight
}

internal class PlatformerConstants
{
    internal const float SchwerkraftFaktor = 9.81f / 2.0f;
}