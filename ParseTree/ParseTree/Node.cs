// <copyright file="Node.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>

namespace ParseTree;

/// <summary>
/// Abstract class that class Tree uses to store items and Calculate() and Print() them.
/// </summary>
public abstract class Node
{
    /// <summary>
    /// Calculates expression presented in subtree.
    /// </summary>
    /// <returns>Expression calculating result.</returns>
    public abstract int Calculate();

    /// <summary>
    /// Prints expression presented in subtree.
    /// </summary>
    public abstract void Print();
}
