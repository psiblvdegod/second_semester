namespace SkipList;

public class SkipList<T> where T : IComparable
{
    int Count = 0;

    SortedLinkLists<T> root;

    public SkipList()
    {
        root = new();
    }
    public SkipList(SortedLinkLists<T> root)
    {
        this.root = root;
    }

    public void Add(T item)
    {
        var node = new Node<T>(item);

        RecCall(root.Items);

        BuildTower();

        void RecCall(Node<T>? current)
        {
            if (current is null)
            {
                return;
            }

            if (current.Next != null && item.CompareTo(current.Next.Item) > 0)
            {
                RecCall(current.Next);      
            }
            else
            {
                RecCall(current.Down);

                if (current.Down is null)
                {
                    node.Next = current.Next;
                    current.Next = node;
                    ++Count;
                }
            } 
        }

        void BuildTower()
        {
            int height = 2;
            var currentNode = node;

            RecCall(root);

            void RecCall(SortedLinkLists<T> currentList, int counter = 0)
            {
                if (currentList.NextList is null)
                {
                    return;
                }

                if (counter < height)
                {
                    currentNode = new(item)
                    {
                        Down = currentNode,
                    };

                    currentList.Add(currentNode);
                }
                
                RecCall(currentList.NextList, counter + 1);
            }
        }
    }

    public bool Contains(T item)
    {
        return RecCall(root.Items);

        bool RecCall(Node<T>? current)
        {
            if (current is null)
            {
                return false;
            }

            if (Equals(item, current.Item))
            {
                return true;
            }

            if (current.Next != null && item.CompareTo(current.Item) > 0)
            {
                return RecCall(current.Next);
            }
            else
            {
                return RecCall(current.Down);
            }
        }
    }
}
