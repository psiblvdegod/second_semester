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
        Console.WriteLine(args.Key);
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
            
        }
    }
}