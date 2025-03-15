// <copyright file = "InputProcessing.cs" author = "psiblvdegod" date = "2025">
// under MIT license
// </copyright>

namespace BWTxLZW;

/// <summary>
/// Contains methods which processes user input allowing work with files using LZW algorithm.
/// </summary>
public static class InputProcessing
{
    /// <summary>
    /// Detransforms string which has been transformed with Burrows-Wheeler algorithm.
    /// </summary>
    /// <param name="args">Should contain 2 params : path to file and switch --c or --u.</param>
    public static void ProcessInput(string[] args)
    {
        if (args.Length != 2)
        {
            throw new ArgumentException("Incorrect number of arguments.");
        }

        ArgumentNullException.ThrowIfNullOrEmpty(args[0]);
        ArgumentNullException.ThrowIfNullOrEmpty(args[1]);

        if (args[1] == "--c")
        {
            Compress(args[0]);
        }
        else if (args[1] == "--u")
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

        var result = BWTxLZW.Compress(input);

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

        Console.WriteLine(CompressionStatistics.GetCompressionRatio(path));
    }

    private static void Decompress(string path)
    {
        if (path[path.LastIndexOf('.')..] != ".zipped")
        {
            throw new ArgumentException("Invalid file format.");
        }

        var input = File.ReadAllText(path);
        var result = BWTxLZW.Decompress(input);

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
