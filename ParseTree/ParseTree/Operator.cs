// <copyright file="Operator.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>

namespace ParseTree;

/// <summary>
/// Node that has two children, stores operation and associated tokens and allows Calculate() and Print() subtree.
/// </summary>
/// <param name="operation">Function that will be used in Calculate().</param>
/// <param name="token">Token which Print() writes to console.</param>
public class Operator(Func<int, int, int> operation, string token = "") : Node
{
    private readonly Func<int, int, int> operation = operation;

    private readonly string token = token;

    /// <summary>
    /// Gets or sets left operand.
    /// </summary>
    public Node? LeftChild { get; set; }

    /// <summary>
    /// Gets or sets right operand.
    /// </summary>
    public Node? RightChild { get; set; }

    /// <summary>
    /// Calculates expression presented in subtree.
    /// </summary>
    /// <returns>Expression calculating result.</returns>
    /// <exception cref="InvalidOperationException">Is thrown if left or right child is missing.</exception>
    public override int Calculate()
    {
        if (this.LeftChild is null || this.RightChild is null)
        {
            throw new InvalidOperationException("operand is missing.");
        }

        return this.operation(this.LeftChild.Calculate(), this.RightChild.Calculate());
    }

    /// <inheritdoc/>
    public override void Print()
    {
        if (this.LeftChild is not null)
        {
            this.LeftChild.Print();
            Console.Write(" ");
        }

        Console.Write(this.token);

        if (this.RightChild is not null)
        {
            Console.Write(" ");
            this.RightChild.Print();
        }
    }
}
