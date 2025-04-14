using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
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

        var current = this.Window.PopCell(x, y);
        var next = this.Window.PopCell(x, y - 1);

        if (current is null)
        {
            throw new InvalidOperationException("current cell is null when moveup");
        }

        if (next is null)
        {
            this.Window.SetCell(x, y - 1, current);
            --entity.Position.y;
            return;
        }

        if (next.Name != "SPACE")
        {
            this.Window.SetCell(x, y, current);
            this.Window.SetCell(x, y - 1, next);
            return;
        }

        this.Window.SetCell(x, y, next);
        this.Window.SetCell(x, y - 1, current);
        --entity.Position.y;
    }

    public void MoveLeft(Entity entity)
    {
        int x = entity.Position.x;
        int y = entity.Position.y;

        var current = this.Window.PopCell(x, y);
        var next = this.Window.PopCell(x - 1, y);

        if (current is null)
        {
            throw new InvalidOperationException("current cell is null when moveup");
        }

        if (next is null)
        {
            this.Window.SetCell(x - 1, y, current);
            --entity.Position.x;
            return;
        }

        if (next.Name != "SPACE")
        {
            this.Window.SetCell(x, y, current);
            this.Window.SetCell(x - 1, y, next);
            return;
        }

        this.Window.SetCell(x, y, next);
        this.Window.SetCell(x - 1, y, current);
        --entity.Position.x;
    }

    public void MoveDown(Entity entity)
    {
        int x = entity.Position.x;
        int y = entity.Position.y;

        var current = this.Window.PopCell(x, y);
        var next = this.Window.PopCell(x, y + 1);

        if (current is null)
        {
            throw new InvalidOperationException("current cell is null when moveup");
        }

        if (next is null)
        {
            this.Window.SetCell(x, y + 1, current);
            ++entity.Position.y;
            return;
        }

        if (next.Name != "SPACE")
        {
            this.Window.SetCell(x, y, current);
            this.Window.SetCell(x, y + 1, next);
            return;
        }

        this.Window.SetCell(x, y, next);
        this.Window.SetCell(x, y + 1, current);
        ++entity.Position.y;
    }

    public void MoveRight(Entity entity)
    {
        int x = entity.Position.x;
        int y = entity.Position.y;

        var current = this.Window.PopCell(x, y);
        var next = this.Window.PopCell(x + 1, y);

        if (current is null)
        {
            throw new InvalidOperationException("current cell is null when moveup");
        }

        if (next is null)
        {
            this.Window.SetCell(x + 1, y, current);
            ++entity.Position.x;
            return;
        }

        if (next.Name != "SPACE")
        {
            this.Window.SetCell(x, y, current);
            this.Window.SetCell(x + 1, y, next);
            return;
        }

        this.Window.SetCell(x, y, next);
        this.Window.SetCell(x + 1, y, current);
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

         CreateEnemy();
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

    public void CreateEnemy()
    { 
        var zombie = CreateZombie();

        this.Window.PopCell(zombie.Position.x, zombie.Position.y);
        this.Window.SetCell(zombie.Position.x, zombie.Position.y, zombie);
    }

    public void MoveRandom()
    {

    }
}