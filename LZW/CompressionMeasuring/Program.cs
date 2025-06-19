// <copyright file="Program.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>

/// <summary>
/// Measures the effect of BWT on compression ratio.
/// </summary>
var pathForFirstMeasurement = "../DataForTests/BigTextForTest.txt";
var resultOfFirstMeasurement = MeasureOnText(pathForFirstMeasurement);

var pathForSecondMeasurement = "../DataForTests/BigBinaryForTest";
var resultOfSecondMeasurement = MeasureOnBinary(pathForSecondMeasurement);

Console.WriteLine($"on text: compression ratio = {resultOfFirstMeasurement.CompressionRatio}, text is {resultOfFirstMeasurement.ImpactOfBWT} times bigger with no BWT.");
Console.WriteLine($"on binary: copression ratio = {resultOfSecondMeasurement.CompressionRatio}, text is {resultOfSecondMeasurement.ImpactOfBWT} times bigger with no BWT.");

static (double CompressionRatio, double ImpactOfBWT) MeasureOnText(string path)
{
    var input = File.ReadAllText(path);
    var outputWithNoBWT = LZW.Compression.Compress(input);
    var outputWithBWT = LZW.CompressionWithBWT.Compress(input);

    if (LZW.Compression.Decompress(outputWithNoBWT) != input)
    {
        throw new Exception("Compression corrupted the data.");
    }

    if (LZW.CompressionWithBWT.Decompress(outputWithBWT) != input)
    {
        throw new Exception("Compression with BWT corrupted the data.");
    }

    var compressionRatio = (double)input.Length / outputWithBWT.Length;
    var impactOfBWT = (double)outputWithNoBWT.Length / outputWithBWT.Length;
    return (compressionRatio, impactOfBWT);
}

static (double CompressionRatio, double ImpactOfBWT) MeasureOnBinary(string path)
{
    var input = File.ReadAllBytes(path);
    var outputWithNoBWT = LZW.Compression.Compress(input);
    var outputWithBWT = LZW.CompressionWithBWT.Compress(input);

    if (!LZW.Compression.Decompress(outputWithNoBWT).SequenceEqual(input))
    {
        throw new Exception("Compression corrupted the data.");
    }

    if (!LZW.CompressionWithBWT.Decompress(outputWithBWT).SequenceEqual(input))
    {
        throw new Exception("Compression with BWT corrupted the data.");
    }

    var compressionRatio = (double)input.Length / outputWithBWT.Length;
    var impactOfBWT = (double)outputWithNoBWT.Length / outputWithBWT.Length;
    return (compressionRatio, impactOfBWT);
}
