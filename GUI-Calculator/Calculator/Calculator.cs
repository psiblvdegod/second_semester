// <copyright file="Calculator.cs"> author="psiblvdegod"
// under MIT License.
// </copyright>

namespace Calculator;

using System.ComponentModel;

/// <inheritdoc/>
public class Calculator : ICalculator<double>
{
    /// <summary>
    /// Store intermediate states.
    /// </summary>
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
        => this.isOperatorSpecified ? $"{this.accumulator}{this.operatorBuffer}{this.operandBuffer}" : $"{this.operandBuffer}";

    /// <inheritdoc/>
    public void AddToken(char token)
    {
        if (token == 'C')
        {
            this.operandBuffer = string.Empty;
            this.isOperatorSpecified = false;
            this.isOperandSpecified = false;
            this.accumulator = default;
        }
        else if (char.IsDigit(token) || (token == '-' && !this.isOperandSpecified))
        {
            this.operandBuffer += token;
            this.isOperandSpecified = true;
        }
        else if (this.isOperandSpecified && ValidOperations.ContainsKey(token))
        {
            var parsedOperand = double.Parse(this.operandBuffer);
            this.accumulator = this.isOperatorSpecified ? ValidOperations[this.operatorBuffer](this.accumulator, parsedOperand) : parsedOperand;
            this.operandBuffer = string.Empty;
            this.operatorBuffer = token;
            this.isOperandSpecified = false;
            this.isOperatorSpecified = true;
        }
        else if (this.isOperandSpecified && this.isOperatorSpecified && token == '=')
        {
            this.operandBuffer = $"{ValidOperations[this.operatorBuffer](this.accumulator, double.Parse(this.operandBuffer))}";
            this.isOperatorSpecified = false;
        }

        this.PropertyChanged?.Invoke(this, new (nameof(this.State)));
    }
}
