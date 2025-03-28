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

        Start += CLI.Clear;
        Start += map.Print;
        Start += CLI.SetCursor;

        Left += map.MoveLeft;
        Left += CLI.MoveLeft;

        Right += map.MoveRight;
        Right += CLI.MoveRight;

        Down += map.MoveDown;
        Down += CLI.MoveDown;

        Up += map.MoveUp;
        Up += CLI.MoveUp;
    }

    public void Run()
    {
        Start();

        while (true)
        {
            var key = Console.ReadKey().Key;

            // var key = ConsoleKey.RightArrow;

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

                case ConsoleKey.Spacebar:
                    End();
                return;
            }
        }
    }
}
