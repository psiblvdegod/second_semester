using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Controls.Shapes;

namespace GUI;

public class Display : Panel
{
    private readonly TextBlock textBlock;

    public Display()
    {
        var back = new Rectangle
        {
            Width = Preferences.CellSize * Preferences.GridWidth * 0.95,
            Height = Preferences.CellSize * 0.95,
            Fill = Brushes.Cornsilk,
            Stroke = Brushes.Black,
            StrokeThickness = 2,
        };

        var front = new TextBlock
        {
            FontSize = 18,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
        };

        this.textBlock = front;

        Children.Add(back);
        Children.Add(front);
        
        HorizontalAlignment = HorizontalAlignment.Center;
        VerticalAlignment = VerticalAlignment.Top;
    }

    public string Data
    {
        get => this.textBlock.Text ?? string.Empty;
        set => this.textBlock.Text = value;
    }
}
