﻿// <copyright file="Functions.cs" author="psiblvdegod">
// under MIT License.
// </copyright>

namespace Functions;

/// <summary>
/// Contains methods which apply delegates on IEnumerable.
/// </summary>
public static class Functions
{
    /// <summary>
    /// Creates transformed sequence applying function to each element.
    /// </summary>
    /// <typeparam name="T">Type of elements in sequence.</typeparam>
    /// <param name="elements">Sequence which is used create transformed one.</param>
    /// <param name="func">Function which will be applied to each element of the sequence.</param>
    /// <returns>Transformed sequence.</returns>
    public static IEnumerable<T> Map<T>(IEnumerable<T> elements, Func<T, T> func)
    {
        IEnumerable<T> result = [];

        foreach (var element in elements)
        {
            result = result.Append(func(element));
        }

        return result;
    }

    /// <summary>
    /// Creates transformed sequence removing elements for which predicate is true.
    /// </summary>
    /// <typeparam name="T">Type of elements in the sequence.</typeparam>
    /// <param name="elements">Sequence which is used to create transformed one.</param>
    /// <param name="predicate">Predicate which determines elements to be deleted.</param>
    /// <returns>Transformed sequence.</returns>
    public static IEnumerable<T> Filter<T>(IEnumerable<T> elements, Predicate<T> predicate)
    {
        IEnumerable<T> result = [];

        foreach (var element in elements)
        {
            if (predicate(element))
            {
                result = result.Append(element);
            }
        }

        return result;
    }

    /// <summary>
    /// Calculates result of doing sequence traversal and applying function to each element.
    /// Uses previous function output (or initialValue when call is the first one) as the left operand and the current sequence element as the right operand.
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
