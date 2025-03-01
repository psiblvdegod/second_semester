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

        var current = input[0].ToString();

        for (var i = 1; i < input.Length; ++i)
        {
            while (i < input.Length - 1 && !dictionary.Add(current + input[i]))
            {
                current += input[i];
                ++i;
            }

            output += dictionary.Find(current);

            current = input[i].ToString();
        }
    
        return output;
    } 
}