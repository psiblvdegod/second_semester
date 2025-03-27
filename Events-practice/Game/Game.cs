using System.Runtime.Versioning;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace Game;

public class Game : ICharacter
{
    private int x;
    private int y;

    public (int x, int y) Position
    {
        get => (this.x, this.y);
    }

    private char[][] Map;


    public event Action Start;
    public event Action Left;
    public event Action Right;
    public event Action Up;
    public event Action Down;
    public event Action End;

    public Game(string map)
    {
        var data = map.Split('\n');

        Map = new char[data.Length][];

        for (int i = 0; i < data.Length; ++i)
        {
            Map[i] = data[i].ToCharArray();
        }

        for (var y = 0; y < Map.GetLength(0); ++y)
        {
            for (int x = 0; x < Map[y].Length; ++x)
            {
                if (Map[y][x] == '0')
                {
                    this.x = x;
                    this.y = y;
                }
            }
        }

        Left += this.MoveLeft;

        Left += this.PrintMap;

        Right += this.MoveRight;

        Right += this.PrintMap;

        Up += this.MoveUp;

        Up += this.PrintMap;

        Down += this.MoveDown;

        Down += this.PrintMap;

        Start += PrintMap;

        End += this.Die;
    }

    public void Run()
    {
        Start();

        while (true)
        {
            var key = Console.ReadKey().Key;

            switch (key)
            {
                case (ConsoleKey.LeftArrow):
                    Left();
                break;

                case (ConsoleKey.RightArrow):
                    Right();
                break;

                case (ConsoleKey.UpArrow):
                    Up();
                break;

                case (ConsoleKey.DownArrow):
                    Down();
                break;

                case (ConsoleKey.Spacebar):
                    End();
                return;
            }
        }
    }
    
    public void PrintMap()
    {
        foreach (var line in Map)
        {
            Console.WriteLine(line);
        }
    }

    public void MoveLeft()
    {
        if (this.Position.x == 0)
        {
            throw new InvalidOperationException("attempt to go beyond the map.");
        }
        if (Map[y][x - 1] != ' ')
        {
            throw new InvalidOperationException("attempt to go throw the wall.");
        }

        (Map[y][x - 1], Map[y][x]) = (Map[y][x], Map[y][x - 1]);

        this.x--;
    }

    public void MoveRight()
    {
        if (this.Position.x == Map[this.Position.y].Length - 1)
        {
            throw new InvalidOperationException("attempt to go beyond the map.");
        }
        if (Map[y][x + 1] != ' ')
        {
            throw new InvalidOperationException("attempt to go throw the wall.");
        }

        (Map[y][x + 1], Map[y][x]) = (Map[y][x], Map[y][x + 1]);

        ++this.x;
    }

    public void MoveUp()
    {
        if (this.Position.y == 0)
        {
            throw new InvalidOperationException("attempt to go beyond the map.");
        }
        if (Map[y - 1][x] != ' ')
        {
            throw new InvalidOperationException("attempt to go throw the wall.");
        }

        (Map[y - 1][x], Map[y][x]) = (Map[y][x], Map[y - 1][x]);

        --this.y;
    }

    public void MoveDown()
    {
        if (this.Position.y == this.Map.Length - 1)
        {
            throw new InvalidOperationException("attempt to go beyond the map.");
        }
        if (Map[y + 1][x] != ' ')
        {
            throw new InvalidOperationException("attempt to go throw the wall.");
        }

        (Map[y + 1][x], Map[y][x]) = (Map[y][x], Map[y + 1][x]);

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

