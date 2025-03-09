namespace LZW;

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

        var length = (int)Math.Ceiling(Math.Log2(dictionary.Size));
        var amount = (int)Math.Pow(2, length) - dictionary.Size;
        var tail = string.Empty;

        for (var i = 0; i <= input.Length; ++i)
        {
            while (i < input.Length && !dictionary.Add(tail + input[i]))
            {
                tail += input[i++];
            }

            if (--amount <= 0)
            {
                amount = (int)Math.Pow(2, ++length) - dictionary.Size;
            }

            var significant = Convert.ToString(dictionary.Find(tail), 2);
            var zeros = new string('0', length - significant.Length);
            output = string.Concat(output, zeros, significant);

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

        var length = (int)Math.Ceiling(Math.Log2(input.IndexOf('$')));

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
                output += tail + ' ';
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
}