namespace Tests;

using Xunit;

using BWT;

public class BWT_Tests
{
    [Fact]
    public void Transform_OrdinaryInput()
    {
        var input = "ABACABA";
        var expectedOutput = "BCABAAA";
        var expectedPosition = 2;

        Assert.Equal((expectedOutput, expectedPosition), BWT.Transform(input));
    }

    [Fact]
    public void Transform_EmptyStringAsInput()
    {
        Assert.Throws<ArgumentException>(() => BWT.Transform(string.Empty));
    }

    [Fact]
    public void Detransform_OrdinaryInput()
    {
        var input = "BCABAAA";
        var position = 2;
        var expectedOutput = "ABACABA";

        Assert.Equal(expectedOutput, BWT.Detransform(input, position)); 
    }

    [Fact]
    public void Detransform_EmptyStringAsInput()
    {
        Assert.Throws<ArgumentException>(() => BWT.Detransform(string.Empty, 0));
    }

    [Fact]
    public void Detransform_IncorrectPosition()
    {
        Assert.Throws<ArgumentException>(() => BWT.Detransform("123", 123));
    }
    
    [Fact]
    public void Transform_Then_Detransform()
    {
        var input = "BANANA";
        (string output, int position) = BWT.Transform(input);
        Assert.Equal(input, BWT.Detransform(output, position));
    }
}