using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using static Game.UIInitialization;

namespace Game;

public class Game(MainWindow window) : IMove
{
    public void Run()
    {
        this.Window.SetCell(Position.x, Position.y, character);

        this.Window.KeyDown += KeyHandler;

        this.Window.AddButtons(CreateMovementPanel(ButtonHandler));
    }

    private MainWindow Window = window;

    private Control character = CreateCharacter();

    private (int x, int y) Position = Preferences.InitialPosition;


    public void MoveUp()
    {
        Window.PopCell(Position.x, Position.y);
        var cell = Window.PopCell(Position.x, Position.y - 1);

        if (cell is not null)
        {
            Window.SetCell(Position.x, Position.y, cell);
        }

        Window.SetCell(Position.x, Position.y - 1, character);

        --Position.y;
    }

    public void MoveLeft()
    {
        Window.PopCell(Position.x, Position.y);
        var cell = Window.PopCell(Position.x - 1, Position.y);

        if (cell is not null)
        {
            Window.SetCell(Position.x, Position.y, cell);
        }

        Window.SetCell(Position.x - 1, Position.y, character);

        --Position.x;
    }

    public void MoveDown()
    {
        Window.PopCell(Position.x, Position.y);
        var cell = Window.PopCell(Position.x, Position.y + 1);

        if (cell is not null)
        {
            Window.SetCell(Position.x, Position.y, cell);
        }

        Window.SetCell(Position.x, Position.y + 1, character);

        ++Position.y;
    }

    public void MoveRight()
    {
        Window.PopCell(Position.x, Position.y);
        var cell = Window.PopCell(Position.x + 1, Position.y);

        if (cell is not null)
        {
            Window.SetCell(Position.x, Position.y, cell);
        }

        Window.SetCell(Position.x + 1, Position.y, character);

        ++Position.x;
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
}