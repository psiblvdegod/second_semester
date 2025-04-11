using System.Dynamic;
using Microsoft.VisualBasic;

namespace PQueue;

public class PQueue<T> : IPQueue<T>
{
    BinaryHeap<T> elements = new();

    public T Dequeue()
        => elements.GetMin();

    public void Enqueue(T element, int priority)
       => elements.Add(element, priority);

    public bool IsEmpty()
        => elements.IsEmpty();
}
