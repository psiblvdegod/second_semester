namespace GUI;

using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System.ComponentModel;
using Calculator;

public class MainWindow : Window
{
    private readonly ButtonsGrid grid;
    
    private readonly Display display;

    public MainWindow()
    {
        HorizontalContentAlignment = Avalonia.Layout.HorizontalAlignment.Center;
        VerticalContentAlignment = Avalonia.Layout.VerticalAlignment.Center;
        Width = Preferences.WindowWidth;
        Height = Preferences.WindowHeight;
        Background = Brushes.Azure;

        this.grid = new ButtonsGrid();
        this.display = new Display();

        this.Content = new Panel
        { 
            Children = { grid, display, },
        };
    }

    public void SubToButtons(EventHandler<RoutedEventArgs> handler)
    {
        foreach (var child in grid.Children)
        {
            if (child is CalcButton button)
            {
                button.Click += handler;
            }
        }
    }

    public void UpdateDisplay(object? sender, PropertyChangedEventArgs args)
    {
        if (sender is Calculator calculator)
        {
            display.Data = calculator.State;
        }
    }
}
