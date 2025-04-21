using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Avalonia.Media;

namespace GUI;

public static class Initialization
{

    public static string[] ButtonsContent { get; } = ["789+", "456-", "123*", "0=C/"];

    public static Grid CreateGrid()
    {
        var grid = new Grid();

        for (var i = 0; i < Preferences.GridHeight; ++i)
        {
            grid.RowDefinitions.Add(new RowDefinition{Height = new GridLength(Preferences.CellSize)});
        }
        for (var i = 0; i < Preferences.GridWidth; ++i)
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition{Width = new GridLength(Preferences.CellSize)});
        }

        var display = new Display();
        Grid.SetRow(display, 0);
        Grid.SetColumn(display, Preferences.GridWidth / 2);
        grid.Children.Add(display);

        for (var i = 0; i < ButtonsContent.Length; ++i)
        {
            for (var j = 0; j < ButtonsContent[i].Length; ++j)
            {
                var button = new CalcButton(ButtonsContent[i][j]);
                Grid.SetRow(button, i + 1);
                Grid.SetColumn(button, j);
                grid.Children.Add(button);
            }
        }

        return grid;
    }
}
