// <copyright file = "BWT.cs" author = "psiblvdegod" date = "2025">
// under MIT license
// </copyright>

namespace BWT;

/// <summary>
/// Contains methods, which allow do Burrows-Wheeler transform.
/// </summary>
public static class BWT
{
    /// <summary>
    /// Tranforms string using Burrows-Wheeler algorithm.
    /// </summary>
    /// <param name="input">String which will be transformed.</param>
    /// <returns>Transformed string and it's position in the table of shifts.</returns>
    public static (string Output, int Position) GetTransformedStringAndPosition(string input)
    {
        ArgumentException.ThrowIfNullOrEmpty(input);

        var shifts = GetShifts(input);
        var output = new char[input.Length];
        var position = 0;

        for (var i = 0; i < shifts.Length; ++i)
        {
            if (shifts[i] == 0)
            {
                output[i] = input[^1];
                position = i;
                continue;
            }

            output[i] = input[shifts[i] - 1];
        }

        return (string.Concat(output), position);
    }

    /// <summary>
    /// Detransforms string which has been transformed with Burrows-Wheeler algorithm.
    /// </summary>
    /// <param name="input">String which will be detransformed.</param>
    /// <param name="position">Position of input string in the shifts table.</param>
    /// <returns>Initial string.</returns>
    public static string GetDetransformedString(string input, int position)
    {
        ArgumentException.ThrowIfNullOrEmpty(input);

        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(position, input.Length);

        ArgumentOutOfRangeException.ThrowIfLessThan(position, 0);

        int alphabetPower = char.MaxValue;
        var count = new int[alphabetPower];
        var amountOfSmaller = new Dictionary<char, int>();

        for (var i = 0; i < input.Length; ++i)
        {
            ++count[input[i]];
        }

        for (var i = 0; i < input.Length; ++i)
        {
            if (amountOfSmaller.ContainsKey(input[i]))
            {
                continue;
            }

            amountOfSmaller[input[i]] = 0;

            for (var j = 0; j < input[i]; ++j)
            {
                amountOfSmaller[input[i]] += count[j];
            }
        }

        var amountOfSameEarlier = new int[input.Length];
        var counterForSameEarlier = new Dictionary<char, int>();

        for (var i = 0; i < input.Length; ++i)
        {
            if (!counterForSameEarlier.ContainsKey(input[i]))
            {
                counterForSameEarlier[input[i]] = 0;
            }

            amountOfSameEarlier[i] = counterForSameEarlier[input[i]]++;
        }

        var output = new char[input.Length];
        var current = position;

        for (var i = input.Length - 1; i >= 0; --i)
        {
            output[i] = input[current];
            current = amountOfSameEarlier[current] + amountOfSmaller[input[current]];
        }

        return string.Concat(output);
    }

    private static int[] GetShifts(string input)
    {
        ArgumentException.ThrowIfNullOrEmpty(input);

        var shifts = new int[input.Length];

        for (var i = 0; i < input.Length; ++i)
        {
            shifts[i] = i;
        }

        var comparer = new ShiftsComparer(input);

        Array.Sort(shifts, comparer);

        return shifts;
    }

    private class ShiftsComparer(string input) : IComparer<int>
    {
        public int Compare(int left, int right)
        {
            var i = right;

            var resultForFirstPart = CompareSlice(left, input.Length);

            return resultForFirstPart != 0 ? resultForFirstPart : CompareSlice(0, left);

            int CompareSlice(int start, int end)
            {
                for (var j = start; j < end; ++j, ++i)
                {
                    i = i == input.Length ? 0 : i;

                    if (input[j] != input[i])
                    {
                        return input[j] - input[i];
                    }
                }

                return 0;
            }
        }
    }
}
