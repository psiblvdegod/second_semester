// <copyright file="Preferences.cs" author="psiblvdegod">
// under MIT License
// </copyright>

namespace App;

// Elements should be documented.
#pragma warning disable SA1600
#pragma warning disable CS1591

/// <summary>
/// Stores preferences for application.
/// </summary>
public static class Preferences
{
    public static int GridWidth { get; } = 12;

    public static int GridHeight { get; } = 8;

    public static int CellSize { get; } = 75;

    public static int WindowWidth { get; } = (GridWidth * CellSize) + (CellSize / 5);

    public static int WindowHeight { get; } = (GridHeight * CellSize) + (CellSize / 5);
}
