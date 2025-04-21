using System.Data;
using Microsoft.VisualBasic;

namespace Calculator;

public class Calculator
{
    public static string Digits { get; } = "0123456789";

    public void AddToken(char token)
    {
        if (isStart)
        {
            if (Digits.Contains(token))
            {
                operandBuffer += token;
            }
            else if (ValidOperations.ContainsKey(token))
            {
                Value = double.Parse(operandBuffer);
                operationBuffer = token;
                operandBuffer = string.Empty;
                isStart = false;
            }
        }
        else
        {
            if (Digits.Contains(token))
            {
                operandBuffer += token;
            }
            else if (ValidOperations.ContainsKey(token))
            {
                Value = ValidOperations[operationBuffer](Value, double.Parse(operandBuffer));
                operationBuffer = token;
                operandBuffer = string.Empty;
            }
        }
    }

    private bool isStart = true;

    public double Value { get; private set; }
    
    private char operationBuffer;

    private string operandBuffer = string.Empty;

    public static readonly Dictionary<char, Func<double, double, double>> ValidOperations = new()
    {
        ['+'] = (x,y) => x + y,
        ['*'] = (x,y) => x * y,
        ['-'] = (x,y) => x - y,
        ['/'] = (x,y) => x / y,
    };
}
