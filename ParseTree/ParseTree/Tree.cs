using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace ParseTree;

public class Tree
{
    private Node root;

    private static Dictionary<string, Operator> supportedOperators = new()
    {
        ["+"] = new Operator((x, y) => x + y),
        ["-"] = new Operator((x, y) => x - y),
        ["*"] = new Operator((x, y) => x * y),
        ["/"] = new Operator((x, y) => x / y),
        ["pow"] = new Operator((x, y) => (int)Math.Pow(x, y))
    };

    public static void AddOperationToSupportedOnes(string token, Func<int,int,int> operation)
    {
        if (supportedOperators.ContainsKey(token))
        {
            throw new InvalidOperationException("token is already occupied.");
        }

        supportedOperators[token] = new Operator(operation);
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

    private static Node Parse(string token)
    {
        if (int.TryParse(token, out int parsed))
        {
            return new Leaf(parsed);
        }
        else if (supportedOperators.ContainsKey(token))
        {
            return supportedOperators[token];
        }
        else
        {
            throw new NotSupportedException();
        }
    }
}