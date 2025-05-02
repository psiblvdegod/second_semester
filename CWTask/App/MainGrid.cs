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

        this.button = new CircleButton
        {
            Text = "catch me",
        };

        this.Children.Add(this.button);

        this.MoveButton();
    }

    public CircleButton button { get; private set; }

    public (int X, int Y) ButtonPosition { get; private set; } = (3, 3);

    public void MoveButton()
    {
        var random = new Random();

        var x = random.Next() % Preferences.GridWidth;
        var y = random.Next() % Preferences.GridHeight;

        SetRow(this.button, y);
        SetColumn(this.button, x);

        this.ButtonPosition = (x, y);
    }
}
