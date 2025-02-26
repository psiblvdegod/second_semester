// <copyright file = "BWT_Tests.cs" author = "psiblvdegod" date = "2025">
// under MIT license
// </copyright>

namespace Tests;

using BWT;
using NUnit;

/// <summary>
/// Tests for functions from BWT.cs.
/// </summary>
public class BWT_Tests
{
    [Test]
    public void Transform_OrdinaryInput()
    {
        var input = "ABACABA";
        var expectedOutput = "BCABAAA";
        var expectedPosition = 2;

        Assert.That(BWT.Transform(input), Is.EqualTo((expectedOutput, expectedPosition)));
    }

    [Test]
    public void Transform_OneSymbolAsInput()
    {
        var input = "C";
        var expectedOutput = "C";
        var expectedPosition = 0;

        Assert.That(BWT.Transform(input), Is.EqualTo((expectedOutput, expectedPosition)));
    }

    [Test]
    public void Transform_StrOfIdentialCharsAsInput()
    {
        var input = "1111";
        var expectedOutput = "1111";
        var expectedPosition = 0;

        Assert.That(BWT.Transform(input), Is.EqualTo((expectedOutput, expectedPosition)));
    }

    [Test]
    public void Transform_EmptyStringAsInput()
    {
        Assert.Throws<ArgumentException>(() => BWT.Transform(string.Empty));
    }

    [Test]
    public void Detransform_OrdinaryInput()
    {
        var input = "BCABAAA";
        var position = 2;
        var expectedOutput = "ABACABA";

        Assert.That(BWT.Detransform(input, position), Is.EqualTo(expectedOutput));
    }

    [Test]
    public void Detransform_OneSymbolAsInput()
    {
        var input = "C";
        var position = 0;
        var expectedOutput = "C";

        Assert.That(BWT.Detransform(input, position), Is.EqualTo(expectedOutput));
    }

    [Test]
    public void Detransform_StrOfIdentialCharsAsInput()
    {
        var input = "4444";
        var position = 0;
        var expectedOutput = "4444";

        Assert.That(BWT.Detransform(input, position), Is.EqualTo(expectedOutput));
    }

    [Test]
    public void Detransform_EmptyStringAsInput()
    {
        Assert.Throws<ArgumentException>(() => BWT.Detransform(string.Empty, 0));
    }

    [Test]
    public void Detransform_IncorrectPosition()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => BWT.Detransform("123", 123));
    }

    [Test]
    public void Transform_Then_Detransform()
    {
        var input = "BANANA";
        (string output, int position) = BWT.Transform(input);
        Assert.That(BWT.Detransform(output, position), Is.EqualTo(input));
    }
}