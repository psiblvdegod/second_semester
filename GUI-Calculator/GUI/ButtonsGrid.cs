// <copyright file="ButtonsGrid.cs" author="psiblvdegod">
// under MIT License
// </copyright>

namespace GUI;

using Avalonia.Controls;

/// <summary>
/// Implements which calculator uses.
/// </summary>
public class ButtonsGrid : Grid
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ButtonsGrid"/> class.
    /// </summary>
    public ButtonsGrid()
    {
        for (var i = 0; i < Preferences.GridHeight; ++i)
        {
            this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(Preferences.CellSize) });
        }

        for (var i = 0; i < Preferences.GridWidth; ++i)
        {
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(Preferences.CellSize) });
        }

        for (var i = 0; i < ButtonsContent.Length; ++i)
        {
            for (var j = 0; j < ButtonsContent[i].Length; ++j)
            {
                var button = new CalcButton(ButtonsContent[i][j]);
                Grid.SetRow(button, i + 1);
                Grid.SetColumn(button, j);
                this.Children.Add(button);
            }
        }
    }

    private static string[] ButtonsContent { get; } =
        ["789+", "456-", "123*", "0.=/", "C\u2191\u2193^"];
}
