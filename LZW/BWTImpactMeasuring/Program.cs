﻿var pathForFirstMeasurement = "../DataForTests/TestData.txt";
var resultOfFirstMeasurement = MeasureOnText(pathForFirstMeasurement);

var pathForSecondMeasurement = "../DataForTests/TestData";
var resultOfSecondMeasurement = MeasureOnBinary(pathForSecondMeasurement);

Console.WriteLine($"first measure: text is {resultOfFirstMeasurement} times bigger with no BWT.");
Console.WriteLine($"second measure: text is {resultOfSecondMeasurement} times bigger with no BWT.");

static double MeasureOnText(string path)
{
    var input = File.ReadAllText(path);
    var outputWithNoBWT = LZW.Compression.Compress(input);
    var outputWithBWT = BWTxLZW.Compression.Compress(input);
    return (double)outputWithNoBWT.Length / outputWithBWT.Length;
}

static double MeasureOnBinary(string path)
{
    var input = File.ReadAllBytes(path);
    var outputWithNoBWT = LZW.Compression.Compress(input);
    var outputWithBWT = BWTxLZW.Compression.Compress(input);
    return (double)outputWithNoBWT.Length / outputWithBWT.Length;
}
