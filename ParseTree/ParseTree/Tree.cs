using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace ParseTree;

public class Tree
{
    private readonly Node root;

    private static Dictionary<string, Func<int,int,int>> supportedOperators = new()
    {
        ["+"] = (x, y) => x + y,
        ["-"] = (x, y) => x - y,
        ["*"] = (x, y) => x * y,
        ["/"] = (x, y) => x / y,
        ["pow"] = (x, y) => (int)Math.Pow(x, y)
    };

    public static void AddOperationToSupportedOnes(string token, Func<int,int,int> operation)
    {
        if (supportedOperators.ContainsKey(token))
        {
            throw new InvalidOperationException("token is already occupied.");
        }

        supportedOperators[token] = operation;
    }

    public Tree(string expression) 
    {
        var tokens = expression.Split(' ');

        root = Parse(tokens[0]);

        if (tokens.Length == 1 && root is Leaf)
        {
            return;
        }
        else if (tokens.Length == 1 && root is not Leaf)
        {
            throw new InvalidExpressionException();
        }
        else if (tokens.Length != 1 && root is not Operator)
        {
            throw new InvalidExpressionException();
        }

        var stack = new Stack<Operator>();

        stack.Push((Operator)root);

        foreach (var token in tokens[1..])
        {
            var current = stack.Peek();

            var parsed = Parse(token);

            if (current.LeftChild is null)
            {
                current.LeftChild = parsed;
            }
            else if (current.RightChild is null)
            {
                current.RightChild = parsed;
                stack.Pop();
            }

            if (parsed is Operator @operator)
            {
                stack.Push(@operator);
            }
        }
    }

    public int Calculate()
        => root.Calculate();

    private static Node Parse(string token)
    {
        if (int.TryParse(token, out int parsed))
        {
            return new Leaf(parsed);
        }
        else if (supportedOperators.ContainsKey(token))
        {
            return new Operator(supportedOperators[token]);
        }
        else
        {
            throw new NotSupportedException();
        }
    }
}
