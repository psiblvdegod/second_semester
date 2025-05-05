// <copyright file="Trie.cs" author="psiblvdegod">
// under MIT License
// </copyright>

namespace Trie;

/// <summary>
/// Implements the "Trie" data structure.
/// </summary>
public class Trie
{
    private readonly Node root = new('/');

    /// <summary>
    /// Gets amount of items in the Trie.
    /// </summary>
    public int Count => this.root.HeirsNumber;

    /// <summary>
    /// Adds an object to the Trie.
    /// </summary>
    /// <returns>true if item is successfully added; otherwise, false.</returns>
    /// <param name="item">The string to add to the Trie.</param>
    public bool Add(string item)
    {
        ArgumentException.ThrowIfNullOrEmpty(item);

        var path = new Node[item.Length];
        var current = this.root;

        for (var i = 0; i < item.Length; ++i)
        {
            path[i] = current;

            var next = current.Find(item[i]);

            if (next is null)
            {
                next = new Node(item[i]);
                current.Link(next);
            }

            current = next;
        }

        if (current.IsInTrie)
        {
            return false;
        }

        current.IsInTrie = true;

        foreach (var node in path)
        {
            ++node.HeirsNumber;
        }

        return true;
    }

    /// <summary>
    /// Removes the first occurrence of a specific string from the Trie.
    /// </summary>
    /// <returns>true if item is successfully removed; otherwise, false.</returns>
    /// <param name="item">The string to remove from the Trie.</param>
    public bool Remove(string item)
    {
        ArgumentException.ThrowIfNullOrEmpty(item);

        IEnumerable<Node> path = [];
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
    /// Determines whether the Trie contains a specific value.
    /// </summary>
    /// <returns>true if the string is found in the Trie; otherwise, false.</returns>
    /// <param name="item">The object to locate in the Trie.</param>
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
    /// Counts words with such prefix in the Trie.
    /// </summary>
    /// <returns>Number of items, which have such prefix.</returns>
    /// <param name="prefix">The prefix to locate in the Trie.</param>
    public int HowManyStartsWithPrefix(string prefix)
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

    private class Node(char symbol, bool isInTrie = false)
    {
        private readonly List<Node> linked = [];

        internal char Symbol { get; } = symbol;

        internal bool IsInTrie { get; set; } = isInTrie;

        internal int HeirsNumber { get; set; }

        internal void Link(Node node) => this.linked.Add(node);

        internal bool Unlink(Node node) => this.linked.Remove(node);

        internal Node? Find(char symbol) => this.linked.Find(x => x.Symbol == symbol);
    }
}
