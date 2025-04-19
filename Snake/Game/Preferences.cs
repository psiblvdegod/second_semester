using System.Diagnostics;

namespace Game;

public static class Preferences
{
    public static int MapWidth { get; } = 40; 

    public static int MapHeight { get; } = 20;

    public static (int x, int y) InitialPosition { get; } = (10, 10);

    public static char PlayerSymbol { get; } = '@';

    public static char BorderSymbol { get; } = '#';

    public static char SpaceSymbol { get; } = ' ';
}
