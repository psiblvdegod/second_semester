// AI generated.

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

char[][] data =
[
    ['1', '2', '3'],
    ['4', '5'],
    ['6', '7', '8', '9'],
];

SharedData.Data = data;

BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);



static AppBuilder BuildAvaloniaApp()
    => AppBuilder.Configure<App>().UsePlatformDetect();

static class SharedData
{
    public static char[][]? Data {get; set;}
}
