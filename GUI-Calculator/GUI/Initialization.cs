using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Avalonia.Media;

namespace GUI;

public static class Initialization
{

    public static string[] ButtonsContent { get; } = ["789", "456", "123", "0+-", "*/C"];

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
                var button = new DigitButton(ButtonsContent[i][j].ToString());
                Grid.SetRow(button, i + 1);
                Grid.SetColumn(button, j);
                grid.Children.Add(button);
            }
        }

        return grid;
    }

    public class DigitButton : Button
    {
        public DigitButton(string name)
        {
            Name = name;
            Width = Preferences.CellSize;
            Height = Preferences.CellSize;

            this.Content = new Panel
            {
                Children = 
                {
                    new Ellipse
                    {
                        Fill = Brushes.LightPink,
                        Stroke = Brushes.Black,
                        StrokeThickness = 2,
                        Width = Preferences.CellSize,
                        Height = Preferences.CellSize,
                        
                    },
                    new TextBlock
                    {
                        Text = name,
                        FontSize = 16,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center
                    },
                }
            };

            this.HorizontalContentAlignment = HorizontalAlignment.Center;
            this.VerticalContentAlignment = VerticalAlignment.Center;
        }
    }

    public class Display : TextBlock
    {
        public Display()
        {
            Name = "DISPLAY";
            Width = Preferences.CellSize * Preferences.GridWidth;
            Height = Preferences.CellSize;
            Background = Brushes.MistyRose;
            Foreground = Brushes.Black;
            Text = "DISPLAY";
            FontSize = 16;
            TextAlignment = TextAlignment.Center;
            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Center;
        }
    }
}
