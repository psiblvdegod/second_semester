using System.Runtime.Versioning;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace Game;

public class Game : ICharacter
{
    public static readonly string Obstructions = "_-+|";

    private int x = 1;
    private int y = 1;

    public (int x, int y) Position
    {
        get => (this.x, this.y);
    }

    private char[][] Map;

    public Game(string map)
    {
        var data = map.Split('\n');

        Map = new char[data.Length][];

        for (int i = 0; i < data.Length; ++i)
        {
            Map[i] = data[i].ToCharArray();
        }
    }
    
    public void PrintMap()
    {
        foreach (var line in Map)
        {
            Console.WriteLine(line);
        }
    }

    public void MoveUp()
    {
        if (this.Position.x == 0)
        {
            throw new InvalidOperationException("attempt to go beyond the map.");
        }
        if (Obstructions.Contains(Map[y][x - 1]))
        {
            throw new InvalidOperationException("attempt to go throw the wall.");
        }

        (Map[x][y], Map[x - 1][y]) = (Map[x - 1][y], Map[x][y]);

        this.x--;
    }

    public void MoveDown()
    {
        if (this.Position.x == Map[this.Position.y].Length - 1)
        {
            throw new InvalidOperationException("attempt to go beyond the map.");
        }
        if (Obstructions.Contains(Map[y][x + 1]))
        {
            throw new InvalidOperationException("attempt to go throw the wall.");
        }

        (Map[x][y], Map[x + 1][y]) = (Map[x + 1][y], Map[x][y]);

        ++this.x;
    }

    public void MoveLeft()
    {
        if (this.Position.y == 0)
        {
            throw new InvalidOperationException("attempt to go beyond the map.");
        }
        if (Obstructions.Contains(Map[y - 1][x]))
        {
            throw new InvalidOperationException("attempt to go throw the wall.");
        }

        (Map[x][y], Map[x][y - 1]) = (Map[x][y - 1], Map[x][y]);


        --this.y;
    }

    public void MoveRight()
    {
        if (this.Position.y == this.Map.Length - 1)
        {
            throw new InvalidOperationException("attempt to go beyond the map.");
        }
        if (Obstructions.Contains(Map[y + 1][x]))
        {
            throw new InvalidOperationException("attempt to go throw the wall.");
        }

        (Map[x][y], Map[x][y + 1]) = (Map[x][y + 1], Map[x][y]);

        ++this.y;
    }

    public void Die()
    {
        if (this.Position.x == 0)
        {
            throw new InvalidOperationException("attempt to go beyond the map.");
        }
    }
}

