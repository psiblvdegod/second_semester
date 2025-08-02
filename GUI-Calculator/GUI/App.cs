// <copyright file="App.cs" author="psiblvdegod">
// under MIT License
// </copyright>

namespace GUI;

using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Calculator;

/// <summary>
/// Graphical application which creates calculator in new window.
/// </summary>
public class App : Avalonia.Application
{
    private readonly Calculator calculator = new();

    private MainWindow? window;

    /// <inheritdoc/>
    public override void OnFrameworkInitializationCompleted()
    {
        this.window = new MainWindow();
        this.ConfigureDesktop();
        this.window.SubscribeHandlerToButtons(this.ButtonHandler);
        this.calculator.PropertyChanged += this.window.UpdateDisplayTextToMatchCalculatorState;
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
        if (sender is CalcButton button)
        {
            this.calculator.AddToken(button.Symbol);
        }
    }
}
