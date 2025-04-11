using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using Tmds.DBus.Protocol;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using UI;
using Avalonia.Input;
using Avalonia.Interactivity;
using Game;

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

        this.Content = new StackPanel
        {
            Children = { grid, CreateButtons() },
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
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

    private StackPanel CreateButtons()
    {
        var stackPanel = new StackPanel
        {
            Orientation = Orientation.Horizontal,
            Spacing = 20,
        };

        var dataForButton = "WASD";

        foreach (var c in dataForButton)
        {
            var button = new Button
            {
                Content = c,
                Width = 50,
                Height = 50,
                Background = Brushes.Black, 
                Foreground = Brushes.White  
            };

            stackPanel.Children.Add(button);
        }

        return stackPanel;
    }

    public void SubButtons(EventHandler<RoutedEventArgs> handler)
    {
        foreach(var c in ((StackPanel)this.Content).Children)
        {
            if (c is Button button)
            {
                button.Click += handler;
            }
        }
    }
}
