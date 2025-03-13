namespace LZW;

public static class InputProcessing
{
    public static void ProcessInput(string[] args)
    {
        if (args.Length != 2)
        {
            throw new ArgumentException("Incorrect number of arguments.");
        }

        ArgumentNullException.ThrowIfNullOrEmpty(args[0]);
        ArgumentNullException.ThrowIfNullOrEmpty(args[1]);

        if (args[1] == "c")
        {
            Compress(args[0]);
        }
        else if (args[1] == "u")
        {
            Decompress(args[0]);
        }
        else
        {
            throw new ArgumentException("Invalid switch passed.");
        }

    }

    private static void Compress(string path)
    {
        var input = File.ReadAllText(path);

        var result = LZW.Compress(input);

        var newFilePath = $"{path}.zipped";

        var stream = File.CreateText(newFilePath);

        try
        {
            stream.Write(result);
        }
        finally
        {
            stream.Close();
        }

        CompressionStatistics.Print(path);
    }

    private static void Decompress(string path)
    {
        if (path[path.LastIndexOf('.')..] != ".zipped")
        {
            throw new ArgumentException("Invalid file format.");
        }

        var input = File.ReadAllText(path);
        var result = LZW.Decompress(input);

        var newFilePath = path[..path.LastIndexOf('.')];
        var stream = File.CreateText(newFilePath);

        try
        {
            stream.Write(result);
        }
        finally
        {
            stream.Close();
        }
    }
}