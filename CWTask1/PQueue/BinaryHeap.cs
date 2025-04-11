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
            this.root.Enqueue(data);
            return;
        }

        var current = this.root;

        while (true)
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
                return;
            }
        }
    }

    public T GetMin()
    {
        throw new NotImplementedException();

        if (root is null)
        {
            throw new InvalidOperationException("heap is empty");
        }

        var result = root.Dequeue();

        if (!root.IsEmpty())
        {
            return result;
        }

        if (root.RightChild is null)
        {
            root = root.LeftChild;
            return result;
        }
        else if (root.LeftChild is null)
        {
            root = root.RightChild;
            return result;
        }
        else 
        {
            var leftBranch = root.LeftChild;
            root = root.RightChild;


        }
    }

    public bool IsEmpty()
        => root is null || root.IsEmpty();

    private class Node(int priority)
    {
        private T[] elements = [];

        public int Priority { get; } = priority;

        public Node? LeftChild {get; set;} = null;

        public Node? RightChild {get; set;} = null;

        public void Enqueue(T data)
        {
            this.elements = [.. this.elements, data];
        }

        public T Dequeue()
        {
            if (this.elements.Length == 0)
            {
                throw new InvalidOperationException("there is no elements in the node");
            }

            var result = this.elements[0];

            if (this.elements.Length == 1)
            {
                this.elements = [];
            }
            else
            {
                this.elements = this.elements[1..];
            }

            return result;
        }

        public bool IsEmpty()
            => this.elements.Length == 0;
    }
}
