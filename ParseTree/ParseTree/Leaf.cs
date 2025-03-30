namespace ParseTree;

public class Leaf(int data) : Node
{
    private readonly int data = data;

    public override int Calculate()
        => data;
}
