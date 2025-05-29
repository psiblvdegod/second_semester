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
    /// <typeparam name="TResult">Type to which items of the initial sequence map. .</typeparam>
    /// <param name="source">Sequence which is used to create transformed one.</param>
    /// <param name="func">Function which will be applied to each element of the sequence.</param>
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
    /// Creates sequence removing elements from initial sequence for which passed predicate is true.
    /// </summary>
    /// <typeparam name="T">Type of elements in the sequence.</typeparam>
    /// <param name="source">Sequence which is used to create transformed one.</param>
    /// <param name="predicate">Predicate which determines elements to be deleted.</param>
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
    /// Calculates result of doing sequence traversal and applying passed function to each element.
    /// </summary>
    /// <typeparam name="TSource">Type of items in the sequence.</typeparam>
    /// <typeparam name="TResult">Type of returned value.</typeparam>
    /// <param name="source">Sequence which is used to calculate.</param>
    /// <param name="initialValue">Value which is passed to function as left operand at the first call.</param>
    /// <param name="func">Function which is used to calculate.</param>
    /// <returns>Result of doing traversal.</returns>
    public static TResult Fold<TSource, TResult>(IEnumerable<TSource> source, TResult initialValue, Func<TResult, TSource, TResult> func)
    {
        var result = initialValue;

        foreach (var element in source)
        {
            result = func(result, element);
        }

        return result;
    }
}
