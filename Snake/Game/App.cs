using Avalonia.Controls.ApplicationLifetimes;

namespace Game;

public class App : Avalonia.Application
{
    private MainWindow Window = new();

    private IClassicDesktopStyleApplicationLifetime? Desktop;

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        ConfigureDesktop();
        var game = new Game(Window);
        Window.Focus();
        Window.KeyDown += game.KeyHandler;
        game.SubToButtons();
    }

    private void ConfigureDesktop()
    {
        if (this.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = this.Window;
            this.Desktop = desktop;
        }
        else
        {
            throw new NotSupportedException("seems like your platform is unsupported.");
        }
    }
}
