using static LZW.LZW;
using System.Linq.Expressions;

args = ["/home/psi/Desktop/second_semester/Trie/Program/text.txt", "c"];

if (args.Length != 2)
{
    throw new ArgumentException("Incorrect number of parameters.");
}

if (args[1] == "c")
{
    var input = File.ReadAllText(args[0]);

    var result = Compress(input);

    var stream = File.CreateText($"{args[0]}.zipped");

    try
    {
        stream.Write(result);
    }
    finally
    {
        stream.Close();
    }
}

else if (args[1] == "u")
{
    if (args[0][args[0].LastIndexOf('.')..] != ".zipped")
    {
        throw new ArgumentException("Invalid file format.");
    }

    var input = File.ReadAllText(args[0]);
    var result = Decompress(input);
    var stream = File.CreateText(args[0][..args[0].LastIndexOf('.')]);

    try
    {
        stream.Write(result);
    }
    finally
    {
        stream.Close();
    }
}

else 
{
    throw new ArgumentException("Invalid switch.");
}

return 0;