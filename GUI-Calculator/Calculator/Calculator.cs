namespace Calculator;

public class Calculator : ICalculator
{
    public static string Digits { get; } = "0123456789";

    public void AddToken(char token)
    {
        if (token == 'C')
        {
            isStart = true;
            Value = default;
            operandBuffer = string.Empty;
            operatorBuffer = default;
        }

        else if (Digits.Contains(token))
        {
            operandBuffer += token;
        }

        else if (ValidOperations.ContainsKey(token))
        {
            if (operandBuffer == string.Empty)
            {
                return;
            }

            var parsed = double.Parse(operandBuffer);
            Value = isStart ? parsed : ValidOperations[operatorBuffer](Value, parsed);
            operatorBuffer = token;
            operandBuffer = string.Empty;
            isStart = false;
        }

        else if (token == '=')
        {
            if (operandBuffer == string.Empty)
            {
                return;
            }
            if (!isStart)
            {
                operandBuffer = ValidOperations[operatorBuffer](Value, double.Parse(operandBuffer)).ToString();
            }

            isStart = true;
        }
    }

    public string Output
        => isStart ? $"{operandBuffer}" : $"{Math.Round(Value, 3)} {operatorBuffer} {operandBuffer}";

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
