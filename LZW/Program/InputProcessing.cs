// <copyright file = "InputProcessing.cs" author = "psiblvdegod" date = "2025">
// under MIT license
// </copyright>

namespace FileCompression;

using BWTxLZW;

/// <summary>
/// User reques processing allowing use methods of BWTxLZW class on files.
/// </summary>
public static class InputProcessing
{
    /// <summary>
    /// Detransforms string which has been transformed with Burrows-Wheeler algorithm.
    /// </summary>
    /// <param name="args">Should contain 2 params: path to file and switch --c or --u.</param>
    public static void Run(string[] args)
    {
        if (args.Length != 2)
        {
            throw new ArgumentException("Incorrect number of arguments.");
        }

        ArgumentException.ThrowIfNullOrEmpty(args[0]);
        ArgumentException.ThrowIfNullOrEmpty(args[1]);

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
        var newFilePath = $"{path}.zipped";

        if (path.EndsWith(".txt"))
        {
            var input = File.ReadAllText(path);
            var result = BWTxLZW.Compression.Compress(input);
            File.WriteAllText(newFilePath, result);
        }
        else
        {
            var input = File.ReadAllBytes(path);
            var result = BWTxLZW.Compression.Compress(input);
            File.WriteAllBytes(newFilePath, result);
        }

        Console.WriteLine(CompressionStatistics.GetCompressionRatio(path));
    }

    private static void Decompress(string path)
    {
        if (!path.EndsWith(".zipped"))
        {
            throw new ArgumentException("Invalid file format.");
        }

        var newFilePath = path[..path.LastIndexOf('.')];

        if (path.EndsWith(".txt.zipped"))
        {
            var input = File.ReadAllText(path);
            var result = BWTxLZW.Compression.Decompress(input);
            File.WriteAllText(newFilePath, result);
        }
        else
        {
            var input = File.ReadAllBytes(path);
            var result = BWTxLZW.Compression.Decompress(input);
            File.WriteAllBytes(newFilePath, result);
        }
    }
}
