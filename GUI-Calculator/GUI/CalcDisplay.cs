// <copyright file="CalcDisplay.cs" author="psiblvdegod">
// under MIT License
// </copyright>

namespace GUI;

using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Avalonia.Media;

/// <summary>
/// Configured block with text for graphical calculator.
/// </summary>
public class CalcDisplay : Panel
{
    private readonly TextBlock textBlock;

    /// <summary>
    /// Initializes a new instance of the <see cref="CalcDisplay"/> class.
    /// </summary>
    public CalcDisplay()
    {
        var back = new Rectangle
        {
            Width = Preferences.CellSize * Preferences.GridWidth * 0.95,
            Height = Preferences.CellSize * 0.95,
            Fill = Brushes.Cornsilk,
            Stroke = Brushes.Black,
            StrokeThickness = 2,
        };

        var front = new TextBlock
        {
            FontSize = 18,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
        };

        this.textBlock = front;

        this.Children.Add(back);
        this.Children.Add(front);
        this.HorizontalAlignment = HorizontalAlignment.Center;
        this.VerticalAlignment = VerticalAlignment.Top;
    }

    /// <summary>
    /// Gets or sets text which is displayed.
    /// </summary>
    public string Text
    {
        get => this.textBlock.Text ?? string.Empty;
        set => this.textBlock.Text = value;
    }
}
