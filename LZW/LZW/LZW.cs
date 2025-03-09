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
        var amount = (int)Math.Pow(2, length) - dictionary.Size;
        var tail = string.Empty;

        for (var i = 0; i < input.Length; ++i)
        {
            if (dictionary.Add(tail + input[i]))
            {
                if (--amount <= 0)
                {
                    amount = (int)Math.Pow(2, ++length) - dictionary.Size;
                }

                var significant = Convert.ToString(dictionary.Find(tail), 2);
                var zeros = new string('0', length - significant.Length);
                output = string.Concat(output, zeros, significant);                
                tail = input[i].ToString();
            }
            else 
            {
                tail += input[i];
            }
        }

        var s = Convert.ToString(dictionary.Find(tail), 2);
        var z = new string('0', length - s.Length);
    
        return output + z + s;
    }

    public static string Decompress(string input)
    {
        var dictionary = new Trie();

        var length = 5;

        for (var i = 0; input[i] != '$'; ++i)
        {
            var significant = Convert.ToString(i, 2);
            var zeros = new string('0', length - significant.Length);
            dictionary.Add(zeros + significant);
        }
        
        var amount = (int)Math.Pow(2, length) - dictionary.Size;

        var output = string.Empty;
        var tail = string.Empty;

        for (var i = input.IndexOf('$') + 1; i + length < input.Length; i += length)
        {
            var current = input[i..(i + length)];            

            if (dictionary.Add(tail + current))
            {
                output += tail;
                tail = current;
                
                if (--amount <= 0)
                {
                    amount = (int)Math.Pow(2, ++length) - dictionary.Size;
                }
            }

            else 
            {
                tail += current;
            }
        }

        return output + tail;
    }

    public static string Decompress2(string input)
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