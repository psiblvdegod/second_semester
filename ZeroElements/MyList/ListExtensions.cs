// <copyright file="ListExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyList;

/// <summary>
/// Contains extension methods for MyList.List.
/// </summary>
public static class ListExtensions
{
    /// <summary>
    /// Counts number of nulls in the List.
    /// </summary>
    /// <typeparam name="T">Type of the collection.</typeparam>
    /// <param name="items">The list to count.</param>
    /// <param name="isNull">Predicate which determines if the item is null.</param>
    /// <returns>Number of null items in the List.</returns>
    public static int CountNulls<T>(this MyList.List<T> items, Predicate<T> isNull)
    {
        var counter = 0;
        foreach (var item in items)
        {
            if (isNull(item))
            {
                ++counter;
            }
        }

        return counter;
    }

    /// <summary>
    /// Counts number of nulls in the List.
    /// </summary>
    /// <typeparam name="T">Type of the collection.</typeparam>
    /// <param name="items">The list to count.</param>
    /// <param name="recognizer">object which can determine if the item is null.</param>
    /// <returns>Number of null items in the List.</returns>
    public static int CountNulls<T>(this MyList.List<T> items, INullRecognizer<T> recognizer)
        => CountNulls(items, recognizer.IsNull);
}
