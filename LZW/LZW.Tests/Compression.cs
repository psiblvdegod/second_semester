// <copyright file="Compression.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>

#pragma warning disable SA1600

namespace LZW.Tests;

using static LZW.Compression;

/// <summary>
/// Tests methods from LZW.cs.
/// </summary>
[TestFixture]
public class Compression
{
    [Test]
    public static void Compress_On_EmptyString_ShouldThrowException()
        => Assert.Throws<ArgumentException>(() => Compress(string.Empty));

    [Test]
    public static void Decompress_On_EmptyString_ShouldThrowException()
        => Assert.Throws<ArgumentException>(() => Decompress(string.Empty));

    [Test]
    public static void Compress_Then_Decompress_OnOrdinaryInput()
    {
        var input = "some_simple_string_to_compress";

        var compressOutput = Compress(input);

        var decomrpessOutput = Decompress(compressOutput);

        Assert.That(decomrpessOutput, Is.EqualTo(input));
    }

    [Test]
    public static void Compress_Then_Decompress_OnStringOfOneSymbol()
    {
        var input = "1";

        var compressOutput = Compress(input);

        var decomrpessOutput = Decompress(compressOutput);

        Assert.That(decomrpessOutput, Is.EqualTo(input));
    }

    [Test]
    public static void Compress_Then_Decompress_OnBigText()
    {
        var path = "../../../../DataForTests/TextForTest.txt";

        var input = File.ReadAllText(path);

        var compressOutput = Compress(input);

        var decomrpessOutput = Decompress(compressOutput);

        Assert.That(decomrpessOutput, Is.EqualTo(input));
    }

    [Test]
    public static void Compress_Then_Decompress_OnByteArray()
    {
        byte[] input = [72, 101, 108, 108, 111, 255];

        var compressOutput = Compress(input);

        var decomrpessOutput = Decompress(compressOutput);

        Assert.That(decomrpessOutput, Is.EqualTo(input));
    }

    [Test]
    public static void Compress_Then_Decompress_OnBigBinary()
    {
        var path = "../../../../DataForTests/BinaryForTest";

        var input = File.ReadAllBytes(path);

        var compressOutput = Compress(input);

        var decomrpessOutput = Decompress(compressOutput);

        Assert.That(decomrpessOutput, Is.EqualTo(input));
    }
}
