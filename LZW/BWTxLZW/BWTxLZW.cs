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
    /// <returns>Compressed string.</returns>
    public static string Compress(string input)
    {
        var (output, position) = BWT.Transform(LZW.Compress(input));

        var separator = '%';

        return string.Concat(position, separator, output);
    }

    /// <summary>
    /// Decompresses string which has been transformed with Compress() method.
    /// </summary>
    /// <param name="input">String which will be decompressed.</param>
    /// <returns>Initial string.</returns>
    public static string Decompress(string input)
    {
        var separatorIndex = input.IndexOf('%');

        var position = int.Parse(input[..separatorIndex]);

        return LZW.Decompress(BWT.Detransform(input[(separatorIndex + 1)..], position));
    }
}