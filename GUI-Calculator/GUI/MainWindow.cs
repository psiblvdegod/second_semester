using Avalonia.Controls;

namespace GUI;

public class MainWindow : Window
{
    public Grid grid;

    public MainWindow()
    {
        this.grid = Initialization.CreateGrid();

        this.Content = new Panel
        { 
            Children = { grid, },
        };
    }
}
