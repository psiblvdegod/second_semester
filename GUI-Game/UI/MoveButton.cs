namespace UI;

using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Avalonia.Media;

public class MoveButton : Button
{
    public char Symbol { get; }

    public MoveButton(char symbol)
    {
        Symbol = symbol;
        Width = Preferences.CellSize * 1.2;
        Height = Preferences.CellSize * 1.2;

        this.Content = new Panel
        {
            Children = 
            {
                new Ellipse
                {
                    Fill = Brushes.Cornsilk,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    Width = Preferences.CellSize * 1.1,
                    Height = Preferences.CellSize * 1.1,
                    
                },
                new TextBlock
                {
                    Text = symbol.ToString(),
                    FontSize = 24,
                    Foreground = Brushes.Black,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                },
            }
        };

        this.HorizontalContentAlignment = HorizontalAlignment.Center;
        this.VerticalContentAlignment = VerticalAlignment.Center;
    }
}
