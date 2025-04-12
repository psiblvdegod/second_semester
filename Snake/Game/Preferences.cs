namespace Game;

public static class Preferences
{
    public static int MapSize { get; } = 50;
    public static int CellSize { get; } = 35;
    public static (int x, int y) InitialPosition { get; } = (10, 10);
}
