using Avalonia.Controls;
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

    public static Control CreateSpace()
    {
        var control = new Control
        {
            Height = CellSize,
            Width = CellSize
        };

        return control;
    }
}
