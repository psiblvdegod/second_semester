// <copyright file="CircleButton.cs" author="psiblvdegod">
// under MIT License
// </copyright>

namespace App;

using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Avalonia.Media;

/// <summary>
/// Configured button for.
/// </summary>
public class CircleButton : Button
{
    private readonly TextBlock textBlock;

    /// <summary>
    /// Initializes a new instance of the <see cref="CircleButton"/> class.
    /// </summary>
    /// <param name="symbol">Symbol which will be displayed on button.</param>
    public CircleButton()
    {
        this.Width = Preferences.CellSize;
        this.Height = Preferences.CellSize;

        this.textBlock =
        new TextBlock
        {
            FontSize = 15,
            Foreground = Brushes.Black,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
        };

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

                this.textBlock,
            },
        };

        this.HorizontalContentAlignment = HorizontalAlignment.Center;
        this.VerticalContentAlignment = VerticalAlignment.Center;
    }

    /// <summary>
    /// Gets or sets text which is displayed on button.
    /// </summary>
    public string Text
    {
        get => this.textBlock.Text ?? string.Empty;
        set => this.textBlock.Text = value;
    }
}
