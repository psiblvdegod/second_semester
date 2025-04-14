using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace Game;

/// <summary>
/// some static methods creating configured ui stuff.
/// </summary>
public static class UIElements
{
    public static Grid CreateGrid()
    {
        var grid = new Grid();

        for (int i = 0; i < Preferences.MapSize; i++)
        {
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(Preferences.CellSize) });
        }

        for (int j = 0; j < Preferences.MapSize; j++)
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(Preferences.CellSize) });
        }

        return grid;
    }

    public static Entity CreateCharacter()
    {
        var character = new Entity()
        {
            Name = "SF",
            Position = Preferences.InitialPosition,
            Height = Preferences.CellSize,
            Width = Preferences.CellSize,
            Source = new Bitmap("./Images/sf.jpg"),
        };

        return character;
    }

    public static Control CreateSpace()
    {
        var control = new Control
        {
            Name = Preferences.SpaceName,
            Height = Preferences.CellSize,
            Width = Preferences.CellSize,
        };

        return control;
    }

    public static Entity CreateZombie()
    {
        var rand = new Random();
        var zombie = new Entity
        {
            Name = "ZOMBIE",
            Height = Preferences.CellSize,
            Width = Preferences.CellSize,
            Source = new Bitmap("./Images/Zombie.jpg"),
            Position =
                (rand.Next() % Preferences.MapSize, rand.Next() % Preferences.MapSize),
        };

        return zombie;
    }

    // creates panel and subs handler to it
    public static StackPanel CreateMovementPanel(EventHandler<RoutedEventArgs> ButtonHandler)
    {
        var w = CreateButton("W");
        var a = CreateButton("A");
        var s = CreateButton("S");
        var d = CreateButton("D");

        var panel = new StackPanel
        {
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Bottom,
            Orientation = Orientation.Horizontal,
            Children = {w,a,s,d},
        };

        return panel;

        Button CreateButton(string? name)
        {
            var button = new Button
            {
                Height = 50,
                Width = 50,
                Background = Brushes.LightPink,
                Name = name,
                BorderBrush = Brushes.Black,
                Content = name,
            };

            button.Click += ButtonHandler;

            return button;
        }
    }
}
