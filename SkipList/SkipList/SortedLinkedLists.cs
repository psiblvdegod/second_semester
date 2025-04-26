namespace SkipList;

public class SortedLinkLists<T> where T : IComparable
{
    public SortedLinkLists<T>? NextList;

    public Node<T>? List;

    public void Add(Node<T> node)
    {
        List = RecCall(List);
        
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
