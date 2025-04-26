namespace SkipList;

public class SortedLinkLists<T> where T : IComparable
{
    public SortedLinkLists<T>? Next;

    public Node<T>? Head;

    public void Add(Node<T> node)
    {
        Head = RecCall(Head);
        
        Node<T>? RecCall(Node<T>? current)
        {
            if (current is null)
            {
                return node;
            }

            if (node.Item.CompareTo(current.Item) <= 0)
            {
                node.Next = current;
                return node;
            }
            else
            {
                current.Next = RecCall(current.Next);
                return current;
            }
        }
    }

    public Node<T>? FindBigger(T item)
    {
        return RecCall(Head);

        Node<T>? RecCall(Node<T>? current)
        {
            if (current is null || item.CompareTo(current.Item) < 0)
            {
                return current;
            }

            return RecCall(current.Next);
        }
    }
}
