// <copyright file="MainWindow.cs" author="psiblvdegod">
// under MIT License
// </copyright>

namespace GUI;

using System.ComponentModel;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Calculator;

/// <summary>
/// Main window of application.
/// </summary>
public class MainWindow : Window
{
    private readonly ButtonsGrid grid = new();

    private readonly CalcDisplay display = new();

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
            Children = { this.grid, this.display, },
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
            if (child is CalcButton button)
            {
                button.Click += handler;
            }
        }
    }

    /// <summary>
    /// Handles calculator`s property changes.
    /// Updates information on display according to calculator`s "State" property.
    /// Subscribe this method to calculator`s "PropertyChanged" to handle changes.
    /// </summary>
    /// <param name="sender">Object whom event calls this method.</param>
    /// <param name="args">Event args.</param>
    public void UpdateDisplayTextToMatchCalculatorState(object? sender, PropertyChangedEventArgs args)
    {
        if (sender is Calculator calculator)
        {
            this.display.Text = calculator.State;
        }
    }
}
