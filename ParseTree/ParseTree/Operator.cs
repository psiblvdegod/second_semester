namespace ParseTree;

public class Operator(Func<int, int, int> operation, string token) : Node
{
    Func<int,int,int> Operation { get; } = operation;
    public Node? LeftChild { get; set; }
    public Node? RightChild { get; set; }
    private readonly string token = token;

    public override int Calculate()
    {
        if (LeftChild is null || RightChild is null)
        {
            throw new InvalidOperationException("operand is missing.");
        }
    
        return Operation(LeftChild.Calculate(), RightChild.Calculate());
    }

    public override void Print()
        => Console.WriteLine(this.token);
}
