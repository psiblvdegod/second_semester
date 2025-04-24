// <copyright file="ICalculator.cs"> author="psiblvdegod"
// under MIT License.
// </copyright>

namespace Calculator;

using System.ComponentModel;

/// <summary>
/// Calculator which calculates queries immediately.
/// </summary>
/// <typeparam name="T">Type used to evaluate.</typeparam>
public interface ICalculator<T> : INotifyPropertyChanged
{
    /// <summary>
    /// Gets current expression stored in calculator.
    /// </summary>
    public string State { get; }

    /// <summary>
    /// Gets operations which calculator supports.
    /// </summary>
    public static Dictionary<char, Func<T, T, T>>? ValidOperations { get; }

    /// <summary>
    /// Adds token to current expression stored in calculator.
    /// Token may be operator or symbol of operand.
    /// </summary>
    /// <param name="token">Symbol which will be added.</param>
    public void AddToken(char token);
}
