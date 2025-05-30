// <copyright file="IEnumerableExtensions.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>

namespace MyLinq;

/// <summary>
/// Implements extension methods for IEnumerable.
/// </summary>
public static class IEnumerableExtensions
{
    /// <summary>
    /// Returns a specified number of contiguous elements from the start of a sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to return elements from.</param>
    /// <param name="count">The number of elements to return.</param>
    /// <returns>An IEnumerable that contains the specified number of elements from the start of the input sequence.</returns>
    public static IEnumerable<TSource> MyTake<TSource>(this IEnumerable<TSource> source, int count)
    {
        IEnumerator<TSource> enumerator = source.GetEnumerator();

        for (var counter = 0; enumerator.MoveNext() && counter < count; ++counter)
        {
            yield return enumerator.Current;
        }
    }

    /// <summary>
    /// Bypasses a specified number of elements in a sequence and then returns the remaining elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">An IEnumerable to return elements from.</param>
    /// <param name="count">The number of elements to skip before returning the remaining elements.</param>
    /// <returns>An IEnumerable that contains the elements that occur after the specified index in the input sequence.</returns>
    public static IEnumerable<TSource> MySkip<TSource>(this IEnumerable<TSource> source, int count)
    {
        IEnumerator<TSource> enumerator = source.GetEnumerator();

        for (var i = 0; i < count; ++i)
        {
            enumerator.MoveNext();
        }

        while (enumerator.MoveNext())
        {
            yield return enumerator.Current;
        }
    }
}
