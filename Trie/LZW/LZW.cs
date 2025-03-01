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

        var tail = string.Empty;

        for (var i = 0; i <= input.Length; ++i)
        {
            while (i < input.Length && !dictionary.Add(tail + input[i]))
            {
                tail += input[i++];
            }

            output += dictionary.Find(tail);


            if (i < input.Length)
            {
                tail = input[i].ToString();
            }
        }
    
        return output;
    } 
}