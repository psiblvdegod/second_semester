// <copyright file="Tree.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>

namespace ParseTree;

/// <summary>
/// Implements parse tree data structure that allows store expression and calculate it.
/// Has addition, subtraction, multiplication and division as operations.
/// Allows add custom integer binary operations.
/// </summary>
public class Tree
{
    private readonly Dictionary<string, Func<int, int, int>> supportedOperators = new()
    {
        ["+"] = (x, y) => x + y,
        ["-"] = (x, y) => x - y,
        ["*"] = (x, y) => x * y,
        ["/"] = (x, y) => x / y,
    };

    private Node? root = null;

    /// <summary>
    /// Adds operation to supported ones so it will be available to use in expressions using specified token.
    /// </summary>
    /// <param name="token">Token which will be used to call new operation in expressions. Token must be unique for each operation.</param>
    /// <param name="operation">Operation which will be called when expression contains appropriate token.</param>
    /// <exception cref="InvalidOperationException">Is thrown if token is already occupied.</exception>
    public void RegisterOperation(string token, Func<int, int, int> operation)
    {
        if (this.supportedOperators.ContainsKey(token))
        {
            throw new InvalidOperationException("token is already occupied.");
        }

        this.supportedOperators[token] = operation;
    }

    /// <summary>
    /// Gets the operation associated with the specified token.
    /// </summary>
    /// <param name="token">Token with which operation is registered.</param>
    /// <param name="operation">When this method returns, contains the operation associated with the specified token if the token is found; otherwise, null. This parameter is passed uninitialized.</param>
    /// <returns>true if token is found; otherwise, false.</returns>
    public bool TryGetRegisteredOperation(string token, out Func<int, int, int>? operation)
        => this.supportedOperators.TryGetValue(token, out operation);

    /// <summary>
    /// Calculates expression presented in the tree.
    /// </summary>
    /// <returns>Expression calculating result.</returns>
    /// <exception cref="InvalidOperationException">Is thrown if the tree is not initialized with an expression.</exception>
    public int Calculate()
    {
        if (this.root is null)
        {
            throw new InvalidOperationException("tree is not initialized with an expression.");
        }

        return this.root.Calculate();
    }

    /// <summary>
    /// Prints expression presented in the tree.
    /// </summary>
    /// <exception cref="InvalidOperationException">Is thrown if tree is not initialized with an expression.</exception>
    public void Print()
    {
        if (this.root is null)
        {
            throw new InvalidOperationException("tree is not initialized with an expression.");
        }

        this.root.Print();
    }

    /// <summary>
    /// Parses expression and fills in the tree with it. The old one expression will be lost.
    /// </summary>
    /// <param name="expression">Expression to parse.</param>
    /// <exception cref="InvalidExpressionException">Is thrown if expression in the tree is invalid.</exception>
    public void Parse(string expression)
    {
        ArgumentException.ThrowIfNullOrEmpty(expression);

        var tokens = expression.Split(' ');
        this.root = this.ParseToken(tokens[0]);

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

            var newNode = this.ParseToken(token);
            var currentOperator = stack.Peek();

            if (currentOperator.LeftChild is null)
            {
                currentOperator.LeftChild = newNode;
            }
            else if (currentOperator.RightChild is null)
            {
                currentOperator.RightChild = newNode;
                stack.Pop();
            }

            if (newNode is Operator newOperator)
            {
                stack.Push(newOperator);
            }
        }

        if (stack.Count != 0)
        {
            throw new InvalidExpressionException();
        }
    }

    private Node ParseToken(string token)
    {
        if (int.TryParse(token, out int parsed))
        {
            return new Leaf(parsed);
        }
        else if (this.supportedOperators.TryGetValue(token, out Func<int, int, int>? value))
        {
            return new Operator(value, token);
        }
        else
        {
            throw new NotSupportedException("token is not recognized.");
        }
    }
}
