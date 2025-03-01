namespace LZW.Tests;

using NUnit;

[TestFixture]
public class Tests
{
    [Test]
    public void Compress_WithOrdinaryInput()
    {
        var input = "abacabadabacabae";

        Assert.That(LZW.Compress(input), Is.EqualTo("01025039864"));
        /*
        a - 0
        b - 1
        c - 2
        ab - 3
        ba - 4
        ac - 5
        ca - 6
        */
    }
}
