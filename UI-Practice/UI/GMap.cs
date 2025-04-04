
using Avalonia.Controls.Notifications;

namespace UI;

public class GMap((int x, int y) position, MainWindow window) : Game.IMove
{
    private (int x, int y) Position = position;

    private MainWindow window = window;

    public void MoveDown()
    {
       window.SetCell(Position.x, Position.y, ' ');
       window.SetCell(Position.x, Position.y + 1, '@');
       ++this.Position.y;
    }

    public void MoveLeft()
    {
        throw new NotImplementedException();
    }

    public void MoveRight()
    {
        throw new NotImplementedException();
    }

    public void MoveUp()
    {
        throw new NotImplementedException();
    }
}
