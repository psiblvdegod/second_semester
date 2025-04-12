using Avalonia.Controls;
using static Game.UIInitialization;

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
        ClearOld();
        this.grid.Children.Add(value);

        void ClearOld()
        {
            var old = grid.Children.FirstOrDefault
                (c => Grid.GetColumn(c) == x && Grid.GetRow(c) == y);

            if (old != null)
            {
                grid.Children.Remove(old);
            }
        }
    }

    public void AddButtons(StackPanel buttons)
    {
        if (this.Content is Panel content)
        {
            content.Children.Add(buttons);
        }
    }
}
