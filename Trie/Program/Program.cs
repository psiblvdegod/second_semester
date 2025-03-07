using static LZW.LZW;
using System.Linq.Expressions;

if (args.Length != 2)
{
    Console.WriteLine("Specify params.");
    return -1;
}

if (args[1] == "c")
{
    var input = File.ReadAllText(args[0]);

    var result = Compress(input);

    var dir = args[0][(args[0].LastIndexOf('/') + 1)..];

    var stream = File.CreateText(dir + ".zipped");

    try
    {
        stream.Write(result);
    }
    finally
    {
        stream.Close();
    }
}

if (args[1] == "-u")
{
    if (args[0][args[0].LastIndexOf('.')..] != ".zipped")
    {
        throw new ArgumentException("Invalid file format.");
    }

    var input = File.ReadAllText(args[0]);
}

return 0;