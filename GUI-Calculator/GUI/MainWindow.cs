using Avalonia.Controls;
using Avalonia.Media;

namespace GUI;

public class MainWindow : Window
{
    public Grid grid;

    public MainWindow()
    {
        HorizontalContentAlignment = Avalonia.Layout.HorizontalAlignment.Center;
        VerticalContentAlignment = Avalonia.Layout.VerticalAlignment.Center;
        Width = Preferences.WindowWidth;
        Height = Preferences.WindowHeight;
        Background = Brushes.Azure;

        this.grid = Initialization.CreateGrid();

        this.Content = new Panel
        { 
            Children = { grid, },
        };
    }
}
