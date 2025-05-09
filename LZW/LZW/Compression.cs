// <copyright file="Compression.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>

namespace LZW;

using System.Text;
using Trie;

/// <summary>
/// Contains methods which allow compress and decompess files using LZW algorithm.
/// </summary>
public static class Compression
{
    private static readonly char SeparatingSymbol = '$';

    private static readonly Encoding Encoding
        = Encoding.GetEncoding("ISO-8859-1");

    private static readonly Encoder Encoder
        = new("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!#%&'()*+,-./:;<=>?@[]^_`{|}~¢£¤¥¦§¨©ª«¬®¯°±²³´µ¶·¸¹º»¼½¾¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿ");

    /// <summary>
    /// Compresses string using LZW algorithm.
    /// </summary>
    /// <param name="input">String which will be transformed.</param>
    /// <returns>Compressed string.</returns>
    public static string Compress(string input)
    {
        ArgumentException.ThrowIfNullOrEmpty(input);

        var dictionary = new Trie();
        var output = CreatePrefix();
        var tail = string.Empty;

        foreach (var c in input)
        {
            if (dictionary.Add(tail + c))
            {
                output += GetCodeOfNumberOf(tail) + SeparatingSymbol;
                tail = c.ToString();
            }
            else
            {
                tail += c;
            }
        }

        return output + GetCodeOfNumberOf(tail);

        string GetCodeOfNumberOf(string data)
            => Encoder.Encode(dictionary.FindNumberOf(data));

        string CreatePrefix()
        {
            var result = string.Empty;

            foreach (var symbol in input)
            {
                if (dictionary.Add(symbol))
                {
                    result += symbol;
                }
            }

            return result + SeparatingSymbol;
        }
    }

    /// <summary>
    /// Decompresses string using LZW algorithm.
    /// </summary>
    /// <param name="input">Compressed string.</param>
    /// <returns>Initial string.</returns>
    public static string Decompress(string input)
    {
        ArgumentException.ThrowIfNullOrEmpty(input);

        var separatorIndex = input.IndexOf(SeparatingSymbol);
        var dictionary = InitializeDictionaryWithPrefix();
        var tail = string.Empty;
        var output = tail;

        var records = input[(separatorIndex + 1)..].Split(SeparatingSymbol);

        foreach (var record in records)
        {
            var code = Encoder.Decode(record);
            var current = code < dictionary.Count ? dictionary[code] : tail + tail[0];
            output += current;

            if (!dictionary.ContainsValue(tail + current[0]))
            {
                dictionary[dictionary.Count] = tail + current[0];
            }

            tail = current;
        }

        return output;

        Dictionary<int, string> InitializeDictionaryWithPrefix()
        {
            var dictionary = new Dictionary<int, string>();

            for (var i = 0; i < separatorIndex; ++i)
            {
                dictionary[i] = input[i].ToString();
            }

            return dictionary;
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
    /// Decompresses byte sequence using LZW algorithm.
    /// </summary>
    /// <param name="input">Compressed byte sequence.</param>
    /// <returns>Initial byte sequence.</returns>
    public static byte[] Decompress(byte[] input)
        => Encoding.GetBytes(Decompress(Encoding.GetString(input)));
}
