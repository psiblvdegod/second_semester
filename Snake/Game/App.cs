using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Tmds.DBus.Protocol;

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
        base.OnFrameworkInitializationCompleted();
        var game = new Game(Window);
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
