// <copyright file = "Tests.cs" author = "psiblvdegod" date = "2025">
// under MIT license
// </copyright>

#pragma warning disable SA1600

namespace BWTxLZW.Tests;

/// <summary>
/// Tests for functions from BWTxLZW.cs.
/// </summary>
public class Tests
{
    [Test]
    public void Compress_Then_Decompress_On_Ordinary_Input()
    {
        var input = "some_kind_of_simple_text_to_compress";

        Assert.That(BWTxLZW.Decompress(BWTxLZW.Compress(input)), Is.EqualTo(input));
    }

    [Test]
    public void Compress_Then_Decompress_On_Big_Text()
    {
        var path = "../../../TestData.txt";

        var input = File.ReadAllText(path);

        Assert.That(BWTxLZW.Decompress(BWTxLZW.Compress(input)), Is.EqualTo(input));
    }
}
