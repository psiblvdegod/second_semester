// AI generated.

using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using Tmds.DBus.Protocol;

public class MainWindow : Window
{
    private Grid grid = new();

    public MainWindow(char[][] data)
    {
        this.Title = "Game";
        this.Width = 1000;
        this.Height = 800;

        int width = data.Max(row => row.Length);

        int height = data.Length;
        
        for (int j = 0; j < width; j++)
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        for (int i = 0; i < height; i++)
        {
            grid.RowDefinitions.Add(new RowDefinition());
        }

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                SetCell(i, j, data[i][j]);
            }
        }

        var title = new TextBlock
        {
            Text = "Game\n",
            FontSize = 18

        };

        this.Content = new StackPanel
        {
            Children = { title, grid },
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center
        };
    }

    public void SetCell(int x, int y, char symbol)
    {
        var cell = new Border
                {
                Background = Brushes.White,
                BorderBrush = Brushes.Black,
                Child = new TextBlock
                {
                    Text = symbol.ToString(),
                    FontSize = 16,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            };

            // Устанавливает позицию в сетке
            Grid.SetRow(cell, x);
            Grid.SetColumn(cell, y);
            grid.Children.Add(cell);
    }
}
