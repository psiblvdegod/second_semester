namespace ParseTree;

public class Operator(Func<int, int, int> operation) : Node
{
    Func<int,int,int> Operation { get; } = operation;
    public Node? LeftChild {get; set;}
    public Node? RightChild {get; set;}

    public override int Calculate()
    {
        if (LeftChild is null || RightChild is null)
        {
            throw new InvalidOperationException();
        }
    
        return Operation(LeftChild.Calculate(), RightChild.Calculate());
    }
}
