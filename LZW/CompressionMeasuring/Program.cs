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

Console.WriteLine($"first measure: text is {resultOfFirstMeasurement} times bigger with no BWT.");
Console.WriteLine($"second measure: text is {resultOfSecondMeasurement} times bigger with no BWT.");

static double MeasureOnText(string path)
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

    return (double)outputWithNoBWT.Length / outputWithBWT.Length;
}

static double MeasureOnBinary(string path)
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

    return (double)outputWithNoBWT.Length / outputWithBWT.Length;
}
