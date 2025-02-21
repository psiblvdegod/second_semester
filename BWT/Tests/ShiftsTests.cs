namespace Tests;

using System.Security.Principal;
using Xunit;

using static BWT.Shifts;

public class ShiftsSortTests
{
    [Fact]
    public static void GetShifts_OrdinaryInput()
    {
        var input = "23415";

        var result = GetShifts(input);

        int[] expectedResult = [3, 0, 1, 2, 4];

        Assert.Equal(expectedResult, result);
    }
}