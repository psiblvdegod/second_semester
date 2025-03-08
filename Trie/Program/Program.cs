﻿using static LZW.LZW;
using System.Linq.Expressions;

args = ["/home/psi/Desktop/second_semester/Trie/Program/text.txt.zipped", "u"];

if (args.Length != 2)
{
    Console.WriteLine("Specify params.");
    return -1;
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

if (args[1] == "u")
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

return 0;