namespace SkipList;

public class SortedLinkLists<T> where T : IComparable
{
    public SortedLinkLists<T>? Next;

    public Node<T> Head = new();

    public void Add(Node<T> node)
    {
        Head.Next = RecCall(Head.Next);
        
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
}
