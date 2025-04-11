using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using static Game.UIInitialization;

namespace Game;

public class MainWindow : Window
{
    private Grid grid = CreateGrid();

    public MainWindow()
    {
        this.Content = new Panel()
        {
            Children = { this.grid, CreatePanel() }
        };
    }

    public void SetCell(int x, int y, Control value)
    {
        Grid.SetColumn(value, x);
        Grid.SetRow(value, y);
        this.grid.Children.Add(value);
    }
}
