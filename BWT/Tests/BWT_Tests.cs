// <copyright file = "BWT_Tests.cs" author = "psiblvdegod" date = "2025">
// under MIT license
// </copyright>

// SA1600 : Elements should be documented.
#pragma warning disable SA1600

namespace Tests;

using BWT;

/// <summary>
/// Tests for functions from BWT.cs.
/// </summary>
public class BWT_Tests
{
    [Test]
    public void GetTransformedStringAndPosition_OrdinaryInput()
    {
        var input = "ABACABA";
        var expectedOutput = "BCABAAA";
        var expectedPosition = 2;

        Assert.That(BWT.GetTransformedStringAndPosition(input), Is.EqualTo((expectedOutput, expectedPosition)));
    }

    [Test]
    public void GetTransformedStringAndPosition_OneSymbolAsInput()
    {
        var input = "C";
        var expectedOutput = "C";
        var expectedPosition = 0;

        Assert.That(BWT.GetTransformedStringAndPosition(input), Is.EqualTo((expectedOutput, expectedPosition)));
    }

    [Test]
    public void GetTransformedStringAndPosition_StrOfIdentialCharsAsInput()
    {
        var input = "1111";
        var expectedOutput = "1111";
        var expectedPosition = 0;

        Assert.That(BWT.GetTransformedStringAndPosition(input), Is.EqualTo((expectedOutput, expectedPosition)));
    }

    [Test]
    public void GetTransformedStringAndPosition_EmptyStringAsInput()
    {
        Assert.Throws<ArgumentException>(() => BWT.GetTransformedStringAndPosition(string.Empty));
    }

    [Test]
    public void GetDetransformedString_OrdinaryInput()
    {
        var input = "BCABAAA";
        var position = 2;
        var expectedOutput = "ABACABA";

        Assert.That(BWT.GetDetransformedString(input, position), Is.EqualTo(expectedOutput));
    }

    [Test]
    public void GetDetransformedString_OneSymbolAsInput()
    {
        var input = "C";
        var position = 0;
        var expectedOutput = "C";

        Assert.That(BWT.GetDetransformedString(input, position), Is.EqualTo(expectedOutput));
    }

    [Test]
    public void GetDetransformedString_StrOfIdentialCharsAsInput()
    {
        var input = "4444";
        var position = 0;
        var expectedOutput = "4444";

        Assert.That(BWT.GetDetransformedString(input, position), Is.EqualTo(expectedOutput));
    }

    [Test]
    public void GetDetransformedString_EmptyStringAsInput()
    {
        Assert.Throws<ArgumentException>(() => BWT.GetDetransformedString(string.Empty, 0));
    }

    [Test]
    public void GetDetransformedString_IncorrectPosition()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => BWT.GetDetransformedString("123", 123));
    }

    [Test]
    public void GetTransformedStringAndPosition_Then_GetDetransformedString()
    {
        var input = "BANANA";
        (string output, int position) = BWT.GetTransformedStringAndPosition(input);
        Assert.That(BWT.GetDetransformedString(output, position), Is.EqualTo(input));
    }
}
