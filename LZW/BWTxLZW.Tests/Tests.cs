// <copyright file = "BWT.cs" author = "psiblvdegod" date = "2025">
// under MIT license
// </copyright>

namespace BWTxLZW.Tests;

/// <summary>
/// Tests for functions from BWTxLZW.cs.
/// </summary>
public class Tests
{
    [Test]
    public void Compress_Then_Decompress()
    {
        var input = "some_kind_of_simple_text_to_compress";

        Assert.That(BWTxLZW.Decompress(BWTxLZW.Compress(input)), Is.EqualTo(input));
    }
}
