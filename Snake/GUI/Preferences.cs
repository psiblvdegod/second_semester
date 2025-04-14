using System.Diagnostics;

namespace Game;

public static class Preferences
{
    public static int MapSize { get; } = 25;
    public static int CellSize { get; } = 30;
    public static (int x, int y) InitialPosition { get; } = (10, 10);

    public static string SpaceName { get; } = "SPACE";
}
