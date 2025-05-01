// <copyright file="App.cs" author="psiblvdegod">
// under MIT License
// </copyright>

namespace App;

using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
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
        this.window.KeyDown += KeyHandler;
    }

    private void ConfigureDesktop()
    {
        if (this.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = this.window;
        }
        else
        {
            throw new NotSupportedException();
        }
    }

    private void ButtonHandler(object? sender, RoutedEventArgs args)
    {
        if (sender is CircleButton button && this.window is not null)
        {
            this.window.UpdateTextOnDisplay(button.Text ?? "empty");
        }
    }

    private void KeyHandler(object? sender, KeyEventArgs args)
    {
        if (this.window is not null)
        {
            this.window.UpdateTextOnDisplay(args.Key.ToString());
        }
    }
}
