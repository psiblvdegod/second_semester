// <copyright file="Calculator.cs"> author="psiblvdegod"
// under MIT License.
// </copyright>

namespace Calculator;

using System.ComponentModel;

/// <inheritdoc/>
public class Calculator : ICalculator<double>
{
    private bool isOperatorSpecified = false;

    private bool isOperandSpecified = false;

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
        => !this.isOperatorSpecified ? $"{this.operandBuffer}" : $"{this.accumulator}{this.operatorBuffer}{this.operandBuffer}";

    /// <inheritdoc/>
    public void AddToken(char token)
    {
        if (token == 'C')
        {
            this.isOperatorSpecified = false;
            this.isOperandSpecified = false;
            this.accumulator = default;
            this.operandBuffer = string.Empty;
            this.operatorBuffer = default;
        }
        else if (char.IsDigit(token) || (token == '-' && !this.isOperandSpecified))
        {
            this.operandBuffer += token;
            this.isOperandSpecified = true;
        }
        else if (!this.isOperandSpecified)
        {
            return;
        }
        else if (ValidOperations.ContainsKey(token))
        {
            var parsed = double.Parse(this.operandBuffer);
            this.accumulator = !this.isOperatorSpecified ? parsed : ValidOperations[this.operatorBuffer](this.accumulator, parsed);
            this.operatorBuffer = token;
            this.operandBuffer = string.Empty;
            this.isOperandSpecified = false;
            this.isOperatorSpecified = true;
        }
        else if (token == '=')
        {
            if (this.isOperatorSpecified)
            {
                this.operandBuffer = $"{ValidOperations[this.operatorBuffer](this.accumulator, double.Parse(this.operandBuffer))}";
                this.isOperandSpecified = true;
            }

            this.isOperatorSpecified = false;
        }

        this.PropertyChanged?.Invoke(this, new (nameof(this.State)));
    }
}
