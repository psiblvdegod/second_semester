namespace UI;

public static class Preferences
{
    public static int MapHeight { get; } = Game.Preferences.MapHeight;

    public static int MapWidth { get; } = Game.Preferences.MapWidth;

    public static int CellSize {get;} = 30;

    public static string SpaceName { get; } = "SPACE";

    public static string BorderName { get; } = "BORDER";

    public static string PlayerName { get; } = "PLAYER";

    public static string BorderPath { get; } = "./Images/Border.jpg";

    public static string PlayerPath { get; } = "./Images/Player.jpg";
}
