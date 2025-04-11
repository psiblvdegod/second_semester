namespace UI;

public class GMap((int x, int y) position, MainWindow window) : Game.IMove
{
    private (int x, int y) Position = position;

    private MainWindow window = window;

    public void MoveDown()
    {
       window.SetCell(Position.x, Position.y, ' ');
       window.SetCell(Position.x + 1, Position.y, '@');
       ++this.Position.x;
    }

    public void MoveLeft()
    {
        window.SetCell(Position.x, Position.y, ' ');
        window.SetCell(Position.x, Position.y - 1, '@');
        --this.Position.y;
    }

    public void MoveRight()
    {
        window.SetCell(Position.x, Position.y, ' ');
        window.SetCell(Position.x, Position.y + 1, '@');
        ++this.Position.y;
    }

    public void MoveUp()
    {
        window.SetCell(Position.x, Position.y, ' ');
        window.SetCell(Position.x - 1, Position.y, '@');
        --this.Position.x;
    }
}
