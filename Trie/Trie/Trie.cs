// <copyright file="Trie.cs" author="psiblvdegod">
// under MIT License
// </copyright>

namespace Trie;

/// <summary>
/// Implements the "Trie" data structure.
/// </summary>
public class Trie
{
    private readonly Vertex root = new('/');

    /// <summary>
    /// Gets amount of items in the Trie.
    /// </summary>
    public int Count => this.root.HeirsNumber;

    /// <summary>
    /// Adds item to the Trie.
    /// </summary>
    /// <returns>true if item is successfully added; otherwise, false.</returns>
    /// <param name="item">The item which will be added.</param>
    public bool Add(string item)
    {
        ArgumentException.ThrowIfNullOrEmpty(item);

        IEnumerable<Vertex> path = [];
        var current = this.root;

        foreach (var c in item)
        {
            path = path.Append(current);

            var next = current.Find(c);

            if (next is null)
            {
                next = new Vertex(c);
                current.Link(next);
            }

            current = next;
        }

        if (current.IsInTrie)
        {
            return false;
        }

        current.IsInTrie = true;

        foreach (var v in path)
        {
            ++v.HeirsNumber;
        }

        return true;
    }

    /// <summary>
    /// Removes item from the Trie.
    /// </summary>
    /// <returns>true if item is successfully removed; otherwise, false.</returns>
    /// <param name="item">The item which will be removed.</param>
    public bool Remove(string item)
    {
        ArgumentException.ThrowIfNullOrEmpty(item);

        IEnumerable<Vertex> path = [];
        var current = this.root;

        foreach (var c in item)
        {
            path = path.Append(current);

            var next = current.Find(c);

            if (next is null)
            {
                return false;
            }

            current = next;
        }

        if (!current.IsInTrie)
        {
            return false;
        }

        current.IsInTrie = false;

        var previous = path.First();

        foreach (var node in path.Skip(1))
        {
            if (node.HeirsNumber == 1)
            {
                previous.Unlink(node);
                break;
            }

            --node.HeirsNumber;
            previous = node;
        }

        --this.root.HeirsNumber;

        return true;
    }

    /// <summary>
    /// Finds item in the Trie.
    /// </summary>
    /// <returns>true if item was found; otherwise, false.</returns>
    /// <param name="item">The item which will be searched for.</param>
    public bool Contains(string item)
    {
        var current = this.root;

        foreach (var c in item)
        {
            var next = current.Find(c);

            if (next is null)
            {
                return false;
            }

            current = next;
        }

        return current.IsInTrie;
    }

    /// <summary>
    /// Counts word with such prefix in the Trie.
    /// </summary>
    /// <returns>Number of items, which have such prefix.</returns>
    /// <param name="prefix">The prefix which defines search key.</param>
    public int CountWordsWithSuchPrefix(string prefix)
    {
        ArgumentException.ThrowIfNullOrEmpty(prefix);

        var current = this.root;

        foreach (var c in prefix)
        {
            var next = current.Find(c);

            if (next is null)
            {
                return 0;
            }

            current = next;
        }

        return current.HeirsNumber;
    }

    private class Vertex(char symbol, bool isInTrie = false)
    {
        private readonly List<Vertex> linked = [];

        internal char Symbol { get; } = symbol;

        internal bool IsInTrie { get; set; } = isInTrie;

        internal int HeirsNumber { get; set; }

        internal void Link(Vertex vertex) => this.linked.Add(vertex);

        internal bool Unlink(Vertex vertex) => this.linked.Remove(vertex);

        internal Vertex? Find(char symbol) => this.linked.Find(x => x.Symbol == symbol);
    }
}