// <copyright file="ButtonsGrid.cs" author="psiblvdegod">
// under MIT License
// </copyright>

namespace App;

using Avalonia.Controls;

/// <summary>
/// Configured grid for 
/// </summary>
public class MainGrid : Grid
{
    public RectangleDisplay Display { get; private set; }

    public List<CircleButton> Buttons { get; private set; } = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="MainGrid"/> class.
    /// </summary>
    public MainGrid()
    {
        for (var i = 0; i < Preferences.GridHeight; ++i)
        {
            this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(Preferences.CellSize) });
        }

        for (var i = 0; i < Preferences.GridWidth; ++i)
        {
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(Preferences.CellSize) });
        }

        var button = new CircleButton
        {
            Text = "B-TEXT"
        };
        this.Buttons.Add(button);

        Grid.SetRow(button, 3);
        Grid.SetColumn(button, 3);
        this.Children.Add(button);


        var display = new RectangleDisplay
        {
            Text = "D-TEXT"
        };
        this.Display = display;

        Grid.SetRow(display, 1);
        Grid.SetColumn(display, 4);
        this.Children.Add(display);
    }
}
