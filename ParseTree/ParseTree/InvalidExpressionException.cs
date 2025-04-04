// <copyright file="InvalidExpressionException.cs" author="psiblvdegod">
// under MIT License.
// </copyright>

namespace ParseTree;

/// <summary>
/// Exception which ought to be thrown if expression passed to build ParseTree.Tree.
/// </summary>
public class InvalidExpressionException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidExpressionException"/> class.
    /// </summary>
    public InvalidExpressionException()
    : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidExpressionException"/> class.
    /// </summary>
    /// <param name="message">Information that specifies exception which has been thrown.</param>
    public InvalidExpressionException(string message)
    : base(message)
    {
    }
}
