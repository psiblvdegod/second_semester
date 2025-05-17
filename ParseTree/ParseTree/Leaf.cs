// <copyright file="Leaf.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>

namespace ParseTree;

/// <summary>
/// Node that stores integer and has no children.
/// </summary>
/// <param name="item">Value that node stores.</param>
public class Leaf(int item) : Node
{
    private readonly int item = item;

    /// <inheritdoc/>
    public override int Calculate()
        => this.item;

    /// <inheritdoc/>
    public override void Print()
        => Console.Write($"{this.item}");
}
