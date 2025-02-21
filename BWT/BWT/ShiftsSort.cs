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

    private static void QuickSort(int[] array, int l, int r, string input)
    {
        if (l >= r)
        {
            return;
        }

        var pivot = input[array[r]..] + input[..array[r]];

        var (i, j) = (l, r);

        while (i < j)
        {
            if (string.Compare(input[array[i]..] + input[..array[i]], pivot) > 0)
            {
                (array[i], array[j]) = (array[j], array[i]);
                --j;
            }

            ++i;
        }

        QuickSort(array, l, i - 1, input);
        QuickSort(array, i, r, input);
    }
}