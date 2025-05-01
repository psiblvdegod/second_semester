using System.Collections;

namespace SkipList;

public class SkipList<T> : IList<T> where T : IComparable
{
    private int MaxHeight { get; set; } = 0;

    private Node<T> root = new();

    public int Count { get; private set; } = 0;

    public bool IsReadOnly => throw new NotImplementedException();

    public void Add(T item)
    {
        ++this.Count;

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
        var current = root;

        while (true)
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
                    current = current.Next;
                    continue;
                }
            }
            if (current.Down is not null)
            {
                current = current.Down;
            }
            else
            {
                return false;
            }
        }
    }

    public bool Remove(T item)
    {
        var result = false;

        return Remove(root);

        bool Remove(Node<T> current)
        {
            if (current.Next is not null)
            {
                var difference = item.CompareTo(current.Next.Item);

                if (difference == 0)
                {
                    result = true;
                    --Count;

                    current.Next = current.Next.Next;

                    if (current.Down is not null)
                    {
                        return Remove(current.Down);
                    }
                }
                else if (difference < 0 && current.Down is not null)
                {
                    return Remove(current.Down);
                }
                else
                {
                    return Remove(current.Next);
                }
            }
            else if (current.Down is not null)
            {
                return Remove(current.Down);
            }

            return result;
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

        var current = GetBottomOf(root).Next;

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
        var current = GetBottomOf(root).Next;
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

        var current = GetBottomOf(root);

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
        => throw new NotSupportedException("sorted list does not support index addition opperations.");

    private static Node<T> GetBottomOf(Node<T> node)
        => node.Down is null ? node : GetBottomOf(node.Down);

    public T this[int index]
    {
        get
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            var current = GetBottomOf(root).Next;

            for (var i = 0; i < index && current is not null; ++i)
            {
                current = current.Next;
            }

            if (current is null || current.Item is null)
            {
                throw new();
            }

            return current.Item;
        }

        set => throw new NotSupportedException("sorted list does not support index addition opperations.");
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class Enumerator : IEnumerator<T>
    {
        public T Current => throw new NotImplementedException();

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
