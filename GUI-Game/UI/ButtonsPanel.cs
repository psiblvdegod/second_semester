using Avalonia.Controls;

namespace UI;

public class ButtonsPanel : StackPanel
{
    private static readonly string buttonContent = "WASD";
    
    public ButtonsPanel()
    {
        Orientation = Avalonia.Layout.Orientation.Horizontal;
        HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
        VerticalAlignment = Avalonia.Layout.VerticalAlignment.Bottom;
        foreach (var symbol in buttonContent)
        {
            var button = new MoveButton(symbol);
            Children.Add(button);
        }
    }
}
