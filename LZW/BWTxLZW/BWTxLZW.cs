// <copyright file = "BWTxLZW.cs" author = "psiblvdegod" date = "2025">
// under MIT license
// </copyright>

namespace BWTxLZW;

using System.Text;
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
        ArgumentException.ThrowIfNullOrEmpty(input);

        var (output, position) = BWT.Transform(LZW.Compress(input));

        var separator = '%';

        return string.Concat(position, separator, output);
    }

    /// <summary>
    /// Compresses byte sequence using LZW and BWT algorithms.
    /// </summary>
    /// <param name="input">Byte sequence which will be compressed.</param>
    /// <returns>Compressed byte sequence.</returns>
    public static byte[] Compress(byte[] input)
        => Encoding.GetEncoding("ISO-8859-1").GetBytes(Compress(Encoding.GetEncoding("ISO-8859-1").GetString(input)));

    /// <summary>
    /// Decompresses string which has been transformed with Compress() method.
    /// </summary>
    /// <param name="input">String which will be decompressed.</param>
    /// <returns>Initial string.</returns>
    public static string Decompress(string input)
    {
        ArgumentException.ThrowIfNullOrEmpty(input);

        var separatorIndex = input.IndexOf('%');

        var position = int.Parse(input[..separatorIndex]);

        return LZW.Decompress(BWT.Detransform(input[(separatorIndex + 1)..], position));
    }

    /// <summary>
    /// Decompresses byte sequence which has been transformed with Compress() method.
    /// </summary>
    /// <param name="input">Byte sequence which will be decompressed.</param>
    /// <returns>Initial byte sequence.</returns>
    public static byte[] Decompress(byte[] input)
        => Encoding.GetEncoding("ISO-8859-1").GetBytes(Decompress(Encoding.GetEncoding("ISO-8859-1").GetString(input)));
}
