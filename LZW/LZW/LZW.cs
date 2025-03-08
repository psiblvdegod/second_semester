namespace LZW;

using System.Text;
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

        output += '\n';

        var tail = string.Empty;

        for (var i = 0; i <= input.Length; ++i)
        {
            while (i < input.Length && !dictionary.Add(tail + input[i]))
            {
                tail += input[i++];
            }

            var significant = Convert.ToString(dictionary.Find(tail), 2);
    
            output = string.Concat(output, significant, ' ');

            if (i < input.Length)
            {
                tail = input[i].ToString();
            }
        }
    
        return output;
    }

    public static string Decompress(string input)
    {
        var dictionary = new Trie();

        foreach (var c in input[..input.IndexOf('\n')])
        {
            dictionary.Add(c);
        }

        var output = string.Empty;

        var tail = string.Empty;

        foreach (var b in input[(input.IndexOf('\n') + 1)..].Split(" "))
        {
            var s = Convert.ToInt32(b, 2).ToString();

            if (dictionary.Add(tail + s))
            {
                output += tail;
                tail = s;
            }
        }

        output += tail;

        return output;
    }
}