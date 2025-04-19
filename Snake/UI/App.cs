using Avalonia.Controls.ApplicationLifetimes;

namespace UI;

public class App : Avalonia.Application
{
    private MainWindow? Window;

    private Game.Game? game;

    public override void OnFrameworkInitializationCompleted()
    {
        game = new();
        this.Window = new MainWindow(game.map);
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
