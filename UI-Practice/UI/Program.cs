using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

SharedData.Data = GetDataFromFile("./map.txt");

AppBuilder.Configure<App>()
    .UsePlatformDetect()
    .StartWithClassicDesktopLifetime(args);


static char[][] GetDataFromFile(string path)
{
    var data = File.ReadAllText(path).Split('\n');

    var result = new char[data.Length][];

    for (var i = 0; i < data.Length; ++i)
    {
        result[i] = data[i].ToCharArray();
    }

    return result;
}

static class SharedData
{
    public static char[][]? Data {get; set;}
}
