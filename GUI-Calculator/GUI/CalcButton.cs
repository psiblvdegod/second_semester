// <copyright file="CalcButton.cs" author="psiblvdegod">
// under MIT License
// </copyright>

namespace GUI;

using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Avalonia.Media;

/// <summary>
/// Configured button for graphical calculator.
/// </summary>
public class CalcButton : Button
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CalcButton"/> class.
    /// </summary>
    /// <param name="symbol">Symbol which will be displayed on button.</param>
    public CalcButton(char symbol)
    {
        this.Symbol = symbol;
        this.Width = Preferences.CellSize;
        this.Height = Preferences.CellSize;

        this.Content = new Panel
        {
            Children =
            {
                new Ellipse
                {
                    Fill = Brushes.Cornsilk,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    Width = Preferences.CellSize * 0.95,
                    Height = Preferences.CellSize * 0.95,
                },
                new TextBlock
                {
                    Text = symbol.ToString(),
                    FontSize = 24,
                    Foreground = Brushes.Black,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                },
            },
        };

        this.HorizontalContentAlignment = HorizontalAlignment.Center;
        this.VerticalContentAlignment = VerticalAlignment.Center;
    }

    /// <summary>
    /// Gets symbol which is displayed on button.
    /// </summary>
    public char Symbol { get; }
}
