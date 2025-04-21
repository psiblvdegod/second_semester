using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;

namespace GUI;

using Calculator;

public class App : Avalonia.Application
{
    private MainWindow? Window;

    private Calculator calculator = new();

    public override void OnFrameworkInitializationCompleted()
    {
        this.Window = new MainWindow();
        ConfigureDesktop();
        SubToButtons();
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

    private void ButtonHandler(object? sender, RoutedEventArgs args)
    {
        if (sender is DigitButton button)
        {
            calculator.AddToken(button.Symbol);
        }

        UpdateDisplay();
    }

    private void SubToButtons()
    {
        if (this.Window is null)
        {
            Environment.FailFast("Main Window is null");
        }

        foreach (var child in this.Window.grid.Children)
        {
            if (child is Button button)
            {
                button.Click += ButtonHandler;
            }
        }
    }

    private void UpdateDisplay()
    {
        if (this.Window is null)
        {
            Environment.FailFast("Main Window is null");
        }

        foreach (var child in this.Window.grid.Children)
        {
            if (child is Display display)
            {
                display.Text = calculator.Output;
            }
        }
    }
}
