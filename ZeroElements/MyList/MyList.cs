namespace MyList;

public class List<T>
{
    private static readonly int InitialLenght = 10;
    private T[] items = new T[InitialLenght];
    public int Count { get; private set; } = 0;
    public int Capacity { get; private set; } = InitialLenght;

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

    public IEnumerator<T> GetEnumerator()
    {
        return new Enumerator(items);
    }

    private class Enumerator(T[] items) : IEnumerator<T>
    {
        private T[] items = items;

        int index = 0;

        public T Current
            => items[this.index];

        object System.Collections.IEnumerator.Current => this.Current;

        public bool MoveNext()
            => ++this.index < items.Length;

        public void Dispose()
        {
        }

        public void Reset()
        {
        }
    }
}
