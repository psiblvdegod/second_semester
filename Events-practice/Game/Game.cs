namespace Game;

public class Game
{
    public event Action Start;
    public event Action End = () => { };
    public event Action Left;
    public event Action Right;
    public event Action Up;
    public event Action Down;

    public Game(string path)
    {
        var map = new Map(File.ReadAllText(path));

        var CLI = new CLI(map.Position);

        var validator = new Validator(map);

        Start += CLI.Clear;
        Start += map.Print;
        Start += CLI.SetCursor; // bad af

        Left += validator.MoveLeft;
        Left += map.MoveLeft;
        Left += CLI.MoveLeft;

        Right += validator.MoveRight;
        Right += map.MoveRight;
        Right += CLI.MoveRight;

        Down += validator.MoveDown;
        Down += map.MoveDown;
        Down += CLI.MoveDown;

        Up += validator.MoveUp;
        Up += map.MoveUp;
        Up += CLI.MoveUp;
    }

    public void Run()
    {
        Start();

        while (true)
        {
            var key = Console.ReadKey().Key;

            try
            {
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        Left();
                    break;

                    case ConsoleKey.RightArrow:
                        Right();
                    break;

                    case ConsoleKey.UpArrow:
                        Up();
                    break;

                    case ConsoleKey.DownArrow:
                        Down();
                    break;
                }
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}
