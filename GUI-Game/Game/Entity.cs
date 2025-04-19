namespace Game;

public class Entity((int x, int y) position, char name)
{
    public (int x, int y) Position {get; set;} = position;

    public char Name {get; set;} = name;
}
