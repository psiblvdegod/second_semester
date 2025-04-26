using System.Runtime.CompilerServices;

namespace SkipList;

public class SkipList<T> where T : IComparable
{
    private Node root = new();

    public int Count { get; private set; } = 0;

    public void Add(T item)
    {
        var node = new Node(item);

        var current = root;

        while (true)
        {
            var next = current.Next;

            if (next is null || item.CompareTo(next.Item) < 0)
            {
                if (current.Down is null)
                {
                    node.Next = next;
                    current.Next = node;
                    ++this.Count;
                    break;
                }

                current = current.Down;
            }
            else
            {
                current = next;
            }
        }
    }

    public bool Contains(T item)
    {
        return RecCall(root);

        bool RecCall(Node? current)
        {
            if (current is null)
            {
                return false;
            }

            if (Equals(item, current.Item))
            {
                return true;
            }

            if (current.Next is null || item.CompareTo(current.Next.Item) < 0)
            {
                return RecCall(current.Down);
            }

            return RecCall(current.Next);
        }
    }
    
    private class Node(T? item = default)
    {
        public T? Item {get;} = item;
        public Node? Next {get; set;}
        public Node? Down {get; set;}
    }
}