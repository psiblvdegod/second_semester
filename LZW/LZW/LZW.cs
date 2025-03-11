namespace LZW;

using System.Diagnostics;
using System.Text;
using Microsoft.VisualBasic;
using Trie;

static public class LZW
{
    public static string Compress(string input)
    {
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

        var length = (int)Math.Max(1, Math.Ceiling(Math.Log2(dictionary.Size)));
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

    public static string Decompress2(string input)
    {
        var dictionary = new Dictionary<int, string>();

        var separatorIndex = input.IndexOf('$');

        var length = (int)Math.Max(1, Math.Ceiling(Math.Log2(separatorIndex)));
        var freeSpace = (int)Math.Pow(2, length) - separatorIndex;

        for (var i = 0; i < separatorIndex; ++i)
        {
            dictionary[i] = input[i].ToString();
        }

        var output = string.Empty;

        var tail = string.Empty;

        for (var i = separatorIndex + 1; i + length <= input.Length; i += length)
        {
            var code = Convert.ToInt32(input[i..(i + length)], 2);

            var current = code < dictionary.Count ? dictionary[code] : tail + tail[0];

            output += current;

            if (!dictionary.ContainsValue(tail + current))
            {
                dictionary[dictionary.Count] = tail + current;
                tail = current;
            }
            else
            {
                tail += current;
            }

            if (--freeSpace <= 0)
            {
                freeSpace = -(int)Math.Pow(2, length++) + (int)Math.Pow(2, length);
            }
        }

        return output;
    }
}