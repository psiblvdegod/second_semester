using System.Security.Cryptography.X509Certificates;

namespace Game;

public class CLI((int x, int y) startPoint) : ICharacter
{
    public char Character { get; } = '@';

    private readonly int x = startPoint.x;

    private readonly int y = startPoint.y;

    public (int x, int y) Position { get => (this.x, this.y); }

   public void MoveRight()
    {
        --Console.CursorLeft;
        Console.Write(" ");
        Console.Write(Character);
    }

    public void MoveDown()
    {
        --Console.CursorLeft;
        Console.Write(" ");
        ++Console.CursorTop;
        --Console.CursorLeft;
        Console.Write(Character);
    }
    public void MoveLeft()
    {
        --Console.CursorLeft;
        Console.Write(" ");
        Console.CursorLeft -= 2;
        Console.Write(Character);
    }

    public void MoveUp()
    {
        --Console.CursorLeft;
        Console.Write(" ");
        Console.CursorTop--;
        Console.CursorLeft--;
        Console.Write(Character);
    }

    public void Clear()
        => Console.Clear();

    public void SetCursor()
    {
        Console.CursorLeft = this.x;
        Console.CursorTop = this.y;
    }
}