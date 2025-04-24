// <copyright file="Calculator.cs"> author="psiblvdegod"
// under MIT License.
// </copyright>

namespace Calculator;

using System.ComponentModel;

/// <inheritdoc/>
public class Calculator : ICalculator<double>
{
    private bool isStart = true;

    private double accumulator;

    private char operatorBuffer;

    private string operandBuffer = string.Empty;

    /// <summary>
    /// Notifies subscribers when State changes.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Gets operations which calculator supports.
    /// </summary>
    public static Dictionary<char, Func<double, double, double>> ValidOperations { get; } = new ()
    {
        ['+'] = (x, y) => x + y,
        ['*'] = (x, y) => x * y,
        ['-'] = (x, y) => x - y,
        ['/'] = (x, y) => x / y,
    };

    /// <inheritdoc/>
    public string State
        => this.isStart ? $"{this.operandBuffer}" : $"{this.accumulator}{this.operatorBuffer}{this.operandBuffer}";

    /// <inheritdoc/>
    public void AddToken(char token)
    {
        if (token == 'C')
        {
            this.isStart = true;
            this.accumulator = default;
            this.operandBuffer = string.Empty;
            this.operatorBuffer = default;
        }
        else if (char.IsDigit(token) || (token == '-' && this.operandBuffer == string.Empty))
        {
            this.operandBuffer += token;
        }
        else if (this.operandBuffer == string.Empty)
        {
            return;
        }
        else if (ValidOperations.ContainsKey(token))
        {
            var parsed = double.Parse(this.operandBuffer);
            this.accumulator = this.isStart ? parsed : ValidOperations[this.operatorBuffer](this.accumulator, parsed);
            this.operatorBuffer = token;
            this.operandBuffer = string.Empty;
            this.isStart = false;
        }
        else if (token == '=')
        {
            if (!this.isStart)
            {
                this.operandBuffer = $"{ValidOperations[this.operatorBuffer](this.accumulator, double.Parse(this.operandBuffer))}";
            }

            this.isStart = true;
        }

        this.PropertyChanged?.Invoke(this, new (nameof(this.State)));
    }
}
