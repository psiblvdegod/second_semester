namespace Game;

public class Game
{
    public Entity player = new(Preferences.InitialPosition, Preferences.PlayerSymbol);

    public List<Entity> enemies = [];

    public readonly char[][] map;

    public Stats stats = new(); // STATS

    public Game()
    {
        // allocation
        map = new char[Preferences.MapHeight][];

        for (var k = 0; k < Preferences.MapHeight; ++k)
        {
            map[k] = new char[Preferences.MapWidth];
        }
    
        // spaces
        for (var i = 0; i < Preferences.MapHeight; ++i)
        {
            for (var j = 0; j < map[i].Length; ++j)
            {
                map[i][j] = Preferences.SpaceSymbol;
            }
        }

        // borders
        for (var i = 0; i < Preferences.MapHeight; ++i)
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

        // player
        map[player.Position.y][player.Position.x] = Preferences.PlayerSymbol;
    }

    public bool MoveUp(Entity entity)
        => Move(entity, (entity.Position.x, entity.Position.y - 1));

    public bool MoveLeft(Entity entity)
        => Move(entity, (entity.Position.x - 1, entity.Position.y));

    public bool MoveDown(Entity entity)
        => Move(entity, (entity.Position.x, entity.Position.y + 1));

    public bool MoveRight(Entity entity)
        => Move(entity, (entity.Position.x + 1, entity.Position.y));

    private char GetMapCell(int x, int y)
    {
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
        var cell = GetMapCell(pos.x, pos.y);

        if (cell != Preferences.SpaceSymbol)
        {
            return false;
        }
        if (entity.Name == Preferences.PlayerSymbol) // STATS
        {
            ++stats.Moves;
        }

        Swap();
        return true;
        
        void Swap()
        {
            map[pos.y][pos.x] = entity.Name;
            map[entity.Position.y][entity.Position.x] = Preferences.SpaceSymbol;
            entity.Position = pos;
        }
    }

    public bool MoveRandom(Entity entity)
    {
        return (new Random().Next() % 5) switch
        {
            0 => MoveUp(entity),
            1 => MoveLeft(entity),
            2 => MoveDown(entity),
            3 => MoveRight(entity),
            _ => false,
        };
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

    public class Stats // STATS
    {
        public int Kills { get; set; }

        public int Moves { get; set; }
    }
}
