using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using Tmds.DBus.Protocol;
using Avalonia.Media.Imaging;

namespace GUI;

public static class Initialization
{

    public static string ButtonsContent { get; }= "123";

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

        var display = CreateDisplay();
        Grid.SetRow(display, 0);
        Grid.SetColumn(display, Preferences.GridWidth / 2);
        grid.Children.Add(display);

        for (var i = 0; i < ButtonsContent.Length; ++i)
        {
            var button = CreateButton(ButtonsContent[i].ToString());
            Grid.SetRow(button, 1);
            Grid.SetColumn(button, i);
            grid.Children.Add(button);
        }

        return grid;
    }

    public static Button CreateButton(string name)
    {
        var control = new Button
        {
            Name = name,
            Width = Preferences.CellSize,
            Height = Preferences.CellSize,
            Background = Brushes.HotPink,
            Content = new TextBlock
            {
                Text = name,
                FontSize = 16,
                Foreground = Brushes.White,
            }
        };

        return control;
    }

    public static TextBlock CreateDisplay()
    {
        var control = new TextBlock
        {
            Name = "DISPLAY",
            Width = Preferences.CellSize * Preferences.GridWidth,
            Height = Preferences.CellSize,
            Background = Brushes.GhostWhite,
            Text = "DISPLAY",
        };

        return control;
    }
}