namespace BWT;

using System.Collections;

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
            throw new Exception("empty string is not allowed as input");
        }

        var shifts = new int[input.Length];

        for (var i = 0; i < input.Length; ++i)
        {
            shifts[i] = i;
        }

        QuickSort(shifts, 0, input.Length - 1, input);

        return shifts;
    }

    private static void QuickSort(int[] array, int left, int right, string input)
    {
        if (left >= right)
        {
            return;
        }

        var pivot = Partition(left, right);
        QuickSort(array, left, pivot - 1, input);
        QuickSort(array, pivot + 1, right, input);

        int Partition(int left, int right)
        {
            var pivot = right;
            var i = left - 1;

            for (var j = left; j < right; ++j)
            {
                if (!Compare(j, pivot))
                {
                    ++i;
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }

            (array[i + 1], array[right]) = (array[right], array[i + 1]);

            return i + 1;
        }

        bool Compare(int left, int right)
            => string.Compare(input[array[left]..] + input[..array[left]], input[array[right]..] + input[..array[right]]) > 0;
    }

    public static string Detransform(string input, int position)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(input);

        if (position < 0 || position > input.Length - 1)
        {
            throw new ArgumentException("invalid value");
        }

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
}