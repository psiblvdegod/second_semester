// <copyright file="PQueue.cs" author="psiblvdegod">
// under MIT License.
// </copyright>

namespace PQueue;

/// <summary>
/// Implements PQueue data structure.
/// </summary>
/// <typeparam name="T">Type of elements in queue.</typeparam>
public class PQueue<T> : IPQueue<T>
{
    private Node? root = null;

    /// <inheritdoc/>
    public T Dequeue()
    {
        var current = this.root;

        while (true)
        {
            if (current is null)
            {
                throw new InvalidOperationException("queue is empty");
            }

            if (current.IsEmpty())
            {
                current = current.LeftChild;
            }
            else
            {
                return current.Dequeue();
            }
        }
    }

    /// <inheritdoc/>
    public void Enqueue(T data, int priority)
    {
        if (this.root is null)
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

    /// <inheritdoc/>
    public bool IsEmpty()
        => this.root is null || this.root.IsEmpty();

    private class Node(int priority)
    {
        private T[] elements = [];

        public int Priority { get; } = priority;

        public Node? LeftChild { get; set; } = null;

        public Node? RightChild { get; set; } = null;

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
