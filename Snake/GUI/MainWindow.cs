using Avalonia.Controls;
using static Game.UIElements;

namespace Game;

public class MainWindow : Window
{
    private Grid grid = CreateGrid();

    public MainWindow()
    {
        this.Content = new Panel()
        {
            Children = { this.grid }
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

    public void AddButtons(StackPanel buttons)
    {
        if (this.Content is Panel content)
        {
            content.Children.Add(buttons);
        }
    }
}
