// <copyright file="List.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>

namespace MyList;

/// <summary>
/// Collection which allows add items and use enumerator on them.
/// </summary>
/// <typeparam name="T">Type of items in the collection.</typeparam>
public class List<T>
{
    private static readonly int InitialLenght = 10;
    private T[] items = new T[InitialLenght];

    /// <summary>
    /// Gets the number of elements contained in the List.
    /// </summary>
    public int Count { get; private set; } = 0;

    /// <summary>
    /// Gets the total number of elements the internal data structure can hold without resizing.
    /// </summary>
    public int Capacity { get; private set; } = InitialLenght;

    /// <summary>
    /// Adds an object to the end of the List.
    /// </summary>
    /// <param name="item">The object to be added to the end of the List.</param>
    public void Add(T item)
    {
        ++this.Count;
        UpdateSize();
        this.items[this.Count] = item;

        void UpdateSize()
        {
            if (this.Count == this.Capacity)
            {
                this.Capacity *= 2;
                var newItems = new T[this.Capacity];
                for (var i = 0; i < this.Count; ++i)
                {
                    newItems[i] = this.items[i];
                }

                this.items = newItems;
            }
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through a collection.
    /// </summary>
    /// <returns>An IEnumerator object that can be used to iterate through the collection.</returns>
    public IEnumerator<T> GetEnumerator()
        => new Enumerator(this.items, this.Count);

    private class Enumerator(T[] items, int count) : IEnumerator<T>
    {
        private T[] items = items;

        private int count = count;

        private int index = -1;

        public T Current
            => this.items[this.index];

        object? System.Collections.IEnumerator.Current
            => this.Current;

        public bool MoveNext()
            => ++this.index < this.count;

        public void Dispose()
        {
        }

        public void Reset()
        {
        }
    }
}
