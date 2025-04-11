using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using static Game.UIInitialization;

namespace Game;

public class MainWindow : Window
{
    public MainWindow()
    {
        this.Content = CreatePanel();
    }
}
