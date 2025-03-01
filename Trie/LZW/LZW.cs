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

        foreach (var c in input[1..])
        {
            if (!dictionary.Add(current + c))
            {
                current += c;
            }

            output += dictionary.Find(current);

            current = c.ToString();
        }
    
        return output;
    } 
}