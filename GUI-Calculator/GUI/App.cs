using Avalonia.Controls.ApplicationLifetimes;

namespace GUI;

public class App : Avalonia.Application
{
    private MainWindow? Window;

    public override void OnFrameworkInitializationCompleted()
    {
        this.Window = new MainWindow();
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
            throw new NotSupportedException();
        }
    }
}
