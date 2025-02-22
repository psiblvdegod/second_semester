namespace Tests;

using Xunit;

using BWT;

public class BWT_Tests
{
 
    public void Transform_OrdinaryInput()
    {
        var input = "ABACABA";
        var expectedOutput = "BCABAAA";
        var expectedPosition = 2;

        Assert.Equal((expectedOutput, expectedPosition), BWT.Transform(input));
    }
}