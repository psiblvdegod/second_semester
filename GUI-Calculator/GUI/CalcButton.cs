using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Avalonia.Media;

namespace GUI;

public class DigitButton : Button
{
    public char Symbol { get; }

    public DigitButton(char symbol)
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
                    Fill = Brushes.LightPink,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    Width = Preferences.CellSize,
                    Height = Preferences.CellSize,
                    
                },
                new TextBlock
                {
                    Text = symbol.ToString(),
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
