using System.Dynamic;
using Microsoft.VisualBasic;

namespace PQueue;

public class PQueue<T> : IPQueue<T>
{
    List<(T data, int priority)> elements = [];

    public T Dequeue()
    {
        var index = GetIndexOfMin();

        var result = elements[index].data;

        elements.RemoveAt(index);

        return result;

        int GetIndexOfMin()
        {
            int result = 0;

            for (var i = 1; i < elements.Count; ++i)
            {
                if (elements[i].priority < elements[result].priority)
                {
                    result = i;
                }
            }

            return result;
        }
    }

    public void Enqueue(T element, int priority)
        => elements.Add((element, priority));

    public bool IsEmpty()
        => elements.Count == 0;
}

public class BinaryHeap<T>
{
    private class Node(T data, int priority)
    {
        public T Data { get; } = data;

        public int Priority { get; } = priority;

        public Node? LeftChild {get; set;} = null;

        public Node? RightChild {get; set;} = null;
    }
}
