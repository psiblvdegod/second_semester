// <copyright file="Tree.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>

namespace ParseTree;

/// <summary>
/// Implements parse tree data structure that allows store expression and calculates it.
/// Has addition, subtraction, multiplication and division as operations.
/// Allows add custom integer binary operations.
/// </summary>
public class Tree
{
    private static readonly Dictionary<string, Func<int, int, int>> SupportedOperators = new()
    {
        ["+"] = (x, y) => x + y,
        ["-"] = (x, y) => x - y,
        ["*"] = (x, y) => x * y,
        ["/"] = (x, y) => x / y,
    };

    private readonly Node root;

    /// <summary>
    /// Initializes a new instance of the <see cref="Tree"/> class.
    /// Builds parse tree by passed expression.
    /// </summary>
    /// <param name="expression">Expression that will be parsed to build tree.</param>
    public Tree(string expression)
    {
        ArgumentException.ThrowIfNullOrEmpty(expression);

        var tokens = expression.Split(' ');
        this.root = Parse(tokens[0]);

        if (tokens.Length == 1 && this.root is Leaf)
        {
            return;
        }
        else if (tokens.Length == 1 && this.root is not Leaf)
        {
            throw new InvalidExpressionException();
        }
        else if (tokens.Length != 1 && this.root is not Operator)
        {
            throw new InvalidExpressionException();
        }

        var stack = new Stack<Operator>();

        stack.Push((Operator)this.root);

        foreach (var token in tokens[1..])
        {
            if (stack.Count == 0)
            {
                throw new InvalidExpressionException();
            }

            AddNodeToTree(Parse(token));
        }

        if (stack.Count != 0)
        {
            throw new InvalidExpressionException();
        }

        void AddNodeToTree(Node node)
        {
            var current = stack.Peek();

            if (current.LeftChild is null)
            {
                current.LeftChild = node;
            }
            else if (current.RightChild is null)
            {
                current.RightChild = node;
                stack.Pop();
            }

            if (node is Operator op)
            {
                stack.Push(op);
            }
        }
    }

    /// <summary>
    /// Adds operation to supported ones so it will be available in expressions used to build parse tree.
    /// </summary>
    /// <param name="token">Token which will be used to call new operation in expressions. Token must be unique for each operation.</param>
    /// <param name="operation">Operation which will be called when expression contains appropriate token.</param>
    /// <exception cref="InvalidOperationException">Is thrown if token is already occupied.</exception>
    public static void AddOperationToSupportedOnes(string token, Func<int, int, int> operation)
    {
        if (SupportedOperators.ContainsKey(token))
        {
            throw new InvalidOperationException("token is already occupied.");
        }

        SupportedOperators[token] = operation;
    }

    /// <summary>
    /// Calculates expression that is stored in tree.
    /// </summary>
    /// <returns>Expression calculating result.</returns>
    public int Calculate()
        => this.root.Calculate();

    private static Node Parse(string token)
    {
        if (int.TryParse(token, out int parsed))
        {
            return new Leaf(parsed);
        }
        else if (SupportedOperators.TryGetValue(token, out Func<int, int, int>? value))
        {
            return new Operator(value, token);
        }
        else
        {
            throw new NotSupportedException("token is not recognized.");
        }
    }
}
