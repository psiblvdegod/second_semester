namespace LZW.Tests;

using NUnit;

[TestFixture]
public class Tests
{
    [Test]
    public void Compress_WithOrdinaryInput()
    {
        var input = "abacabababa";

        Assert.That(LZW.Compress(input), Is.EqualTo("0102374"));
    }

    [Test]
    public void Compress_WithSequenceOfIdentialChar()
    {
        var input = "88888888";

        Assert.That(LZW.Compress(input), Is.EqualTo("0121"));
    }

    [Test]
    public void Compress_WithInputThatCannotBeCompressed()
    {
        var input = "ACBD";

        Assert.That(LZW.Compress(input), Is.EqualTo("0123"));
    }

    [Test]
    public void Compress_WithInputFromWikiIfmo()
    {
        var input = "abacabadabacabae";

        Assert.That(LZW.Compress(input), Is.EqualTo("01025039864"));
        /*
        a - 0
        b - 1
        c - 2
        d - 3
        e - 4
        ab - 5
        ba - 6
        ac - 7
        ca - 8
        aba - 9
        ad - 10
        da - 11
        abac - 12
        cab - 13
        */
    }

    [Test]
    public void Compress_WithInputFromHabr()
    {
        var input = "banana_bandana";

        Assert.That(LZW.Compress(input), Is.EqualTo("0126135248"));
        /*
        b - 0
        a - 1
        n - 2
        _ - 3
        d - 4
        ba - 5
        an - 6
        na - 7
        ana - 8
        a_ - 9
        _b - 10
        ban - 11
        nd - 12
        da - 13
        */
    }
}
