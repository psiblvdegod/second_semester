// <copyright file = "LZW.cs" author = "psiblvdegod" date = "2025">
// under MIT license
// </copyright>

namespace LZW;

using Trie;

/// <summary>
/// Contains methods which allow compress and decompess files using LZW algorithm.
/// </summary>
public static class LZW
{
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

        output += '$';

        var length = 16;
        var freeSpace = (int)Math.Pow(2, length) - dictionary.Size;

        var tail = string.Empty;

        foreach (var c in input)
        {
            if (dictionary.Add(tail + c))
            {
                output += GetBinNumber(tail);
                tail = c.ToString();

                if (--freeSpace <= 0)
                {
                    freeSpace = -(int)Math.Pow(2, length++) + (int)Math.Pow(2, length);
                }
            }
            else
            {
                tail += c;
            }
        }

        return output + GetBinNumber(tail);

        string GetBinNumber(string seq)
        {
            var significant = Convert.ToString(dictionary.Find(seq), 2);
            var zeros = new string('0', length - significant.Length);
            return zeros + significant;
        }
    }

    public static byte[] Compress(byte[] input)
    {
        var stringRepresentation = Convert.ToBase64String(input);

        var compressedStringRepresentation = Compress(stringRepresentation);

        return Convert.FromBase64String(compressedStringRepresentation);
    }

    /// <summary>
    /// Decompresses string using LZW algorithm.
    /// </summary>
    /// <param name="input">Compressed string.</param>
    /// <returns>Initial string.</returns>
    public static string Decompress(string input)
    {
        ArgumentException.ThrowIfNullOrEmpty(input);

        var dictionary = new Dictionary<int, string>();

        var separatorIndex = input.IndexOf('$');

        for (var i = 0; i < separatorIndex; ++i)
        {
            dictionary[i] = input[i].ToString();
        }

        var length = 16;
        var freeSpace = (int)Math.Pow(2, length) - dictionary.Count;

        var tail = dictionary[Convert.ToInt32(input[(separatorIndex + 1)..(separatorIndex + 1 + length)], 2)];

        var output = tail;

        for (var i = separatorIndex + 1 + length; i + length <= input.Length; i += length)
        {
            var code = Convert.ToInt32(input[i..(i + length)], 2);

            var current = code < dictionary.Count ? dictionary[code] : tail + tail[0];

            output += current;

            if (--freeSpace <= 0)
            {
                freeSpace = -(int)Math.Pow(2, length++) + (int)Math.Pow(2, length);
            }

            if (!dictionary.ContainsValue(tail + current[0]))
            {
                dictionary[dictionary.Count] = tail + current[0];
            }

            tail = current;
        }

        return output;
    }

    public static byte[] Decompress(byte[] input)
    {
        var stringRepresentation = Convert.ToBase64String(input);

        var compressedStringRepresentation = Decompress(stringRepresentation);

        return Convert.FromBase64String(compressedStringRepresentation);
    }
}
