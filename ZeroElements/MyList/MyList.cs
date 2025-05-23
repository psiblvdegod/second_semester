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
        => new Enumerator(items, this.Count);
    

    private class Enumerator(T[] items, int count) : IEnumerator<T>
    {
        private T[] items = items;

        private int count = count;

        int index = -1;

        public T Current
            => items[this.index];

        object System.Collections.IEnumerator.Current => this.Current;

        public bool MoveNext()
            => ++this.index < count;

        public void Dispose()
        {
        }

        public void Reset()
        {
        }
    }
}
