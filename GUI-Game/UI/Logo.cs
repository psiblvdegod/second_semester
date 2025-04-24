using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Game;

namespace UI;

public class Logo : Image
{
    public Logo()
    {
        Source = new Bitmap(Preferences.LogoPath);
        HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Left;
        VerticalAlignment = Avalonia.Layout.VerticalAlignment.Top;
        Width = Preferences.CellSize * 1.5;
        Height = Preferences.CellSize * 1.5;
    }
}
