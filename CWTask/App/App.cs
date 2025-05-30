// <copyright file="App.cs" author="psiblvdegod">
// under MIT License
// </copyright>

namespace App;

using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;

/// <summary>
/// Graphical application which creates calculator in new window.
/// </summary>
public class App : Avalonia.Application
{
    private MainWindow? window;

    /// <inheritdoc/>
    public override void OnFrameworkInitializationCompleted()
    {
        this.window = new MainWindow();
        this.ConfigureDesktop();
        this.window.SubscribeHandlerToButtons(this.ButtonHandler);
        this.window.PointerMoved += this.window.MoveButtonOnPointerMoved;
    }

    private void ConfigureDesktop()
    {
        if (this.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = this.window;
        }
        else
        {
            throw new NotSupportedException("It seems like your platform is not supported.");
        }
    }

    private void ButtonHandler(object? sender, RoutedEventArgs args)
    {
        if (sender is CircleButton && this.window is not null)
        {
            this.window.Close();
        }
    }
}
