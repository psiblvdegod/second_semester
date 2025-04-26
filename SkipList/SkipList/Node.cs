namespace SkipList;

public class Node<T>(T? item = default)
{
    public T? Item { get; } = item;

    public Node<T>? Next;

    public Node<T>? Down;
}
