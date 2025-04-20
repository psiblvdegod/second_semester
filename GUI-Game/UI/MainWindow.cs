using Avalonia.Controls;

namespace UI;

public class MainWindow : Window
{
    private Grid grid;

    public StackPanel statistics { get; set; }

    public MainWindow(char[][] map)
    {
        grid = Initialization.CreateGrid(map);

        statistics = Initialization.CreateStatistics();

        this.Content = new Panel
        {
            Children =
            { 
                grid, statistics,
            }
        };
    }

    public void SetCell((int x, int y) Position, Control value)
    {
        Grid.SetColumn(value, Position.x);
        Grid.SetRow(value, Position.y);
        this.grid.Children.Add(value);
    }

    public Control? PopCell((int x, int y) Position)
    {
        var cell = grid.Children.FirstOrDefault
            (c => Grid.GetColumn(c) == Position.x && Grid.GetRow(c) == Position.y);
        if (cell is not null)
        {
            grid.Children.Remove(cell);
        }

        return cell;
    }
}
