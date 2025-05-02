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
    public void SubscribeHandlerToButtons(EventHandler<RoutedEventArgs> handler)
    {
        foreach (var button in this.grid.Buttons)
        {
            button.Click += handler;
        }
    }

    /// <summary>
    /// Updates text on display.
    /// </summary>
    /// <param name="text">New text.</param>
    public void UpdateTextOnDisplay(string text)
        => this.grid.Display.Text = text;
}
