namespace LZW;

public static class CompressionStatistics
{
    public static void Print(string pathOfInitial)
    {
        var infoOfInitial = new FileInfo(pathOfInitial);

        if (!infoOfInitial.Exists)
        {
            Console.WriteLine("Compression statistics can not be obtained.");
            Console.WriteLine("Initial file not found.");
            return;
        }

        var pathOfCompressed = $"{pathOfInitial}.zipped";
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