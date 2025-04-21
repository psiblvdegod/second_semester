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
            Value = isStart ? parsed : ValidOperations[operatorBuffer](Value, parsed);
            operatorBuffer = token;
            operandBuffer = string.Empty;
            isStart = false;
        }
    }

    public string Output
        => isStart ? $"{operandBuffer}" : $"{Value} {operatorBuffer} {operandBuffer}";

    private bool isStart = true;

    public double Value { get; private set; }
    
    private char operatorBuffer;

    private string operandBuffer = string.Empty;

    public static readonly Dictionary<char, Func<double, double, double>> ValidOperations = new()
    {
        ['+'] = (x,y) => x + y,
        ['*'] = (x,y) => x * y,
        ['-'] = (x,y) => x - y,
        ['/'] = (x,y) => x / y,
    };
}
