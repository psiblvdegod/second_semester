using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using static Game.UIElements;

namespace Game;

public class Game(MainWindow window)
{
    public void Run()
    {
        this.Window.SetCell(character.Position.x, character.Position.y, character);

        this.Window.KeyDown += KeyHandler;

        this.Window.AddButtons(CreateMovementPanel(ButtonHandler));
    }

    private MainWindow Window = window;

    private Entity character = CreateCharacter();

    public void MoveUp(Entity entity)
    {
        int x = entity.Position.x;
        int y = entity.Position.y;

        Window.PopCell(x, y);
        var cell = Window.PopCell(x, y - 1);

        if (cell is not null)
        {
            Window.SetCell(x, y, cell);
        }

        Window.SetCell(x, y - 1, character);

        --entity.Position.y;
    }

    public void MoveLeft(Entity entity)
    {
        int x = entity.Position.x;
        int y = entity.Position.y;

        Window.PopCell(x, y);
        var cell = Window.PopCell(x - 1, y);

        if (cell is not null)
        {
            Window.SetCell(x, y, cell);
        }

        Window.SetCell(x - 1, y, character);

        --entity.Position.x;
    }

    public void MoveDown(Entity entity)
    {
        int x = entity.Position.x;
        int y = entity.Position.y;

        Window.PopCell(x, y);
        var cell = Window.PopCell(x, y + 1);

        if (cell is not null)
        {
            Window.SetCell(x, y, cell);
        }

        Window.SetCell(x, y + 1, character);

        ++entity.Position.y;
    }

    public void MoveRight(Entity entity)
    {
        int x = entity.Position.x;
        int y = entity.Position.y;

        Window.PopCell(x, y);
        var cell = Window.PopCell(x + 1, y);

        if (cell is not null)
        {
            Window.SetCell(x, y, cell);
        }

        Window.SetCell(x + 1, y, character);

        ++entity.Position.x;
    }

    public void KeyHandler(object? sender, KeyEventArgs args)
    {
        switch (args.Key)
        {
            case Key.W:
                MoveUp(character);
            break;
            case Key.A:
                MoveLeft(character);
            break;
            case Key.S:
                MoveDown(character);
            break;
            case Key.D:
                MoveRight(character);
            break;
        }

        // CreateEnemy();
    }

    
    public void ButtonHandler(object? sender, RoutedEventArgs args)
    {
        if (sender is Button button)
        {
            switch (button.Name)
            {
                case "W":
                    MoveUp(character);
                break;
                case "A":
                    MoveLeft(character);
                break;
                case "S":
                    MoveDown(character);
                break;
                case "D":
                    MoveRight(character);
                break;
            }
        }
    }

    // TODO
    public void CreateEnemy()
    { 
        var zombie = CreateZombie();

        this.Window.PopCell(zombie.Position.x, zombie.Position.y);
        this.Window.SetCell(zombie.Position.x, zombie.Position.y, zombie);
    }
}