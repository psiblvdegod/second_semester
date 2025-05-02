// <copyright file="MainGrid.cs" author="psiblvdegod">
// under MIT License
// </copyright>

namespace App;

using Avalonia.Controls;

/// <summary>
/// Configured grid with button on it.
/// </summary>
public class MainGrid : Grid
{
    private readonly CircleButton escapingButton;

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

        this.escapingButton = new CircleButton
        {
            Text = "catch me",
        };

        this.Children.Add(this.escapingButton);

        this.MoveButton();
    }

    /// <summary>
    /// Gets current position on button regarding the grid.
    /// </summary>
    public (int X, int Y) ButtonPosition { get; private set; }

    /// <summary>
    /// Moves button to random place on the grid.
    /// </summary>
    public void MoveButton()
    {
        var x = Random.Shared.Next() % Preferences.GridWidth;
        var y = Random.Shared.Next() % Preferences.GridHeight;

        SetRow(this.escapingButton, y);
        SetColumn(this.escapingButton, x);

        this.ButtonPosition = (x, y);
    }
}
