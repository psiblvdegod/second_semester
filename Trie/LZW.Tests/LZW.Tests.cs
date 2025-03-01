namespace LZW.Tests;

using NUnit;

[TestFixture]
public class Tests
{
    [Test]
    public void Compress_WithOrdinaryInput()
    {
        var input = "abacaba";

        Assert.That(LZW.Compress(input), Is.EqualTo("010230"));
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
