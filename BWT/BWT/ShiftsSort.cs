using System.Collections.Concurrent;
using System.Globalization;

namespace BWT;

public static class Shifts
{
    public static int[] GetShifts(string input)
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
        QuickSort(array, left, pivot, input);
        QuickSort(array, pivot + 1, right, input);

        int Partition(int l, int r)
        {
            var p = input[array[(l + r) / 2]..] + input[..array[(l + r) / 2]];
            var (i, j) = (l, r);
            while (true)
            {
                while (string.Compare(input[array[i]..] + input[..array[i]], p) < 0)
                {
                    ++i;
                }

                while (string.Compare(input[array[j]..] + input[..array[j]], p) > 0)
                {
                    --j;
                }

                if (i >= j)
                {
                    return i;
                }

                (array[i], array[j]) = (array[j], array[i]);
                ++i;
                --j;
            }
        }
    }
}