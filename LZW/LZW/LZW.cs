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

        var length = 5;
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

        string GetBinNumber(string seq)
        {
            var significant = Convert.ToString(dictionary.Find(seq), 2);
            var zeros = new string('0', length - significant.Length);
            return zeros + significant;
        }
    }

    public static string Decompress(string input)
    {
        var dictionary = new List<string>();

        var length = 5;

        foreach (var c in input[..input.IndexOf('$')])
        {
            dictionary.Add(c.ToString());
        }

        var output = string.Empty;

        var tail = string.Empty;

        for (var i = input.IndexOf('$') + 1; i + length <= input.Length; i += length)
        {
            var current = dictionary[Convert.ToInt32(input[i..(i + length)], 2)];

            output += current;

            if (!dictionary.Contains(tail + current))
            {
                dictionary.Add(tail + current);
                tail = current;
            }
            else
            {
                tail += current;
            }
        }

        return output;
    }
}