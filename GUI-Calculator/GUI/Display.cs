using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Avalonia.Media;

namespace GUI;

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
