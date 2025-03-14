// <copyright file = "BWT.cs" author = "psiblvdegod" date = "2025">
// under MIT license
// </copyright>

namespace BWTxLZW;

using BWT;
using LZW;

/// <summary>
/// Contains methods from namespace LZW, improved by Burrows-Wheeler transform.
/// </summary>
public static class BWTxLZW
{
    /// <summary>
    /// Compresses string using LZW and BWT algorithms.
    /// </summary>
    /// <param name="input">String which will be compressed.</param>
    /// <returns>Transformed string and it's position in the table of shifts.</returns>
    public static (string Output, int Position) Compress(string input)
        => BWT.Transform(LZW.Compress(input));

    /// <summary>
    /// Decompresses string which has been transformed with Compress() method.
    /// </summary>
    /// <param name="input">String which will be decompressed.</param>
    /// <param name="position">Position of input string in the shifts table.</param>
    /// <returns>Initial string.</returns>
    public static string Decompress(string input, int position)
        => LZW.Decompress(BWT.Detransform(input, position));
}
