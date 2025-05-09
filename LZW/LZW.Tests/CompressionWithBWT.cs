// <copyright file="CompressionWithBWT.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>

#pragma warning disable SA1600

namespace LZW.Tests;

using static LZW.CompressionWithBWT;

/// <summary>
/// Tests for functions from BWTxLZW.cs.
/// </summary>
[TestFixture]
public class CompressionWithBWT
{
    [Test]
    public static void Compress_On_EmptyString()
        => Assert.That(() => Compress(string.Empty), Throws.ArgumentException);

    [Test]
    public static void Decompress_On_EmptyString()
        => Assert.That(() => Decompress(string.Empty), Throws.ArgumentException);

    [Test]
    public void Compress_Then_Decompress_OnSmallText()
    {
        var input = "some_simple_text_to_compress";

        Assert.That(Decompress(Compress(input)), Is.EqualTo(input));
    }

    [Test]
    public void Compress_Then_Decompress_OnBigText()
    {
        var path = "../../../../DataForTests/TextForTest.txt";

        var input = File.ReadAllText(path);

        Assert.That(Decompress(Compress(input)), Is.EqualTo(input));
    }
}
