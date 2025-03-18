// <copyright file = "Tests.cs" author = "psiblvdegod" date = "2025">
// under MIT license
// </copyright>

#pragma warning disable SA1600

namespace BWTxLZW.Tests;

/// <summary>
/// Tests for functions from BWTxLZW.cs.
/// </summary>
[TestFixture]
public class Tests
{
    [Test]
    public static void Compress_On_EmptyString()
        => Assert.That(() => BWTxLZW.Compress(string.Empty), Throws.ArgumentException);

    [Test]
    public static void Decompress_On_EmptyString()
        => Assert.That(() => BWTxLZW.Decompress(string.Empty), Throws.ArgumentException);

    [Test]
    public void Compress_Then_Decompress_On_Ordinary_Input()
    {
        var input = "some_simple_text_to_compress";

        Assert.That(BWTxLZW.Decompress(BWTxLZW.Compress(input)), Is.EqualTo(input));
    }

    [Test]
    public void Compress_Then_Decompress_On_Big_Text()
    {
        var path = "../../../../DataForTests/TestData.txt";

        var input = File.ReadAllText(path);

        Assert.That(BWTxLZW.Decompress(BWTxLZW.Compress(input)), Is.EqualTo(input));
    }
}