namespace SkipList;

public class SkipLists<T> where T : IComparable
{
    private Node<T> root = new();

    public int Count { get; private set; } = 0;

    public void Add(T item)
    {
        ++Count;
        
        var height = Count % 2 + 1;

        List<Node<T>> prev = new (height); 

        Node<T>? newNode = new(item);

        var current = root;

        while (true)
        {
            if (newNode is null)
            {
                throw new();
            }

            if (current.Next is not null && item.CompareTo(current.Next.Item) >= 0)
            {
                current = current.Next;
            }
            else if (current.Down is not null)
            {
                if (prev.Count == prev.Capacity)
                {
                    prev.RemoveAt(0);
                }

                prev.Add(current);

                current = current.Down;                
            }
            else
            {
                newNode.Next = current.Next;
                current.Next = newNode;
                break;
            }
        }

        var right = newNode;

        prev.Reverse();

        foreach (var left in prev)
        {
            right = new(right.Item)
            {
                Down = right,
                Next = left.Next,
            };

            left.Next = right;
        }
    }

    public void AddLevel()
    {
        root = new()
        {
            Down = root,
        };
    }

    public bool Contains(T item)
    {
        return RecCall(root);

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

            if (current.Next != null && item.CompareTo(current.Item) >= 0)
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