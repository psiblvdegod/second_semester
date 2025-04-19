using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace Game;

public class Game
{
    Entity player;

    List<Entity> enemies = [];

    char[][] map;

    public Game()
    {
        player = new(DefaultPreferences.InitialPosition, DefaultPreferences.PlayerSymbol);
        map = new char[DefaultPreferences.MapHeight][];
        for (var k = 0; k < DefaultPreferences.MapHeight; ++k)
        {
            map[k] = new char[DefaultPreferences.MapWidth];
        }

        FillMap();
        map[player.Position.y][player.Position.x] = '@';
        

        void FillMap()
        {
            for (var i = 0; i < map.GetLength(0); ++i)
            {
                for (var j = 0; j < map[i].Length; ++j)
                {
                    map[i][j] = ' ';
                }
            }

            for (var i = 0; i < map.GetLength(0); ++i)
            {
                map[i][0] = DefaultPreferences.BorderSymbol;
                map[i][^1] = DefaultPreferences.BorderSymbol;
            }
            for (var i = 0; i < map[0].Length; ++i)
            {
                map[0][i] = DefaultPreferences.BorderSymbol;
            }
            for (var i = 0; i < map[^1].Length; ++i)
            {
                map[^1][i] = DefaultPreferences.BorderSymbol;
            }
        }
    }

    private bool MoveUp(Entity entity)
        => Move(entity, (entity.Position.x, entity.Position.y - 1));

    private bool MoveLeft(Entity entity)
        => Move(entity, (entity.Position.x - 1, entity.Position.y));

    private bool MoveDown(Entity entity)
        => Move(entity, (entity.Position.x, entity.Position.y + 1));

    private bool MoveRight(Entity entity)
        => Move(entity, (entity.Position.x + 1, entity.Position.y));

    private char GetMapCell((int x, int y) Position)
    {
        (int x, int y) = Position;

        if (y < 0 || x < 0)
        {
            return '$';
        }
        if (y >= map.GetLength(0) || x >= map[y].Length)
        {
            return '$';
        }

        return map[y][x];
    }

    private bool Move(Entity entity, (int x, int y) pos)
    {
        switch (GetMapCell(pos))
        {
            case ' ':
                map[pos.y][pos.x] = entity.Name;
                map[entity.Position.y][entity.Position.x] = ' ';
                entity.Position = pos;
            return true;

            default:
            return false;
        }
    }

    public void Run()
    {
        while (true)
        {
            var key = Console.ReadKey();
            KeyHandler(key.Key);
            WriteMap();
        }
    }

    private void KeyHandler(ConsoleKey key)
    {
        Console.WriteLine("handler");
        switch (key)
        {
            case ConsoleKey.UpArrow:
                MoveUp(player);
            break;
            case ConsoleKey.LeftArrow:
                MoveLeft(player);
            break;
            case ConsoleKey.DownArrow:
                MoveDown(player);
            break;
            case ConsoleKey.RightArrow:
                MoveRight(player);
            break;
        }
    }

    private void WriteMap()
    {
        for (var i = 0; i < map.GetLength(0); ++i)
        {
            for (var j = 0; j < map[i].Length; ++j)
            {
                Console.Write(map[i][j]);
            }
            Console.Write('\n');
        }
    }
}
