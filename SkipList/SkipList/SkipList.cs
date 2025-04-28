namespace SkipList;

public class SkipLists<T> where T : IComparable
{
    private int maxHeight = 0;

    private Node<T> root = new();

    public int Count { get; private set; } = 0;

    public void Add(T item)
    {
        var prev = Prepare();

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
                    prev.Dequeue();
                }

                prev.Enqueue(current);

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

        foreach (var left in prev.Reverse())
        {
            right = new(right.Item)
            {
                Down = right,
                Next = left.Next,
            };

            left.Next = right;
        }

        Queue<Node<T>> Prepare()
        {
            ++Count;

            var d = Math.Log2(Count);

            if (Math.Abs(double.Floor(d) - d) < 1e-10)
            {
                ++maxHeight;
                LevelUp();
            }

            var height = 1;
            for (var i = 2; i < maxHeight; ++i)
            {
                if (Count % (int)Math.Pow(2, i) == 0)
                {
                    height = i;
                }
            }

            return new Queue<Node<T>>(height);
        }
    }

    private void LevelUp()
    {
        root = new(root.Item)
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