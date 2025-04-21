using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Avalonia.Media;

namespace GUI;

public class CalcButton : Button
{
    public char Symbol { get; }

    public CalcButton(char symbol)
    {
        Symbol = symbol;
        Width = Preferences.CellSize;
        Height = Preferences.CellSize;

        this.Content = new Panel
        {
            Children = 
            {
                new Ellipse
                {
                    Fill = Brushes.Cornsilk,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    Width = Preferences.CellSize * 0.95,
                    Height = Preferences.CellSize * 0.95,
                    
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
