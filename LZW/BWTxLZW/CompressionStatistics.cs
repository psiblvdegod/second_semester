// <copyright file = "CompressionStatistics.cs" author = "psiblvdegod" date = "2025">
// under MIT license
// </copyright>

namespace BWTxLZW;

/// <summary>
/// Contains methods which allow analyse efficiency of compression made with LZW algorithm.
/// </summary>
public static class CompressionStatistics
{
    /// <summary>
    /// Calculates compression ratio of file, compressed using some algorithm.
    /// </summary>
    /// <param name="pathToInitialFile">Path to file which was used to create compressed file.</param>
    /// <returns>returns compression ratio.</returns>
    public static double GetCompressionRatio(string pathToInitialFile)
    {
        var infoOfInitial = new FileInfo(pathToInitialFile);

        if (!infoOfInitial.Exists)
        {
            throw new FileNotFoundException("Initial file not found.");
        }

        var pathOfCompressed = $"{pathToInitialFile}.zipped";
        var infoOfCompressed = new FileInfo(pathOfCompressed);

        if (!infoOfCompressed.Exists)
        {
            throw new FileNotFoundException("Compressed file not found.");
        }

        return (double)infoOfInitial.Length / infoOfCompressed.Length;
    }
}
