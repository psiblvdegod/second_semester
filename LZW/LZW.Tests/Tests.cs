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
    public void Compress_Then_Decompress()
    {
        var input = "f";
        Assert.That(LZW.Decompress(LZW.Compress(input)), Is.EqualTo(input));
    }
}