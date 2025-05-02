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

        this.RecreateButton();
    }

    public void RecreateButton()
    {
        this.Children.Remove(this.button);

        var button = new CircleButton
        {
            Text = "catch me",
        };

        var random = new Random();

        var x = random.Next() % Preferences.GridWidth;
        var y = random.Next() % Preferences.GridHeight;

        SetRow(button, x);
        SetColumn(button, y);
        this.Children.Add(button);

        this.button = button;

        this.ButtonPosition = (x, y);
    }

    public CircleButton button;

    public (int X, int Y) ButtonPosition = (3, 3);
}
