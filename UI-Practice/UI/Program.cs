// AI generated.

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

static class SharedData
{
    public static char[][]? Data {get; set;}
}
class Program
{
    public static void Main(string[] args)
    {
        // Создаем зубчатый массив в Main
        char[][] data =
        [
            ['1', '2', '3'],
            ['4', '5'],
            ['6', '7', '8', '9'],
        ];

        SharedData.Data = data;

        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect();
}
