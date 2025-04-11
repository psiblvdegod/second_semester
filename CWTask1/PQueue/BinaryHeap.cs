using System.ComponentModel.Design.Serialization;

namespace PQueue;

public class BinaryHeap<T> : IBinaryHeap<T>
{
    private Node? root = null;

    public void Add(T data, int priority)
    {
        if (root is null)
        {
            this.root = new Node(priority);
            return;
        }

        var current = this.root;

        while (current != null)
        {
            if (priority > current.Priority)
            {
                if (current.RightChild is null)
                {
                    current.RightChild = new Node(priority);
                    current.RightChild.Enqueue(data);
                    return;
                }
                
                current = current.RightChild;

            }
            else if (priority < current.Priority)
            {
                if (current.LeftChild is null)
                {
                    current.LeftChild = new Node(priority);
                    current.LeftChild.Enqueue(data);
                    return;
                }
                
                current = current.LeftChild;
            }
            else
            {
                current.Enqueue(data);
            }
        }
    }

    public (T data, int priority) GetMin()
    {
        throw new NotImplementedException();
    }

    private class Node(int priority)
    {
        private T[] elements = [];

        public int Priority { get; } = priority;

        public Node? LeftChild {get; set;} = null;

        public Node? RightChild {get; set;} = null;

        public void Enqueue(T data)
        {
            elements = [.. elements, data];
        }

        public T Dequeue()
        {
            var result = elements[0];

            elements = elements[1..];

            return result;
        }
    }
}
