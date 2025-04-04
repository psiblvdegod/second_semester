// <copyright file="Operator.cs" author="psiblvdegod">
// under MIT License.
// </copyright>

namespace ParseTree;

/// <summary>
/// Node that has two children and lets use passed operation on them.
/// </summary>
/// <param name="operation">Function that will be used in Calculate().</param>
/// <param name="token">Token which Print() writes to console.</param>
public class Operator(Func<int, int, int> operation, string token = "") : Node
{
    private readonly string token = token;

    /// <summary>
    /// Gets or sets left operand.
    /// </summary>
    public Node? LeftChild { get; set; }

    /// <summary>
    /// Gets or sets right operand.
    /// </summary>
    public Node? RightChild { get; set; }

    private Func<int, int, int> Operation { get; } = operation;

    /// <inheritdoc/>
    public override int Calculate()
    {
        if (this.LeftChild is null || this.RightChild is null)
        {
            throw new InvalidOperationException("operand is missing.");
        }

        return this.Operation(this.LeftChild.Calculate(), this.RightChild.Calculate());
    }

    /// <inheritdoc/>
    public override void Print()
        => Console.WriteLine(this.token);
}
