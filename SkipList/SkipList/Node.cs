// <copyright file="Node.cs" company="_">
// psiblvdegod, 2025, under MIT License
// </copyright>

namespace SkipList;

/// <summary>
/// Stores item and allows link it with two nodes.
/// </summary>
/// <typeparam name="T">Type of item which node stores.</typeparam>
/// <param name="item">Item which node stores.</param>
public class Node<T>(T? item = default)
{
    /// <summary>
    /// Gets item witch node stores.
    /// </summary>
    public T? Item { get; } = item;

    /// <summary>
    /// Gets or sets next node.
    /// </summary>
    public Node<T>? Next { get; set; }

    /// <summary>
    /// Gets or sets down node.
    /// </summary>
    public Node<T>? Down { get; set; }
}
