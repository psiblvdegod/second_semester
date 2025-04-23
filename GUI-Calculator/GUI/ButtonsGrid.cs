using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Avalonia.Media;

namespace GUI;

public class ButtonsGrid : Grid
{
    public static string[] ButtonsContent { get; } = ["789+", "456-", "123*", "0=C/"];

    public ButtonsGrid()
    {
        for (var i = 0; i < Preferences.GridHeight; ++i)
        {
            this.RowDefinitions.Add(new RowDefinition{Height = new GridLength(Preferences.CellSize)});
        }
        for (var i = 0; i < Preferences.GridWidth; ++i)
        {
            this.ColumnDefinitions.Add(new ColumnDefinition{Width = new GridLength(Preferences.CellSize)});
        }

        for (var i = 0; i < ButtonsContent.Length; ++i)
        {
            for (var j = 0; j < ButtonsContent[i].Length; ++j)
            {
                var button = new CalcButton(ButtonsContent[i][j]);
                Grid.SetRow(button, i + 1);
                Grid.SetColumn(button, j);
                this.Children.Add(button);
            }
        }
    }
}
