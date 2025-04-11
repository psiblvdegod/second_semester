using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using UI;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Game;

class App : Application
{
    public MainWindow? window;

    private GMap map;

    public override void OnFrameworkInitializationCompleted()
    {
        if (SharedData.Data is null)
        {
            Environment.FailFast("data is empty");
        }

        var desktop = (IClassicDesktopStyleApplicationLifetime?)ApplicationLifetime;

        if (desktop is null)
        {
            Environment.FailFast(string.Empty);
        }

        this.window =  new MainWindow(SharedData.Data);
 
        desktop.MainWindow = window;

        this.map = new GMap((5,5), window);

        window.KeyDown += KeyHandler;
    }

    private void KeyHandler(object? sender, KeyEventArgs e)
    {
        if (e.Key  == Key.A)
        {
            map.MoveLeft();
        }
        if (e.Key  == Key.D)
        {
            map.MoveRight();
        }
        if (e.Key  == Key.W)
        {
            map.MoveUp();
        }
        if (e.Key  == Key.S)
        {
            map.MoveDown();
        }
    }
}

