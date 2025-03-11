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
        var dictionary = new Trie();

        var length = 5;

        for (var i = 0; i < input.IndexOf('$'); ++i)
        {
            var significant = Convert.ToString(i, 2);
            var zeros = new string('0', length - significant.Length);
            dictionary.Add(zeros + significant);
        }

        var output = string.Empty;

        var tail = string.Empty;

        for (var i = input.IndexOf('$') + 1; i + length <= input.Length; i += length)
        {
            var current = input[i..(i + length)];

            if (dictionary.Add(tail + current))
            {
                tail = current;
            }
            else
            {
                tail += current;
            }
        }

        return output;
    }

    public static string Decompress2(string input)
    {
        var dictionary = new Dictionary<int, string>();

        var length = 5;

        for (var i = 0; input[i] != '$'; ++i)
        {
            dictionary[i] = input[i].ToString();
        }

        var output = string.Empty;

        var tail = string.Empty;

        for (var i = input.IndexOf('$') + 1; i + length <= input.Length; i += length)
        {
            var index = Convert.ToInt32(input[i..(i + length)], 2);

            var current = string.Empty;

            if (index < dictionary.Count)
            {
                current = dictionary[index];
            }
            else
            {
                current = tail + tail[0];
            }

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
        }

        return output;
    }
}