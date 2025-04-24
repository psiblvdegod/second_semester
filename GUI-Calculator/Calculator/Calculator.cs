// <copyright file="Calculator.cs"> author="psiblvdegod"
// under MIT License.
// </copyright>

namespace Calculator;

using System.ComponentModel;

/// <summary>
/// Implements calculator which calculates queries immediately.
/// </summary>
public class Calculator : INotifyPropertyChanged
{
    /// <summary>
    /// Store intermediate states.
    /// </summary>
    private bool isOperatorSpecified;
    private bool isOperandSpecified;
    private double accumulator;
    private char operatorBuffer;
    private string operandBuffer = string.Empty;

    /// <inheritdoc/>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Gets binary operations which calculator supports.
    /// </summary>
    public static Dictionary<char, Func<double, double, double>> BinaryOperations { get; } = new ()
    {
        ['+'] = (x, y) => x + y,
        ['*'] = (x, y) => x * y,
        ['-'] = (x, y) => x - y,
        ['/'] = (x, y) => x / y,
        ['^'] = Math.Pow,
    };

    /// <summary>
    /// Gets unary operations which calculator supports.
    /// </summary>
    public static Dictionary<char, Func<double, double>> UnaryOperations { get; } = new ()
    {
        ['\u2191'] = Math.Ceiling,
        ['\u2193'] = Math.Floor,
    };

    /// <summary>
    /// Gets current expression stored in calculator.
    /// </summary>
    public string State
        => this.isOperatorSpecified ? $"{this.accumulator}{this.operatorBuffer}{this.operandBuffer}" : $"{this.operandBuffer}";

    /// <summary>
    /// Adds token to current expression stored in calculator.
    /// Token may be operator or symbol of operand.
    /// </summary>
    /// <param name="token">Token which will be added.</param>
    public void AddToken(char token)
    {
        if (token == 'C')
        {
            this.operandBuffer = string.Empty;
            this.isOperatorSpecified = false;
            this.isOperandSpecified = false;
            this.accumulator = default;
        }
        else if (char.IsDigit(token))
        {
            this.operandBuffer += token;
            this.isOperandSpecified = true;
        }
        else if (token == '.' && this.isOperandSpecified && !this.operandBuffer.Contains('.'))
        {
            this.operandBuffer += token;
            this.isOperandSpecified = false;
        }
        else if (token == '-' && !this.isOperandSpecified && !this.operandBuffer.Contains('-'))
        {
            this.operandBuffer += token;
        }
        else if (this.isOperandSpecified && !this.isOperatorSpecified && UnaryOperations.ContainsKey(token))
        {
            this.operandBuffer = UnaryOperations[token](double.Parse(this.operandBuffer)).ToString();
        }
        else if (this.isOperandSpecified && BinaryOperations.ContainsKey(token))
        {
            var parsedOperand = double.Parse(this.operandBuffer);
            this.accumulator = this.isOperatorSpecified ? BinaryOperations[this.operatorBuffer](this.accumulator, parsedOperand) : parsedOperand;
            this.operandBuffer = string.Empty;
            this.operatorBuffer = token;
            this.isOperandSpecified = false;
            this.isOperatorSpecified = true;
        }
        else if (this.isOperandSpecified && this.isOperatorSpecified && token == '=')
        {
            this.operandBuffer = $"{BinaryOperations[this.operatorBuffer](this.accumulator, double.Parse(this.operandBuffer))}";
            this.isOperatorSpecified = false;
        }
        else
        {
            return;
        }

        this.PropertyChanged?.Invoke(this, new (nameof(this.State)));
    }
}
