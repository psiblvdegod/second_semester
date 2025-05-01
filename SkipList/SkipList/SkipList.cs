namespace SkipList;

public class SkipList<T> where T : IComparable
{
    private int MaxHeight { get; set; } = 0;

    private Node<T> root = new();

    public int Count { get; private set; } = 0;

    public void Add(T item)
    {
        ++Count;
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
                node = new (node.Item)
                {
                    Down = node,
                    Next = guardian.Next,
                };

                guardian.Next = node;
            }
        }

        int CalculateHeight()
        {
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

    public void CopyTo(T[] array, int arrayIndex = 0)
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("list is empty");
        }

        if (Count + arrayIndex > array.Length)
        {
            throw new InvalidOperationException("array is to small to copy without resizing");
        }

        var current = GetTopOfBottomList(root);

        while (current is not null)
        {
            if (current.Item is null)
            {
                throw new Exception ("item in the list is null somehow");
            }

            array[arrayIndex] = current.Item;
            ++arrayIndex;
            current = current.Next;
        }
    }

    public void Clear()
    {
        root = new();
        MaxHeight = 0;
        Count = 0;
    }

    public int IndexOf(T item)
    {
        var current = GetTopOfBottomList(root);
        var index = 0;

        while (current is not null)
        {
            var difference = item.CompareTo(current.Item);
            if (difference == 0)
            {
                return index;
            }
            else if (difference < 0)
            {
                return -1;
            }

            current = current.Next;
            ++index;
        }

        return -1;
    }

    public void RemoveAt(int index)
    {
        if (index >= Count)
        {
            throw new IndexOutOfRangeException();
        }

        --Count;

        var current = root;

        while (current.Down is not null)
        {
            current = current.Down;
        }

        for (var i = 0; i < index && current is not null; ++i)
        {
            current = current.Next;
        }

        if (current is not null && current.Next is not null)
        {
            current.Next = current.Next.Next;
        }
    }

    public void Insert(int index, T item)
        => throw new NotSupportedException("list is sorted. use Add() instead");

    private static Node<T>? GetTopOfBottomList(Node<T> root)
        => root.Down is null ? root.Next : GetTopOfBottomList(root.Down);
}
