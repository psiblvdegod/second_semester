using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

namespace GUI;

public class Display : TextBlock
{
    public Display()
    {
        Width = Preferences.CellSize * Preferences.GridWidth;
        Height = Preferences.CellSize;
        Background = Brushes.Cornsilk;
        Foreground = Brushes.Black;
        Text = string.Empty;
        FontSize = 18;
        TextAlignment = TextAlignment.Center;
        HorizontalAlignment = HorizontalAlignment.Center;
        VerticalAlignment = VerticalAlignment.Center;
    }
}
