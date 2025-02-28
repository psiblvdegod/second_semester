// <copyright file="Trie.cs" author="psiblvdegod" date ="2025">
// under MIT license
// </copyright>

namespace Trie;

/// <summary>
/// Implements the "Trie" data structure.
/// </summary>
public class Trie
{
    private readonly Vertex root;

    /// <summary>
    /// Initializes a new instance of the <see cref="Trie"/> class.
    /// </summary>
    public Trie()
    {
        this.root = new('/');
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Trie"/> class filling it with passed sequence.
    /// </summary>
    /// <param name="elements">The sequence from which the Trie is created.</param>
    public Trie(IEnumerable<string> elements)
        : this()
    {
        foreach (var element in elements)
        {
            this.Add(element);
        }
    }

    /// <summary>
    /// Gets amount of elements in the Trie.
    /// </summary>
    public int Size
    {
        get { return this.root.HeirsNumber; }
    }

    /// <summary>
    /// Adds element to the Trie.
    /// </summary>
    /// <returns>true if item is successfully added; otherwise, false.</returns>
    /// <param name="element">The element which will be added.</param>
    public bool Add(string element)
    {
        ArgumentException.ThrowIfNullOrEmpty(element);

        List<Vertex> path = [];
        var current = this.root;
        path.Add(current);

        foreach (var c in element)
        {
            var next = current.Find(c);

            if (next is null)
            {
                next = new Vertex(c);
                current.Link(next);
            }

            path.Add(next);
            current = next;
        }

        if (current.Number != -1)
        {
            return false;
        }

        current.Number = this.Size;

        foreach (var v in path)
        {
            ++v.HeirsNumber;
        }

        return true;
    }

    /// <summary>
    /// Removes element from the Trie.
    /// </summary>
    /// <returns>true if item is successfully removed; otherwise, false.</returns>
    /// <param name="element">The element which will be removed.</param>
    public bool Remove(string element)
    {
        ArgumentException.ThrowIfNullOrEmpty(element);

        List<Vertex> path = [];
        var current = this.root;
        path.Add(current);

        foreach (var c in element)
        {
            var next = current.Find(c);

            if (next is null)
            {
                return false;
            }

            path.Add(next);
            current = next;
        }

        if (current.Number == -1)
        {
            return false;
        }

        current.Number = -1;

        for (var i = 1; i < path.Count; ++i)
        {
            if (path[i].HeirsNumber == 1)
            {
                path[i - 1].Unlink(path[i]);
                break;
            }

            --path[i].HeirsNumber;
        }

        --this.root.HeirsNumber;

        return true;
    }

    /// <summary>
    /// Searches element in the Trie.
    /// </summary>
    /// <returns>(positive)number of item if it was found; otherwise, -1.</returns>
    /// <param name="element">The element which will be searched for.</param>
    public int Find(string element)
    {
        var current = this.root;

        foreach (var c in element)
        {
            var next = current.Find(c);

            if (next is null)
            {
                return -1;
            }

            current = next;
        }

        return current.Number;
    }

    /// <summary>
    /// Counts word with such prefix in the Trie.
    /// </summary>
    /// <returns>Number of elements, which have such prefix.</returns>
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

    private class Vertex(char symbol, int number = -1)
    {
        private readonly List<Vertex> linked = [];

        internal char Symbol { get; } = symbol;

        internal int Number { get; set; } = number;

        internal int HeirsNumber { get; set; }

        internal void Link(Vertex vertex) => this.linked.Add(vertex);

        internal bool Unlink(Vertex vertex) => this.linked.Remove(vertex);

        internal Vertex? Find(char symbol) => this.linked.Find(x => x.Symbol == symbol);
    }
}