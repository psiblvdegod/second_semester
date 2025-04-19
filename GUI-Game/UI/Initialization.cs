using Avalonia.Controls;
using Avalonia.Media.Imaging;

namespace UI;

public static class Initialization
{
    public static Grid CreateGrid(char[][] map)
    {
        var grid = new Grid();

        for (int i = 0; i < Preferences.MapHeight; ++i)
        {
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(Preferences.CellSize) });
        }

        for (int i = 0; i < Preferences.MapWidth; ++i)
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(Preferences.CellSize)});
        }

        for (var y = 0; y < Preferences.MapHeight; ++y)
        {
            for (var x = 0; x < Preferences.MapWidth; ++x)
            {
                Control control;

                if (map[y][x] == Game.Preferences.SpaceSymbol)
                {
                    control = CreateSpace();
                }
                else if (map[y][x] == Game.Preferences.PlayerSymbol)
                {
                    control = CreatePlayer();
                }
                else if (map[y][x] == Game.Preferences.BorderSymbol)
                {
                    control = CreateBorder();
                }
                else
                {
                    throw new ArgumentException("Incorrect symbol in map.");
                }
                
                Grid.SetColumn(control, x);
                Grid.SetRow(control, y);
                grid.Children.Add(control);
            }
        }

        return grid;
    }

    public static Control CreateSpace()
    {
        var control = new Control
        {
            Name = Preferences.SpaceName,
            Height = Preferences.CellSize,
            Width = Preferences.CellSize,
        };

        return control;
    }

    public static Image CreateBorder()
    {
        var control = new Image
        {
            Name = Preferences.BorderName,
            Height = Preferences.CellSize,
            Width = Preferences.CellSize,
            Source = new Bitmap(Preferences.BorderPath),
        };

        return control;
    }

    public static Image CreatePlayer()
    {
        var control = new Image
        {
            Name = Preferences.PlayerName,
            Height = Preferences.CellSize,
            Width = Preferences.CellSize,
            Source = new Bitmap(Preferences.PlayerPath),
        };

        return control;
    }
}
