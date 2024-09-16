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