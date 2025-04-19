using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;

namespace UI;

public class App : Avalonia.Application
{
    private MainWindow? Window;

    private Game.Game? game;

    public override void OnFrameworkInitializationCompleted()
    {
        game = new();
        this.Window = new MainWindow(game.map);
        ConfigureDesktop();
        this.Window.KeyDown += KeyHandler;
    }

    private void ConfigureDesktop()
    {
        if (this.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = this.Window;
        }
        else
        {
            throw new NotSupportedException();
        }
    }

    private void KeyHandler(object? sender, KeyEventArgs args)
    {
        if (game is null || Window is null)
        {
            throw new();
        }

        var x = game.player.Position.x;
        var y = game.player.Position.y; 
        var key = args.Key;

        if (key == Key.W && game.MoveUp(game.player))
        {
            SwapCells((x, y), (x, y - 1));
        }
        else if (key == Key.A && game.MoveLeft(game.player))
        {
            SwapCells((x, y), (x - 1, y));
        }
        else if (key == Key.S && game.MoveDown(game.player))
        {
            SwapCells((x, y), (x, y + 1));
        }
        else if (key == Key.D && game.MoveRight(game.player))
        {
            SwapCells((x, y), (x + 1, y));
        }

        

        var newEnemyPos = game.AddEnemy();
        if (newEnemyPos != default)
        {
            Window.PopCell(newEnemyPos);
            Window.SetCell(newEnemyPos, Initialization.CreateEnemy());
        }

        MoveEnemies();
    }

    private void SwapCells((int x, int y) pos1, (int x, int y) pos2)
    {
        ArgumentNullException.ThrowIfNull(Window);

        var left = Window.PopCell(pos1);
        var right = Window.PopCell(pos2);

        if (left != null)
        {
            Window.SetCell(pos2, left);
        }
        if (right != null)
        {
            Window.SetCell(pos1, right);
        }
    }

    private void MoveEnemies()
    {
        ArgumentNullException.ThrowIfNull(game);

        foreach (var enemy in game.enemies)
        {
            var oldEnemyPos = enemy.Position;

            game.MoveRandom(enemy);
            
            SwapCells(oldEnemyPos, enemy.Position);
        }
    }
}
