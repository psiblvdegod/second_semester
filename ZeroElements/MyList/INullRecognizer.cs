// <copyright file="INullRecognizer.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>

namespace MyList;

/// <summary>
/// Describes object which can compare items of specified type with null.
/// </summary>
/// <typeparam name="T">Type of items to compare.</typeparam>
public interface INullRecognizer<T>
{
    /// <summary>
    /// Checks if the item is null.
    /// </summary>
    /// <param name="item">item to check.</param>
    /// <returns>true if item is null; otherwise false.</returns>
    public bool IsNull(T item);
}
