// <copyright file = "Compression.cs" author = "psiblvdegod" date = "2025">
// under MIT license
// </copyright>

namespace LZW;

using System.Text;
using Trie;

/// <summary>
/// Contains methods which allow compress and decompess files using LZW algorithm.
/// </summary>
public static class Compression
{
    private static char SeparatingSymbol { get; } = '$';

    private static Encoding Encoding { get; } = Encoding.GetEncoding("ISO-8859-1");

    /// <summary>
    /// Compresses string using LZW algorithm.
    /// </summary>
    /// <param name="input">String which will be transformed.</param>
    /// <returns>Compressed string.</returns>
    public static string Compress(string input)
    {
        ArgumentException.ThrowIfNullOrEmpty(input);

        var dictionary = new Trie();

        var output = string.Empty;

        foreach (var c in input)
        {
            if (dictionary.Add(c))
            {
                output += c;
            }
        }

        output += SeparatingSymbol;

        var length = 4;

        var tail = string.Empty;

        foreach (var c in input)
        {
            if (dictionary.Add(tail + c))
            {
                output += GetBinNumber(tail);
                tail = c.ToString();
            }
            else
            {
                tail += c;
            }
        }

        return output + GetBinNumber(tail);

        string GetBinNumber(string sequence)
        {
            var significant = Convert.ToString(dictionary.FindNumberOf(sequence), 16);
            var zeros = new string('0', length - significant.Length);
            return zeros + significant;
        }
    }

    /// <summary>
    /// Compresses byte sequence using LZW algorithm.
    /// </summary>
    /// <param name="input">Byte sequence which will be compressed.</param>
    /// <returns>Compressed byte sequence.</returns>
    public static byte[] Compress(byte[] input)
        => Encoding.GetBytes(Compress(Encoding.GetString(input)));

    /// <summary>
    /// Decompresses string using LZW algorithm.
    /// </summary>
    /// <param name="input">Compressed string.</param>
    /// <returns>Initial string.</returns>
    public static string Decompress(string input)
    {
        ArgumentException.ThrowIfNullOrEmpty(input);

        var dictionary = new Dictionary<int, string>();

        var separatorIndex = input.IndexOf(SeparatingSymbol);

        for (var i = 0; i < separatorIndex; ++i)
        {
            dictionary[i] = input[i].ToString();
        }

        var length = 4;

        var tail = dictionary[Convert.ToInt32(input[(separatorIndex + 1)..(separatorIndex + 1 + length)], 2)];

        var output = tail;

        for (var i = separatorIndex + 1 + length; i + length <= input.Length; i += length)
        {
            var code = Convert.ToInt32(input[i..(i + length)], 16);

            var current = code < dictionary.Count ? dictionary[code] : tail + tail[0];

            output += current;

            if (!dictionary.ContainsValue(tail + current[0]))
            {
                dictionary[dictionary.Count] = tail + current[0];
            }

            tail = current;
        }

        return output;
    }

    /// <summary>
    /// Decompresses byte sequence using LZW algorithm.
    /// </summary>
    /// <param name="input">Compressed byte sequence.</param>
    /// <returns>Initial byte sequence.</returns>
    public static byte[] Decompress(byte[] input)
        => Encoding.GetBytes(Decompress(Encoding.GetString(input)));
}
