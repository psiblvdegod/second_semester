namespace LZW;

using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using Trie;

public static class LZW
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

        var tail = input[0].ToString();

        for (var i = 1; i < input.Length; ++i)
        {
            var c = input[i];

            if (dictionary.Find(tail + c) == -1)
            {
                output += dictionary.Find(tail).ToString() + ' ';
                dictionary.Add(tail + c);
                tail = c.ToString();
            }
            else
            {
                tail += c;
            }
        }

        return output + dictionary.Find(tail);
    }


    public static string Decompress(string input)
{
    var dictionary = new Dictionary<int, string>();

    var separatorIndex = input.IndexOf('$');

    for (var i = 0; i < separatorIndex; ++i)
    {
        dictionary[i] = input[i].ToString();
    }

    var seqs = input[(separatorIndex + 1)..].Split(' ');

    var tail = dictionary[int.Parse(seqs[0])]; 
    var output = tail;

    for (var i = 1; i < seqs.Length; ++i)
    {
        var code = int.Parse(seqs[i]);
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
}