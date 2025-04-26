namespace SkipList;

public class SkipList<T> where T : IComparable
{
    SortedLinkLists<T> root = new();

    public void Add(T item)
    {
        var node = new Node<T>(item);

        RecCall(root.List);

        void RecCall(Node<T>? current)
        {
            if (current is null)
            {
                return;
            }

            if (current.Next != null && item.CompareTo(current.Next.Item) > 0)
            {
                RecCall(current.Next);      
            }
            else
            {
                RecCall(current.Down);

                if (current.Down is null)
                {
                    node.Next = current.Next;
                    current.Next = node;
                }
            } 
        }
    }

    public bool Contains(T item)
    {
        return RecCall(root.List);

        bool RecCall(Node<T>? current)
        {
            if (current is null)
            {
                return false;
            }

            if (Equals(item, current.Item))
            {
                return true;
            }

            if (current.Next != null && item.CompareTo(current.Item) > 0)
            {
                return RecCall(current.Next);
            }
            else
            {
                return RecCall(current.Down);
            }
        }
    }
}
