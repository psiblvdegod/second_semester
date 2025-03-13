namespace LZW.Tests;

using NUnit;
using static LZW;

[TestFixture]
public class Tests
{
    [Test]
    public void Compress_Then_Decompress()
    {
        var input = "f";
        Assert.That(Decompress(Compress(input)), Is.EqualTo(input));
    }
}