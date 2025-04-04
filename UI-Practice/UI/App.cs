// AI generated.

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

class App : Application
{
    public override void OnFrameworkInitializationCompleted()
    {
        var desktop = (IClassicDesktopStyleApplicationLifetime?)ApplicationLifetime;

        if (desktop is null)
        {
            Environment.FailFast(string.Empty);
        }

        var window =  new MainWindow(SharedData.Data);
 
        desktop.MainWindow = window;

        window.SetCell(0, 0, 'A');
    }
}
