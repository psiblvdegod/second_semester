using System.Security.Cryptography.X509Certificates;

namespace Game;

public class Validator(Map map) : IMove
{
    private int x { get => map.Position.x; }

    private int y { get => map.Position.y; }

    public void MoveDown()
    {
        if (y == map.map.GetLength(0))
        {
            throw new InvalidOperationException("attempt to go out of map");
        }

        if (map.map[y + 1][x] != ' ')
        {
            throw new InvalidOperationException("attemp to go throw the wall");
        }
    }

    public void MoveLeft()
    {
        if (x == 0)
        {
            throw new InvalidOperationException("attempt to go out of map");
        }

        if (map.map[y][x - 1] != ' ')
        {
            throw new InvalidOperationException("attemp to go throw the wall");
        }
    }

    public void MoveRight()
    {
        if (x == map.map[y].Length)
        {
            throw new InvalidOperationException("attempt to go out of map");
        }

        if (map.map[y][x + 1] != ' ')
        {
            throw new InvalidOperationException("attemp to go throw the wall");
        }
    }

    public void MoveUp()
    {
        if (y == 0)
        {
            throw new InvalidOperationException("attempt to go out of map");
        }

        if (map.map[y - 1][x] != ' ')
        {
            throw new InvalidOperationException("attemp to go throw the wall");
        }
    }
}