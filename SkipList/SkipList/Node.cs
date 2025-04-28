namespace SkipList;

public class Node<T>
{
    public Node(T? item = default)
    {
        ++Count;
        ID = Count;
        Item = item;
    }
    private static int Count = 0;

    public int ID;

    public T? Item { get; }

    public Node<T>? Next;

    public Node<T>? Down;
}
