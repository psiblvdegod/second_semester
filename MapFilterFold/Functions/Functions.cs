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
    /// <typeparam name="T">Type of elements in sequence.</typeparam>
    /// <param name="elements">Sequence which is used to create transformed one.</param>
    /// <param name="func">Function which will be applied to each element of the sequence.</param>
    /// <returns>Transformed sequence.</returns>
    public static IEnumerable<T> Map<T>(IEnumerable<T> elements, Func<T, T> func)
    {
        List<T> result = new(elements.Count());

        foreach (var element in elements)
        {
            result.Add(func(element));
        }

        return result.AsEnumerable();
    }

    /// <summary>
    /// Creates sequence removing elements from initial sequence for which passed predicate is true.
    /// </summary>
    /// <typeparam name="T">Type of elements in the sequence.</typeparam>
    /// <param name="elements">Sequence which is used to create transformed one.</param>
    /// <param name="predicate">Predicate which determines elements to be deleted.</param>
    /// <returns>Transformed sequence.</returns>
    public static IEnumerable<T> Filter<T>(IEnumerable<T> elements, Predicate<T> predicate)
    {
        List<T> result = new(elements.Count());

        foreach (var element in elements)
        {
            if (predicate(element))
            {
                result.Add(element);
            }
        }

        return result.AsEnumerable();
    }

    /// <summary>
    /// Calculates result of doing sequence traversal and applying passed function to each element.
    /// </summary>
    /// <typeparam name="T">Type of elements in the sequence.</typeparam>
    /// <param name="elements">Sequence which is used to calculate.</param>
    /// <param name="initialValue">Value which is passed to function as left operand at the first call.</param>
    /// <param name="func">Function which is used to calculate.</param>
    /// <returns>Result of doing traversal.</returns>
    public static T Fold<T>(IEnumerable<T> elements, T initialValue, Func<T, T, T> func)
    {
        var result = initialValue;

        foreach (var element in elements)
        {
            result = func(result, element);
        }

        return result;
    }
}
