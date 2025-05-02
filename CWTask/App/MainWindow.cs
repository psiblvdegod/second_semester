// <copyright file="MainWindow.cs" author="psiblvdegod">
// under MIT License
// </copyright>

namespace App;

using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;

/// <summary>
/// Main window of application.
/// </summary>
public class MainWindow : Window
{
    private readonly MainGrid grid = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        this.CanResize = false;
        this.Width = Preferences.WindowWidth;
        this.Height = Preferences.WindowHeight;
        this.Background = Brushes.Azure;

        this.Content = new Panel
        {
            Children = { this.grid, },
        };
    }

    /// <summary>
    /// Subsribes passed handler to every button on the display.
    /// </summary>
    /// <param name="handler">Handler which will be subscribed.</param>
    public void SubscribeHandlerToButtons(EventHandler<RoutedEventArgs> handler)
    {
        foreach (var child in this.grid.Children)
        {
            if (child is CircleButton button)
            {
                button.Click += handler;
            }
        }
    }

    /// <summary>
    /// Moves button to random place on the screen when cursor gets to close to it.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public void MoveButtonOnPointerMoved(object? sender, PointerEventArgs args)
    {
        var cursorX = (int)args.GetPosition(this).X / Preferences.CellSize;

        var cursorY = (int)args.GetPosition(this).Y / Preferences.CellSize;

        if (cursorX == this.grid.ButtonPosition.X && cursorY == this.grid.ButtonPosition.Y)
        {
            this.grid.MoveButton();
        }
    }
}
