// AI generated.

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

class App : Application
{
    public MainWindow? window;

    public override void OnFrameworkInitializationCompleted()
    {
        var desktop = (IClassicDesktopStyleApplicationLifetime?)ApplicationLifetime;

        if (desktop is null)
        {
            Environment.FailFast(string.Empty);
        }

        this.window =  new MainWindow(SharedData.Data);
 
        desktop.MainWindow = window;

        
    }
}
