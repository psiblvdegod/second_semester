// <copyright file="InvalidTopologyException.cs" author="psiblvdegod">
// under MIT License.
// </copyright>

namespace Graph;

/// <summary>
/// Throw if for some reason graph can not be build using topology passed to method.
/// </summary>
public class InvalidTopologyException : System.Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidTopologyException"/> class.
    /// </summary>
    public InvalidTopologyException()
        : base()
        {
        }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidTopologyException"/> class.
    /// </summary>
    /// <param name="message">Any additional information about exception.</param>
    public InvalidTopologyException(string message)
        : base(message)
        {
        }
}
