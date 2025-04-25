// <copyright file="Preferences.cs" author="psiblvdegod">
// under MIT License
// </copyright>

namespace GUI;

// SA160: Elements should be documented.
#pragma warning disable SA1600

/// <summary>
/// Stores preferences for application.
/// </summary>
public static class Preferences
{
    public static int GridWidth { get; } = 4;

    public static int GridHeight { get; } = 6;

    public static int CellSize { get; } = 100;

    public static int WindowWidth { get; } = (GridWidth * CellSize) + (CellSize / 5);

    public static int WindowHeight { get; } = (GridHeight * CellSize) + (CellSize / 5);
}
