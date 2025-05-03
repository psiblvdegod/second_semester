// <copyright file="SkipList.cs" company="_">
// psiblvdegod, 2025, under MIT License
// </copyright>

namespace SkipList;

using System.Collections;
using System.Collections.ObjectModel;

/// <summary>
/// Implements sorted list using skip list data structure.
/// </summary>
/// <typeparam name="T">Type of elements in the list.</typeparam>
public class SkipList<T> : IList<T>
where T : IComparable
{
    private Node<T> root = new();

    private event Action? CollectionChanged;

    /// <inheritdoc/>
    public int Count { get; private set; } = 0;

    /// <inheritdoc/>
    public bool IsReadOnly => false;

    private int MaxHeight { get; set; } = 0;

    /// <inheritdoc/>
    public T this[int index]
    {
        get
        {
            if (index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            var current = GetBottomOf(this.root).Next;

            for (var i = 0; i < index && current is not null; ++i)
            {
                current = current.Next;
            }

            if (current is null || current.Item is null)
            {
                throw new NullReferenceException("item in the list is null.");
            }

            return current.Item;
        }

        set => throw new NotSupportedException("sorted list does not support index addition opperations.");
    }

    /// <inheritdoc/>
    public void Add(T item)
    {
        ++this.Count;
        this.CollectionChanged?.Invoke();

        var path = CreatePath(CalculateHeight());
        Node<T> newNode = new(item);

        var current = this.root;

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
            var height = Math.Log2(this.Count);

            if (Math.Abs(double.Floor(height) - height) < 1e-10)
            {
                ++this.MaxHeight;

                this.root = new(this.root.Item)
                {
                    Down = this.root,
                };
            }

            for (var i = this.MaxHeight; i > 1; --i)
            {
                if ((this.Count % Math.Pow(2, i)) < 1e-10)
                {
                    return i;
                }
            }

            return 1;
        }
    }

    /// <inheritdoc/>
    public bool Contains(T item)
    {
        var current = this.root;

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

    /// <inheritdoc/>
    public bool Remove(T item)
    {
        if (Remove(this.root))
        {
            this.CollectionChanged?.Invoke();
            --this.Count;
            return true;
        }

        return false;

        bool Remove(Node<T> current)
        {
            if (current.Next is not null)
            {
                var difference = item.CompareTo(current.Next.Item);

                if (difference == 0)
                {
                    current.Next = current.Next.Next;

                    if (current.Down is not null)
                    {
                        return Remove(current.Down);
                    }

                    return current.Down is null || Remove(current.Down);
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

            return false;
        }
    }

    /// <inheritdoc/>
    public void CopyTo(T[] array, int arrayIndex = 0)
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("list is empty");
        }

        if (this.Count + arrayIndex > array.Length)
        {
            throw new ArgumentException("array is to small to copy without resizing");
        }

        var current = GetBottomOf(this.root).Next;

        while (current is not null)
        {
            if (current.Item is null)
            {
                throw new NullReferenceException("item in the list is null.");
            }

            array[arrayIndex] = current.Item;
            ++arrayIndex;
            current = current.Next;
        }
    }

    /// <inheritdoc/>
    public void Clear()
    {
        this.root = new();
        this.MaxHeight = 0;
        this.Count = 0;
        this.CollectionChanged?.Invoke();
    }

    /// <inheritdoc/>
    public int IndexOf(T item)
    {
        var current = GetBottomOf(this.root).Next;

        for (var index = 0; current is not null; ++index)
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
        }

        return -1;
    }

    /// <inheritdoc/>
    public void RemoveAt(int index)
    {
        if (index >= this.Count)
        {
            throw new IndexOutOfRangeException();
        }

        var current = GetBottomOf(this.root).Next;

        for (var i = 0; i < index && current is not null; ++i)
        {
            current = current.Next;
        }

        if (current is null || current.Item is null)
        {
            throw new NullReferenceException("item in the list is null.");
        }

        this.Remove(current.Item);
        this.CollectionChanged?.Invoke();
    }

    /// <inheritdoc/>
    public void Insert(int index, T item)
        => throw new NotSupportedException("sorted list does not support index addition opperations.");

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator()
    {
        var enumerator = new Enumerator(GetBottomOf(this.root));
        this.CollectionChanged += enumerator.Invalidate;
        return enumerator;
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private static Node<T> GetBottomOf(Node<T> node)
        => node.Down is null ? node : GetBottomOf(node.Down);

    private class Enumerator(Node<T> top) : IEnumerator<T>
    {
        private bool isValid = true;

        private Node<T> currentNode = top;

        public T Current
            => this.currentNode.Item ?? throw new NullReferenceException("item in the list is null.");

        object IEnumerator.Current => this.Current;

        public void Dispose()
            => Console.WriteLine("dispose called");

        public bool MoveNext()
        {
            if (!this.isValid)
            {
                throw new InvalidOperationException("enumerator is invalid.");
            }

            if (this.currentNode.Next is null)
            {
                return false;
            }

            this.currentNode = this.currentNode.Next;

            return true;
        }

        public void Reset()
            => throw new NotSupportedException();

        public void Invalidate()
            => this.isValid = false;
    }
}
