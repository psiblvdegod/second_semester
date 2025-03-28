using System.Dynamic;
using System.Runtime.CompilerServices;

namespace Game;

public class Map : IMove
{
    public char[][] map { get; }

    public char Character { get; } = '@';

    public (int x, int y) Position{ get => (this.x, this.y); }

    private int x = 0;

    private int y = 0;

    public Map(string map)
    {
        var lines = map.Split('\n');

        this.map = new char[lines.Length][];

        for (var y = 0; y < lines.Length; ++y)
        {
            this.map[y] = new char[lines[y].Length];

            for (var x = 0; x < lines[y].Length; ++x)
            {
                var symbol = lines[y][x];

                this.map[y][x] = symbol;

                if (symbol == Character)
                {
                    this.x = x;
                    this.y = y;
                }
            }
        }
    }

    public void Print()
    {
        foreach (var line in map)
        {
            Console.WriteLine(line);
        }
    }

    public void MoveLeft()
    {
        (map[y][x - 1], map[y][x]) = (map[y][x], map[y][x - 1]);

        this.x--;
    }

    public void MoveRight()
    {
        (map[y][x + 1], map[y][x]) = (map[y][x], map[y][x + 1]);

        ++this.x;
    }

    public void MoveUp()
    {
        (map[y - 1][x], map[y][x]) = (map[y][x], map[y - 1][x]);

        --this.y;
    }

    public void MoveDown()
    {
        (map[y + 1][x], map[y][x]) = (map[y][x], map[y + 1][x]);

        ++this.y;
    }
}