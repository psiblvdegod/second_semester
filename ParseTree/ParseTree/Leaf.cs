// <copyright file="Leaf.cs" author="psiblvdegod">
// under MIT License.
// </copyright>

namespace ParseTree;

/// <summary>
/// Node that stores integer and has no children.
/// </summary>
/// <param name="data">Value that node stores.</param>
public class Leaf(int data) : Node
{
    private readonly int data = data;

    /// <inheritdoc/>
    public override int Calculate()
        => this.data;

    /// <inheritdoc/>
    public override void Print()
        => Console.WriteLine($"{this.data}");
}
