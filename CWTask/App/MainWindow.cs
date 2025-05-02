// <copyright file="MainWindow.cs" author="psiblvdegod">
// under MIT License
// </copyright>

namespace App;

using System.ComponentModel;
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
        this.HorizontalContentAlignment = Avalonia.Layout.HorizontalAlignment.Center;
        this.VerticalContentAlignment = Avalonia.Layout.VerticalAlignment.Center;
        this.Width = Preferences.WindowWidth;
        this.Height = Preferences.WindowHeight;
        this.CanResize = false;
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
    public void SubscribeHandlerToButton(EventHandler<RoutedEventArgs> handler)
    {
        this.grid.button.Click += handler;
    }

    public void OnPointerMoved(object? sender, PointerEventArgs args)
    {
        var cursorPosition = args.GetPosition(this);

        var cursorX = (int)cursorPosition.X / Preferences.CellSize;

        var cursorY = (int)cursorPosition.Y / Preferences.CellSize;

        if (cursorX == this.grid.ButtonPosition.X && cursorY == this.grid.ButtonPosition.Y)
        {
            this.grid.RecreateButton();
        }

        Console.WriteLine($"{cursorX} {cursorY}");
    }
}
