using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
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
        var key = args.Key;

        if (key == Key.W)
        {
            this.MoveUp();
        }
        else if (key == Key.A)
        {
            this.MoveLeft();
        }
        else if (key == Key.S)
        {
            this.MoveDown();
        }
        else if (key == Key.D)
        {
            this.MoveRight();
        }
    }

    public void SubToButtons()
    {
        if (Window.Content is Panel panel)
        {
            foreach (var child in panel.Children)
            {
                if (child is StackPanel buttons)
                {
                    foreach (var subchild in buttons.Children)
                    {
                        if (subchild is Button button)
                        {
                            button.Click += ButtonHandler;
                            button.IsEnabled = true;
                        }
                    }
                }
            }
        }
    }

    public void ButtonHandler(object? sender, RoutedEventArgs args)
    {
        if (sender is Button button)
        {
            if (button.Content is char c)
            {
                switch (c)
                {
                    case 'W':
                        this.MoveUp();
                    break;
                    case 'A':
                        this.MoveLeft();
                    break;
                    case 'S':
                        this.MoveDown();
                    break;
                    case 'D':
                        this.MoveRight();
                    break;
                }
            }
        }
    }
}