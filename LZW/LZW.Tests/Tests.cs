// <copyright file = "Tests.cs" author = "psiblvdegod" date = "2025">
// under MIT license
// </copyright>

#pragma warning disable SA1600

namespace LZW.Tests;

/// <summary>
/// Tests methods from LZW.cs.
/// </summary>
[TestFixture]
public class Tests
{
    [Test]
    public static void Compress_On_EmptyString()
        => Assert.That(() => LZW.Compress(string.Empty), Throws.ArgumentException);

    [Test]
    public static void Decompress_On_EmptyString()
        => Assert.That(() => LZW.Decompress(string.Empty), Throws.ArgumentException);

    [Test]
    public static void Compress_Then_Decompress_OnOrdinaryInput()
    {
        var input = "some_simple_string_to_compress";

        var compressOutput = LZW.Compress(input);

        var decompessOutput = LZW.Decompress(compressOutput);

        Assert.That(decompessOutput, Is.EqualTo(input));
    }

    [Test]
    public static void Compress_Then_Decompress_OnStringOfOneSymbol()
    {
        var input = "1";

        var compressOutput = LZW.Compress(input);

        var decompessOutput = LZW.Decompress(compressOutput);

        Assert.That(decompessOutput, Is.EqualTo(input));
    }
}