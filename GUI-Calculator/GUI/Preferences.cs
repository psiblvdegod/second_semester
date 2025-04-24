namespace GUI;

public static class Preferences
{
    public static int GridWidth { get; } = 4;

    public static int GridHeight { get; } = 6;

    public static int CellSize { get; } = 100;

    public static int WindowWidth { get; } = GridWidth * CellSize + CellSize / 5;

    public static int WindowHeight { get; } = GridHeight * CellSize + CellSize / 5;
}
