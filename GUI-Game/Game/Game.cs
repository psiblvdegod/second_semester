using System.Data;

namespace Game;

public class Game
{
    public Entity player;

    public List<Entity> enemies = [];

    public readonly char[][] map;

    public Game()
    {
        player = new(Preferences.InitialPosition, Preferences.PlayerSymbol);
        map = new char[Preferences.MapHeight][];
        for (var k = 0; k < Preferences.MapHeight; ++k)
        {
            map[k] = new char[Preferences.MapWidth];
        }

        FillMap();

        void FillMap()
        {
            for (var i = 0; i < map.GetLength(0); ++i)
            {
                for (var j = 0; j < map[i].Length; ++j)
                {
                    map[i][j] = Preferences.SpaceSymbol;
                }
            }

            for (var i = 0; i < map.GetLength(0); ++i)
            {
                map[i][0] = Preferences.BorderSymbol;
                map[i][^1] = Preferences.BorderSymbol;
            }
            for (var i = 0; i < map[0].Length; ++i)
            {
                map[0][i] = Preferences.BorderSymbol;
            }
            for (var i = 0; i < map[^1].Length; ++i)
            {
                map[^1][i] = Preferences.BorderSymbol;
            }

            map[player.Position.y][player.Position.x] = Preferences.PlayerSymbol;
        }
    }

    public bool MoveUp(Entity entity)
        => Move(entity, (entity.Position.x, entity.Position.y - 1));

    public bool MoveLeft(Entity entity)
        => Move(entity, (entity.Position.x - 1, entity.Position.y));

    public bool MoveDown(Entity entity)
        => Move(entity, (entity.Position.x, entity.Position.y + 1));

    public bool MoveRight(Entity entity)
        => Move(entity, (entity.Position.x + 1, entity.Position.y));

    private char GetMapCell((int x, int y) Position)
    {
        (int x, int y) = Position;

        if (y < 0 || x < 0)
        {
            return Preferences.BorderSymbol;
        }
        if (y >= map.GetLength(0) || x >= map[y].Length)
        {
            return Preferences.BorderSymbol;
        }

        return map[y][x];
    }

    private bool Move(Entity entity, (int x, int y) pos)
    {
        var cell = GetMapCell(pos);

        if (cell == Preferences.SpaceSymbol)
        {
            map[pos.y][pos.x] = entity.Name;
            map[entity.Position.y][entity.Position.x] = Preferences.SpaceSymbol;
            entity.Position = pos;
            return true;
        }
        
        return false;
    }

    public Direction MoveRandom(Entity entity)
    {
        return (new Random().Next() % 5) switch
        {
            0 => MoveUp(entity) ? Direction.up : Direction.none,
            1 => MoveLeft(entity) ? Direction.left : Direction.none,
            2 => MoveDown(entity) ? Direction.down : Direction.none,
            3 => MoveRight(entity) ? Direction.right : Direction.none,
            _ => Direction.none,
        };
    }

    public enum Direction
    {
        up = 0,
        left = 1,
        down = 2,
        right = 3,
        none = 4,
    }

    public (int x, int y) AddEnemy()
    {
        var rand = new Random();
        var x = (rand.Next() % (Preferences.MapWidth - 2)) + 1;
        var y = (rand.Next() % (Preferences.MapHeight - 2)) + 1;
        
        var cell = map[y][x];

        if (cell == Preferences.SpaceSymbol)
        {
            enemies.Add(new((x, y), Preferences.EnemySymbol));
            map[y][x] = Preferences.EnemySymbol;
            return (x, y);
        }

        return default;
    }

    /*
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
    */
}
