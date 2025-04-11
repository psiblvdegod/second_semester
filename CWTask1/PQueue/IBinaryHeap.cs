namespace PQueue;

interface IBinaryHeap<T>
{
    public T GetMin();

    public void Add(T data, int priority);

    public bool IsEmpty();
}
