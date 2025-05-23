// <copyright file="NullRecognizer.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>

namespace Tests;

using MyList;

/// <summary>
/// Custom null recognizer for tests.
/// </summary>
public class NullRecognizer : INullRecognizer<bool>
{
    /// <summary>
    /// Checks if the item is false.
    /// </summary>
    /// <param name="item">item to check.</param>
    /// <returns>true if item is false; otherwise false.</returns>
    public bool IsNull(bool item)
        => item is false;
}
