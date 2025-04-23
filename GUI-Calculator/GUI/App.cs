using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;

namespace GUI;
using Calculator;

public class App : Avalonia.Application
{
    private MainWindow? Window;

    private readonly Calculator calculator = new();

    public override void OnFrameworkInitializationCompleted()
    {
        this.Window = new MainWindow();
        ConfigureDesktop();
        Window.SubToButtons(ButtonHandler);
        calculator.PropertyChanged += Window.UpdateDisplay;
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
        if (sender is CalcButton button)
        {
            calculator.AddToken(button.Symbol);
        }
    }
}
