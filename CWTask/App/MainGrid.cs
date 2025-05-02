// <copyright file="MainGrid.cs" author="psiblvdegod">
// under MIT License
// </copyright>

namespace App;

using Avalonia.Controls;

/// <summary>
/// Configured grid for .
/// </summary>
public class MainGrid : Grid
{
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
            Text = "catch me",
        };
        this.Buttons.Add(button);

        Grid.SetRow(button, 3);
        Grid.SetColumn(button, 3);
        this.Children.Add(button);
    }

    /// <summary>
    /// Gets buttons on window.
    /// </summary>
    public List<CircleButton> Buttons { get; private set; } = [];
}
