namespace BWTxLZW.Tests;


public class Tests
{
    [Test]
    public void Compress_Then_Decompress()
    {
        var input = "ababcbabcbacbabc";

        (var output, var position) = BWTxLZW.Compress(input);

        Assert.That(BWTxLZW.Decompress(output, position), Is.EqualTo(input));
    }
}
