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
}