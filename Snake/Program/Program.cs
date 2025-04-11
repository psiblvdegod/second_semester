using Avalonia;
using Game;

AppBuilder.Configure<App>()
    .UsePlatformDetect()
    .StartWithClassicDesktopLifetime(args);
