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
            throw new Exception("input is string empty");
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

        int Partition(int l, int r)
        {
            var p = r;
            var i = l - 1;

            for (var j = l; j < r; ++j)
            {
                if (!Compare(j, p))
                {
                    ++i;
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }

            (array[i + 1], array[r]) = (array[r], array[i + 1]);

            return i + 1;
        }

        bool Compare(int low, int high)
        {
            var lo = input[array[low]..] + input[..array[low]];
            var hi = input[array[high]..] + input[..array[high]];

            return string.Compare(lo, hi) > 0;
        }
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

        for (var i = input.Length - 1; i >= 0; --i)
        {
            output[i] = input[current];
            current = amountOfSameEarlier[current] + amountOfSmaller[input[current]];
        }

        return string.Concat(output);
    }
}