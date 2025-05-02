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
        this.window.SubscribeHandlerToButton(this.ButtonHandler);
        this.window.PointerMoved += this.OnPointerMoved;
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
            this.window.Close();
        }
    }

    private void OnPointerMoved(object? sender, PointerEventArgs args)
    {
        var position = args.GetPosition(this.window);

        Console.WriteLine(position);
    }
}
