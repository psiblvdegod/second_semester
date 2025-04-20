namespace UI;

public static class Preferences
{
    public static int MapHeight { get; } = Game.Preferences.MapHeight;

    public static int MapWidth { get; } = Game.Preferences.MapWidth;

    public static int CellSize { get; } = 45;

    public static string SpaceName { get; } = "SPACE";

    public static string BorderName { get; } = "BORDER";

    public static string PlayerName { get; } = "PLAYER";

    public static string BorderPath { get; } = "./Images/Border.jpg";

    public static string PlayerPath { get; } = "./Images/Player.jpg";

    public static string EnemyName { get; } = "ENEMY";

    public static string EnemyPath { get; } = "./Images/Enemy.jpg";

    public static string StatsKillsName { get; } = "KILLS";

    public static string StatsMovesName { get; } = "MOVES";

    public static string StatsName { get; } = "STATS";

    public static int StatsBlockWidth { get; } = 100;

    public static int StatsBlockHeight { get; } = 45;
}
