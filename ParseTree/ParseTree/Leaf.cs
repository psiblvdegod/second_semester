namespace ParseTree;

public class Leaf<T>(T data) : Node<T>
{
    private readonly T data = data;

    public override T Calculate()
        => data;
}
