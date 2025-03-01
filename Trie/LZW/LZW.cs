namespace LZW;

using System.Text;
using Trie;

static public class LZW
{
    public static string Compress(string input)
    {
        var dictionary = new Trie();

        foreach (var c in input)
        {
            dictionary.Add(c);
        }

        var output = string.Empty;

        var current = string.Empty;

        for (var i = 0; i < input.Length; ++i)
        {
            while (i < input.Length && !dictionary.Add(current + input[i]))
            {
                current += input[i++];
            }

            output += dictionary.Find(current);

            if (i < input.Length)
            {
                current = input[i].ToString();
            }
        }
    
        return output;
    } 
}