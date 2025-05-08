// <copyright file="CompressionWithBWT.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LZW;

using System.Text;
using BWT;

/// <summary>
/// Contains methods from LZW.Compression, improved by Burrows-Wheeler transform.
/// </summary>
public static class CompressionWithBWT
{
    private static readonly Encoding Encoding = Encoding.GetEncoding("ISO-8859-1");
    private static readonly char SeparatingSymbol = '$';

    /// <summary>
    /// Compresses string using LZW and BWT algorithms.
    /// </summary>
    /// <param name="input">String which will be compressed.</param>
    /// <returns>Compressed string.</returns>
    public static string Compress(string input)
    {
        ArgumentException.ThrowIfNullOrEmpty(input);
        var (output, position) = BWT.Transform(Compression.Compress(input));
        return string.Concat(position, SeparatingSymbol, output);
    }

    /// <summary>
    /// Compresses byte sequence using LZW and BWT algorithms.
    /// </summary>
    /// <param name="input">Byte sequence which will be compressed.</param>
    /// <returns>Compressed byte sequence.</returns>
    public static byte[] Compress(byte[] input)
        => Encoding.GetBytes(Compress(Encoding.GetString(input)));

    /// <summary>
    /// Decompresses string which has been transformed with Compress() method.
    /// </summary>
    /// <param name="input">String which will be decompressed.</param>
    /// <returns>Initial string.</returns>
    public static string Decompress(string input)
    {
        ArgumentException.ThrowIfNullOrEmpty(input);
        var separatorIndex = input.IndexOf(SeparatingSymbol);
        var position = int.Parse(input[..separatorIndex]);
        return Compression.Decompress(BWT.Detransform(input[(separatorIndex + 1)..], position));
    }

    /// <summary>
    /// Decompresses byte sequence which has been transformed with Compress() method.
    /// </summary>
    /// <param name="input">Byte sequence which will be decompressed.</param>
    /// <returns>Initial byte sequence.</returns>
    public static byte[] Decompress(byte[] input)
        => Encoding.GetBytes(Decompress(Encoding.GetString(input)));
}
