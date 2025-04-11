namespace PQueue;

interface IBinaryHeap<T>
{
    public (T data, int priority) GetMin();

    public void Add(T data, int priority);
}
