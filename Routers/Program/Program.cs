using MST;

if (args.Length != 1)
{
    Console.Error.WriteLine("Incorrect number of command line arguments.");
    return 1;
}

var input = File.ReadAllText(args[0]);

var output = string.Empty;

try 
{
    (output, _) = MST.MST.Build(input);
}
catch (Graph.InvalidTopologyException ex)
{
    Console.Error.WriteLine(ex.Message);
    return 2;
}

File.WriteAllText($"{args[0]}.optimal", output);

return 0;
