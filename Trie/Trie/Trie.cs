// <copyright file="Trie.cs" author="psiblvdegod">
// under MIT License
// </copyright>

namespace Trie;

/// <summary>
/// Implements the "Trie" data structure.
/// </summary>
public class Trie
{
    private readonly Node root = new();

    /// <summary>
    /// Gets amount of items in the Trie.
    /// </summary>
    public int Count => this.root.PrefixCounter;

    /// <summary>
    /// Adds an object to the Trie.
    /// </summary>
    /// <returns>true if item is successfully added; otherwise, false.</returns>
    /// <param name="element">The string to add to the Trie.</param>
    public bool Add(string element)
    {
        ArgumentException.ThrowIfNullOrEmpty(element);

        var path = new Node[element.Length + 1];
        var current = this.root;
        path[0] = this.root;

        for (var i = 0; i < element.Length; ++i)
        {
            var next = current.Find(element[i]);

            if (next is null)
            {
                next = new Node();
                current.Link(element[i], next);
            }

            current = next;
            path[i + 1] = current;
        }

        if (current.IsTerminal)
        {
            return false;
        }

        current.IsTerminal = true;

        foreach (var node in path)
        {
            ++node.PrefixCounter;
        }

        return true;
    }

    /// <summary>
    /// Removes the first occurrence of a specific string from the Trie.
    /// </summary>
    /// <returns>true if item is successfully removed; otherwise, false.</returns>
    /// <param name="element">The string to remove from the Trie.</param>
    public bool Remove(string element)
    {
        ArgumentException.ThrowIfNullOrEmpty(element);

        var path = new List<Node>();
        var current = this.root;
        path.Add(this.root);

        for (var i = 0; i < element.Length; ++i)
        {
            var next = current.Find(element[i]);

            if (next is null)
            {
                return false;
            }

            current = next;
            path.Add(current);
        }

        if (current.IsTerminal is false)
        {
            return false;
        }

        current.IsTerminal = false;

        var previous = path[0];

        for (var i = 1; i < path.Count; ++i)
        {
            if (path[i].PrefixCounter == 1)
            {
                previous.Unlink(element[i]);
                break;
            }

            --path[i].PrefixCounter;
            previous = path[i];
        }

        --this.root.PrefixCounter;
        return true;
    }

    /// <summary>
    /// Determines whether the Trie contains a specific value.
    /// </summary>
    /// <returns>true if the string is found in the Trie; otherwise, false.</returns>
    /// <param name="element">The object to locate in the Trie.</param>
    public bool Contains(string element)
    {
        ArgumentException.ThrowIfNullOrEmpty(element);

        var current = this.root;

        foreach (var symbol in element)
        {
            var next = current.Find(symbol);

            if (next is null)
            {
                return false;
            }

            current = next;
        }

        return current.IsTerminal;
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

        foreach (var symbol in prefix)
        {
            var next = current.Find(symbol);

            if (next is null)
            {
                return 0;
            }

            current = next;
        }

        return current.PrefixCounter;
    }

    private class Node
    {
        private Dictionary<char, Node> nextNodes = [];

        public bool IsTerminal { get; set; } = false;

        public int PrefixCounter { get; set; } = 0;

        public Node? Find(char symbol)
        {
            if (this.nextNodes.TryGetValue(symbol, out Node? value))
            {
                return value;
            }

            return null;
        }

        public void Link(char symbol, Node node)
            => this.nextNodes[symbol] = node;

        public void Unlink(char symbol)
            => this.nextNodes.Remove(symbol);
    }
}
