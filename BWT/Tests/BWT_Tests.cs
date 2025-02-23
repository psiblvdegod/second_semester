// <copyright file = "BWT_Tests.cs" author = "psiblvdegod" date = "2025">
// under MIT license
// </copyright>

namespace Tests;

using BWT;
using Xunit;

public class BWT_Tests
{
    [Fact]
    private void Transform_OrdinaryInput()
    {
        var input = "ABACABA";
        var expectedOutput = "BCABAAA";
        var expectedPosition = 2;

        Assert.Equal((expectedOutput, expectedPosition), BWT.Transform(input));
    }

    [Fact]
    private void Transform_OneSymbolAsInput()
    {
        var input = "C";
        var expectedOutput = "C";
        var expectedPosition = 0;

        Assert.Equal((expectedOutput, expectedPosition), BWT.Transform(input));
    }

    [Fact]
    private void Transform_StrOfIdentialCharsAsInput()
    {
        var input = "1111";
        var expectedOutput = "1111";
        var expectedPosition = 0;

        Assert.Equal((expectedOutput, expectedPosition), BWT.Transform(input));
    }

    [Fact]
    private void Transform_EmptyStringAsInput()
    {
        Assert.Throws<ArgumentException>(() => BWT.Transform(string.Empty));
    }

    [Fact]
    private void Detransform_OrdinaryInput()
    {
        var input = "BCABAAA";
        var position = 2;
        var expectedOutput = "ABACABA";

        Assert.Equal(expectedOutput, BWT.Detransform(input, position));
    }

    [Fact]
    private void Detransform_OneSymbolAsInput()
    {
        var input = "C";
        var position = 0;
        var expectedOutput = "C";

        Assert.Equal(expectedOutput, BWT.Detransform(input, position));
    }

    [Fact]
    private void Detransform_StrOfIdentialCharsAsInput()
    {
        var input = "4444";
        var position = 0;
        var expectedOutput = "4444";

        Assert.Equal(expectedOutput, BWT.Detransform(input, position));
    }

    [Fact]
    private void Detransform_EmptyStringAsInput()
    {
        Assert.Throws<ArgumentException>(() => BWT.Detransform(string.Empty, 0));
    }

    [Fact]
    private void Detransform_IncorrectPosition()
    {
        Assert.Throws<ArgumentException>(() => BWT.Detransform("123", 123));
    }

    [Fact]
    private void Transform_Then_Detransform()
    {
        var input = "BANANA";
        (string output, int position) = BWT.Transform(input);
        Assert.Equal(input, BWT.Detransform(output, position));
    }
}