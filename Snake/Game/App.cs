using Avalonia.Controls.ApplicationLifetimes;

namespace Game;

public class App : Avalonia.Application
{
    private MainWindow? Window;

    public override void OnFrameworkInitializationCompleted()
    {
        this.Window = new MainWindow();
        ConfigureDesktop();

        var game = new Game(Window);
        game.Run();
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
