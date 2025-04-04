// <copyright file="Node.cs" author="psiblvdegod">
// under MIT License.
// </copyright>

namespace ParseTree;

/// <summary>
/// Abstract class that class Tree uses to store data.
/// </summary>
public abstract class Node
{
    /// <summary>
    /// Calculates expression presented in subtree.
    /// </summary>
    /// <returns>Expression calculating result.</returns>
    public abstract int Calculate();

    /// <summary>
    /// Prints value which is stored in this node.
    /// </summary>
    public abstract void Print();
}
