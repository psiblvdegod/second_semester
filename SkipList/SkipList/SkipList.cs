using System.Collections;

namespace SkipList;

public class SkipLists<T> where T : IComparable
{
    private int maxHeight = 0;

    private Node<T> root = new();

    public int Count { get; private set; } = 0;

    public void Add(T item)
    {
        var path = CreatePath(CalculateHeight());
        Node<T> newNode = new(item);

        var current = root;

        while (true)
        {
            if (current.Next is not null && item.CompareTo(current.Next.Item) >= 0)
            {
                current = current.Next;
            }
            else if (current.Down is not null)
            {
                AddToPath(current);

                current = current.Down;                
            }
            else
            {
                newNode.Next = current.Next;
                current.Next = newNode;
                break;
            }
        }

        LinkWithPath(newNode);

        Node<T>[]? CreatePath(int height)
            => height < 2 ? null : new Node<T>[height];

        void AddToPath(Node<T> node)
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

        void LinkWithPath(Node<T> node)
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

            var level = Math.Log2(Count);

            if (Math.Abs(double.Floor(level) - level) < 1e-10)
            {
                ++maxHeight;

                root = new(root.Item)
                {
                    Down = root,
                };
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
    }

    public bool Contains(T item) 
    {
        return RecCall(root);

        bool RecCall(Node<T> current)
        {
            if (Equals(item, current.Item))
            {
                return true;
            }
            else if (current.Next != null && item.CompareTo(current.Next.Item) >= 0)
            {
                return RecCall(current.Next);
            }
            else if (current.Down != null)
            {
                return RecCall(current.Down);
            }
            else
            {
                return false;
            }
        }
    }
}