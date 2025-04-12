using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Layout;
using static Game.UIInitialization;

namespace Game;

public class Game : IMove
{
    private Control character = CreateCharacter();

    private (int x, int y) Position = (10, 10);

    public Game(MainWindow window)
    {
        this.Window = window;
        window.SetCell(Position.x, Position.y, character);
        this.Window.AddButtons(CreatePanel());
    }

    private MainWindow Window;

    public void MoveUp()
    {
        Window.SetCell(Position.x, Position.y, CreateSpace());
        --Position.y;
        Window.SetCell(Position.x, Position.y, character);
    }
    public void MoveLeft()
    {
        Window.SetCell(Position.x, Position.y, CreateSpace());
        --Position.x;
        Window.SetCell(Position.x, Position.y, character);
    }

    public void MoveDown()
    {
        Window.SetCell(Position.x, Position.y, CreateSpace());
        ++Position.y;
        Window.SetCell(Position.x, Position.y, character);
    }
    public void MoveRight()
    {
        Window.SetCell(Position.x, Position.y, CreateSpace());
        ++Position.x;
        Window.SetCell(Position.x, Position.y, character);
    }

    public void KeyHandler(object? sender, KeyEventArgs args)
    {
        switch (args.Key)
        {
            case Key.W:
                MoveUp();
            break;
            case Key.A:
                MoveLeft();
            break;
            case Key.S:
                MoveDown();
            break;
            case Key.D:
                MoveRight();
            break;
        }
    }

    public void ButtonHandler(object? sender, RoutedEventArgs args)
    {
        if (sender is Button button)
        {
            switch (button.Name)
            {
                case "W":
                    MoveUp();
                break;
                case "A":
                    MoveLeft();
                break;
                case "S":
                    MoveDown();
                break;
                case "D":
                    MoveRight();
                break;
            }
        }
    }

    public StackPanel CreatePanel()
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
    }

    public Button CreateButton(string? name)
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