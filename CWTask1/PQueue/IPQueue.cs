namespace PQueue;

interface IPQueue<T>
{
    public T Dequeue();

    public void Enqueue(T element, int priority);

    public bool IsEmpty();
}
