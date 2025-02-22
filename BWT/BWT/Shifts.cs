using System.Collections.Concurrent;

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
}