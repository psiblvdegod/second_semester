// <copyright file = "Program.cs" author = "psiblvdegod" date = "2025">
// under MIT license
// </copyright>

/// <summary>
/// measures the effect of BWT on compression ratio.
/// </summary>

var pathForFirstMeasurement = "../DataForTests/BigTextForTest.txt";
var resultOfFirstMeasurement = MeasureOnText(pathForFirstMeasurement);

var pathForSecondMeasurement = "../DataForTests/BigBinaryForTest";
var resultOfSecondMeasurement = MeasureOnBinary(pathForSecondMeasurement);

Console.WriteLine($"on text: compression ratio = {resultOfFirstMeasurement.CompressionRatio}, text is {resultOfFirstMeasurement.BWTImpact} times bigger with no BWT.");
Console.WriteLine($"on binary: copression ratio = {resultOfSecondMeasurement.CompressionRatio}, text is {resultOfSecondMeasurement.BWTImpact} times bigger with no BWT.");

static Measurement MeasureOnText(string path)
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
    var BWTImpact = (double)outputWithNoBWT.Length / outputWithBWT.Length;
    return new (compressionRatio, BWTImpact);
}

static Measurement MeasureOnBinary(string path)
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
    var BWTImpact = (double)outputWithNoBWT.Length / outputWithBWT.Length;
    return new (compressionRatio, BWTImpact);
}

record Measurement(double CompressionRatio, double BWTImpact);
