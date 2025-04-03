using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

class App : Application
{
    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {   
            desktop.MainWindow = new MainWindow(SharedData.Data);
        }

        base.OnFrameworkInitializationCompleted();
    }
}
