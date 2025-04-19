using Avalonia.Controls;

namespace UI;

public class MainWindow : Window
{
    private Grid grid;

    public MainWindow(char[][] map)
    {
        grid = Initialization.CreateGrid(map);

        this.Content = new Panel
        {
            Children = { grid }
        };
    }

    public void SetCell(int x, int y, Control value)
    {
        Grid.SetColumn(value, x);
        Grid.SetRow(value, y);
        this.grid.Children.Add(value);
    }

    public Control? PopCell(int x, int y)
    {
        var cell = grid.Children.FirstOrDefault
            (c => Grid.GetColumn(c) == x && Grid.GetRow(c) == y);
        if (cell is not null)
        {
            grid.Children.Remove(cell);
        }

        return cell;
    }
}
