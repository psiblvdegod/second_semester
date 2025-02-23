using System.Collections;

namespace BWT;

public static class BWT
{
    public static (string Output, int Position) Transform(string input)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(input);

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

    private static int[] GetShifts(string input)
    {
        if (input == string.Empty)
        {
            throw new Exception("input is string empty");
        }

        var shifts = new int[input.Length];

        for (var i = 0; i < input.Length; ++i)
        {
            shifts[i] = i;
        }

        BubbleSort(shifts, input);

        return shifts;
    }

    private static void BubbleSort(int[] array, string input)
    {
        bool isSorted = false;
        while (!isSorted)
        {
            isSorted = true;
            for (var i = 1; i < array.Length; ++i)
            {
                if (string.Compare(input[array[i - 1]..] + input[..array[i - 1]], input[array[i]..] + input[..array[i]]) > 0)
                {
                    (array[i - 1], array[i]) = (array[i], array[i - 1]);
                    isSorted = false;
                }
            }
        }
    }

    public static string Detransform(string input, int position)
    {
        int alphabetPower = (int)Math.Pow(2, sizeof(char) * 8);
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

            for (var j = 0; j < input[i]; ++j) // O(1)
            {
                amountOfSmaller[input[i]] += count[j];
            }
        }

        var table = new Dictionary<char, int>();

        var amountOfSameEarlier = new int[input.Length];

        for (var i = 0; i < input.Length; ++i)
        {
            if (!table.ContainsKey(input[i]))
            {
                table[input[i]] = 0;
            }
            amountOfSameEarlier[i] = table[input[i]]++;
        }

        var output = new char[input.Length];

        var current = position;

        for (var i = 0; i < input.Length; ++i)
        {
            output[i] = input[current];
            current = amountOfSameEarlier[current] + amountOfSmaller[input[current]];
        }

        return string.Concat(output);
    }
}