// <copyright file="Functions.cs" author="psiblvdegod">
// under MIT License
// </copyright>

namespace Functions;

/// <summary>
/// Contains methods which apply passed functions on IEnumerable.
/// </summary>
public static class Functions
{
    /// <summary>
    /// Creates sequence applying passed function to each element in the initial sequence.
    /// </summary>
    /// <typeparam name="TSource">Type of items in the initial sequence.</typeparam>
    /// <typeparam name="TResult">Type to which items of the initial sequence map.</typeparam>
    /// <param name="source">Sequence which is used to create new one.</param>
    /// <param name="func">Function which will be applied to each item of the initial sequence to get new one.</param>
    /// <returns>Transformed sequence.</returns>
    public static IEnumerable<TResult> Map<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> func)
    {
        List<TResult> result = new(source.Count());

        foreach (var element in source)
        {
            result.Add(func(element));
        }

        return result;
    }

    /// <summary>
    /// Creates sequence removing items from initial sequence for which passed predicate is false.
    /// </summary>
    /// <typeparam name="T">Type of items in the sequence.</typeparam>
    /// <param name="source">Sequence which is used to create transformed one.</param>
    /// <param name="predicate">Predicate which determines elements to be added to new sequence.</param>
    /// <returns>Transformed sequence.</returns>
    public static IEnumerable<T> Filter<T>(IEnumerable<T> source, Predicate<T> predicate)
    {
        List<T> result = new(source.Count());

        foreach (var item in source)
        {
            if (predicate(item))
            {
                result.Add(item);
            }
        }

        return result;
    }

    /// <summary>
    /// Accumulates and returns result of doing sequence traversal and applying passed function to each item.
    /// Accumulated value is passed as left operand, current item of sequence as right one.
    /// </summary>
    /// <typeparam name="TSource">Type of the items in the sequence.</typeparam>
    /// <typeparam name="TValue">Type of the accumulating value.</typeparam>
    /// <param name="initialValue">Value which is passed to the func as left operand at the first call.</param>
    /// <param name="source">Sequence which items is used as right opperands.</param>
    /// <param name="func">Function which is applied to accumulated value and item of the sequence.</param>
    /// <returns>Accumulated value.</returns>
    public static TValue Fold<TSource, TValue>(TValue initialValue, IEnumerable<TSource> source, Func<TValue, TSource, TValue> func)
    {
        var result = initialValue;

        foreach (var element in source)
        {
            result = func(result, element);
        }

        return result;
    }
}
