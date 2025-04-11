using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace Game;

/// <summary>
/// some static methods creating configured ui stuff.
/// </summary>
public static class UIInitialization
{
    public static int CellSize = 50;
    public static int MapSize = 50;

    public static StackPanel CreatePanel()
    {
        var contentForButtons = "WASD";

        var panel = new StackPanel()
        {
            Orientation = Orientation.Horizontal,
            Spacing = CellSize / 2,
        };

        foreach (var c in contentForButtons)
        {
            var button = new Button
            {
                Background = Brushes.HotPink,
                Foreground = Brushes.Black,
                Height = CellSize,
                Width = CellSize,
                Content = c
            };

            panel.Children.Add(button);
        }

        return panel;
    }

    public static Grid CreateGrid()
    {
        var grid = new Grid();

        for (int i = 0; i < MapSize; i++)
        {
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(CellSize) });
        }

        for (int j = 0; j < MapSize; j++)
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(CellSize) });
        }

        return grid;
    }

    public static Control CreateCharacter()
    {
        var image = new Image()
        {
            Height = CellSize,
            Width = CellSize,
            Source = new Bitmap("./Images/sf.jpg"),
        };

        return image;
    }

    public static Control CreateWall()
    {
        var image = new Image()
        {
            Height = CellSize,
            Width = CellSize,
            Source = new Bitmap("./Images/wall.jpg"),
        };

        return image;
    }
}
