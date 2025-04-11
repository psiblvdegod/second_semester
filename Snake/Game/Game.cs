using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Imaging;
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
    }
    public void MoveLeft()
    {
        throw new NotImplementedException();
    }

    public void MoveDown()
    {
        throw new NotImplementedException();
    }
    public void MoveRight()
    {
        throw new NotImplementedException();
    }
}