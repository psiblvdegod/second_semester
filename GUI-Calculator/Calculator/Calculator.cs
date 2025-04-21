namespace Calculator;

public class Calculator : ICalculator
{
    public static string Digits { get; } = "0123456789";

    public void AddToken(char token)
    {
        if (Digits.Contains(token))
        {
            operandBuffer += token;
        }
        else if (ValidOperations.ContainsKey(token))
        {
            var parsed = double.Parse(operandBuffer);
            Value = isStart ? parsed : ValidOperations[operationBuffer](Value, parsed);
            operationBuffer = token;
            operandBuffer = string.Empty;
            isStart = false;
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
