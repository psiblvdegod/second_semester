using System.ComponentModel;

namespace Calculator;

public class Calculator : ICalculator<double>
{
    public void AddToken(char token)
    {
        if (token == 'C')
        {
            isStart = true;
            accumulator = default;
            operandBuffer = string.Empty;
            operatorBuffer = default;
        }

        else if (char.IsDigit(token) || (token == '-' && operandBuffer == string.Empty))
        {
            operandBuffer += token;
        }

        else if (operandBuffer == string.Empty)
        {
            return;
        }

        else if (ValidOperations.ContainsKey(token))
        {
            var parsed = double.Parse(operandBuffer);
            accumulator = isStart ? parsed : ValidOperations[operatorBuffer](accumulator, parsed);
            operatorBuffer = token;
            operandBuffer = string.Empty;
            isStart = false;
        }

        else if (token == '=')
        {
            if (!isStart)
            {
                operandBuffer = $"{ValidOperations[operatorBuffer](accumulator, double.Parse(operandBuffer))}";
            }

            isStart = true;
        }

        PropertyChanged?.Invoke(this, new(nameof(State)));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public string State
        => isStart ? $"{operandBuffer}" : $"{accumulator}{operatorBuffer}{operandBuffer}";

    private bool isStart = true;

    private double accumulator;
    
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
