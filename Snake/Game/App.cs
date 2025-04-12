using Avalonia.Controls.ApplicationLifetimes;

namespace Game;

public class App : Avalonia.Application
{
    private MainWindow? Window;

    public override void OnFrameworkInitializationCompleted()
    {
        var window = new MainWindow();
        this.Window = window;
        var game = new Game(Window);
        Window.KeyDown += game.KeyHandler;
        ConfigureDesktop();
    }

    private void ConfigureDesktop()
    {
        if (this.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = this.Window;
        }
        else
        {
            throw new NotSupportedException("seems like your platform is unsupported.");
        }
    }
}
