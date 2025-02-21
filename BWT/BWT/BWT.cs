namespace BWT;

public static class BWT
{
    public static (string Output, int Position) Transform(string input)
    {
        if (input == string.Empty)
        {
            throw new Exception("input is empty string");
        }

        var shifts = Shifts.GetShifts(input);

        var output = new char[input.Length];

        var position = 0;

        for (var i = shifts.Length - 1; i != 0; --i)
        {
            if (shifts[i] == 0)
            {
                position = i;
            }

            output[i] = input[input.Length - 1 - shifts[i]];
        }

        return (string.Concat(output), position);
    }
}