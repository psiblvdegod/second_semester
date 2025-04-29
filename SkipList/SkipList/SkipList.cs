using System.Collections;

namespace SkipList;

public class SkipList<T> where T : IComparable
{
    private int MaxHeight { get; set; } = 0;

    private Node<T> root = new();

    public int Count { get; private set; } = 0;

    public void Add(T item)
    {
        var path = CreatePath(CalculateHeight());
        Node<T> newNode = new(item);

        RecCall(root);

        void RecCall(Node<T> current)
        {
            if (current.Next is not null && item.CompareTo(current.Next.Item) >= 0)
            {
                RecCall(current.Next);
            }
            else if (current.Down is not null)
            {
                AddToPath(current);
                RecCall(current.Down);
            }
            else
            {
                newNode.Next = current.Next;
                current.Next = newNode;
                return;
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

            foreach (var guardian in path)
            {
                node = new(node.Item)
                {
                    Down = node,
                    Next = guardian.Next,
                };

                guardian.Next = node;
            }
        }

        int CalculateHeight()
        {
            ++Count;

            var height = Math.Log2(Count);

            if (Math.Abs(double.Floor(height) - height) < 1e-10)
            {
                ++MaxHeight;

                root = new(root.Item)
                {
                    Down = root,
                };
            }

            for (var i = MaxHeight; i > 1; --i)
            {
                if ((Count % Math.Pow(2, i)) < 1e-10)
                {
                    return i;
                }
            }

            return 1;
        }
    }

    public bool Contains(T item) 
    {
        return RecCall(root);

        bool RecCall(Node<T> current)
        {
            if (current.Next is not null)
            {
                var difference = item.CompareTo(current.Next.Item);

                if (difference == 0)
                {
                    return true;
                }
                else if (difference > 0)
                {
                    return RecCall(current.Next);
                }
            }
            if (current.Down is not null)
            {
                return RecCall(current.Down);
            }
            else
            {
                return false;
            }
        }
    }

    public void Remove(T item)
    {
        RecCall(root);

        void RecCall(Node<T> current)
        {
            if (current.Next is not null)
            {
                var difference = item.CompareTo(current.Next.Item);

                if (difference == 0)
                {
                    current.Next = current.Next.Next;

                    if (current.Down is not null)
                    {
                        RecCall(current.Down);
                    }
                }
                else if (difference < 0 && current.Down is not null)
                {
                    RecCall(current.Down);
                }
                else
                {
                    RecCall(current.Next);
                }
            }
            else if (current.Down is not null)
            {
                RecCall(current.Down);
            }
        }
    }
}