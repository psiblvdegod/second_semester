namespace SkipList;

public class SkipList<T> where T : IComparable
{
    private int maxHeight = 0;

    private Node<T> root = new();

    public int Count { get; private set; } = 0;

    public void Add(T item)
    {
        var height = CalculateHeight();
        var path = height > 1 ? new Node<T>[height] : null;
        Node<T> newNode = new(item);

        RecCall(root);

        TieWithPath(path, newNode);

        void RecCall(Node<T>? current)
        {
            if (current is null)
            {
                return;
            }
            if (current.Next is not null && item.CompareTo(current.Item) >= 0)
            {
                RecCall(current.Next);
            }
            else if (current.Down is not null)
            {
                AddToPath(path, current);

                RecCall(current.Down);
            }
            else
            {
                newNode.Next = current.Next;
                current.Next = newNode;
                return;
            }
        }

        void TieWithPath(Node<T>[]? path, Node<T> node)
        {
            if (path is null)
            {
                return;
            }

            var right = node;

            foreach (var left in path)
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

        void AddToPath(Node<T>[]? path, Node<T> node)
        {
            if (path is null)
            {
                return;
            }

            for (var i = path.Length - 1; i > 0; --i)
            {
                path[i] = path[i - 1];
            }

            path[0] = node;
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