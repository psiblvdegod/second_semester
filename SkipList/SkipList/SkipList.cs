namespace SkipList;

public class SkipLists<T> where T : IComparable
{
    private int maxHeight = 0;

    private Node<T> root = new();

    public int Count { get; private set; } = 0;

    public void Add(T item)
    {
        var height = CalculateHeight();
        Queue<Node<T>>? path = height > 1 ? new(height) : null;
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
                if (path is not null)
                {
                    if (path.Count == path.Capacity)
                    {
                        path.Dequeue();
                    }

                    path.Enqueue(current);
                }

                current = current.Down;                
            }
            else
            {
                newNode.Next = current.Next;
                current.Next = newNode;
                break;
            }
        }

        if (path is not null)
        {
            var right = newNode;

            foreach (var left in path.Reverse())
            {
                right = new(right.Item)
                {
                    Down = right,
                    Next = left.Next,
                };

                left.Next = right;
            }
        }

        int CalculateHeight()
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

            return height;
        }

        void LevelUp()
        {
            root = new(root.Item)
            {
                Down = root,
            };
        }
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