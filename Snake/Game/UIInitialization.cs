using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

namespace Game;

public static class UIInitialization
{
    public static StackPanel CreatePanel()
    {
        var contentForButtons = "WASD";

        var panel = new StackPanel()
        {
            Orientation = Orientation.Horizontal,
            Spacing = 20,
        };

        foreach (var c in contentForButtons)
        {
            var button = new Button
            {
                Background = Brushes.HotPink,
                Foreground = Brushes.Black,
                Height = 50,
                Width = 50,
                Content = c
            };

            panel.Children.Add(button);
        }

        return panel;
    }
}