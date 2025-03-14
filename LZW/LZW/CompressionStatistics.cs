// <copyright file = "BWT.cs" author = "psiblvdegod" date = "2025">
// under MIT license
// </copyright>

namespace LZW;

/// <summary>
/// Contains methods which allow analyse efficiency of compression made with LZW algorithm.
/// </summary>
public static class CompressionStatistics
{
    /// <summary>
    /// Prints compression statistics.
    /// </summary>
    /// <param name="pathToInitialFile">Path to file which was used to create compressed file.</param>
    public static void Print(string pathToInitialFile)
    {
        var infoOfInitial = new FileInfo(pathToInitialFile);

        if (!infoOfInitial.Exists)
        {
            Console.WriteLine("Compression statistics can not be obtained.");
            Console.WriteLine("Initial file not found.");
            return;
        }

        var pathOfCompressed = $"{pathToInitialFile}.zipped";
        var infoOfCompressed = new FileInfo(pathOfCompressed);

        if (!infoOfCompressed.Exists)
        {
            Console.WriteLine("Compression statistics can not be obtained.");
            Console.WriteLine("Compressed file not found.");
            return;
        }

        var result = (double)infoOfInitial.Length / infoOfCompressed.Length;

        Console.WriteLine($"Compression ratio: {result}");
    }
}