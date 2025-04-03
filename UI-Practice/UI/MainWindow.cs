// AI generated.

using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

class MainWindow : Window
{
    public MainWindow(char[][]? data)
    {
        this.Title = "zxc";
        this.Width = 600;
        this.Height = 400;

        var grid = new Grid();

        int maxColumns = data.Max(row => row.Length);
        
        // Добавляем столбцы
        for (int j = 0; j < maxColumns; j++)
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        // Добавляем строки
        for (int i = 0; i < data.Length; i++)
        {
            grid.RowDefinitions.Add(new RowDefinition());
        }

        // Заполняем Grid
        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                var cell = new Border
                {
                    Background = Brushes.White,
                    BorderBrush = Brushes.Black,
                    Child = new TextBlock
                    {
                        Text = data[i][j].ToString(),
                        FontSize = 16,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    }
                };
                Grid.SetRow(cell, i);
                Grid.SetColumn(cell, j);
                grid.Children.Add(cell);
            }
        }

        // Добавляем поясняющий текст
        var title = new TextBlock
        {
            Text = $"Массив {data.Length}x{maxColumns} (строк x столбцов)",
            FontSize = 18,
        };

        this.Content = new StackPanel
        {
            Children = { title, grid },
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center
        };
    }
}