namespace ParseTree;

public class Operator<T>(Func<T,T,T> operation) : Node<T>
{
    Func<T,T,T> Operation { get; } = operation;
    Node<T> LeftChild {get; set;}
    Node<T> RightChild {get; set;}

    public override T Calculate()
        => Operation(LeftChild.Calculate(), RightChild.Calculate());
}
