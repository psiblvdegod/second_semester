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
        var input = "ababcbabcbacbabc";

        (var output, var position) = BWTxLZW.Compress(input);

        Assert.That(BWTxLZW.Decompress(output, position), Is.EqualTo(input));
    }
}
