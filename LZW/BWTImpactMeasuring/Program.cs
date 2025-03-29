var pathForFirstMeasure = "../DataForTests/TestData.txt";
var resultOfFirstMeasure = MeasureOnText(pathForFirstMeasure);

var pathForSecondMeasure = "../DataForTests/TestData";
var resultOfSecondMeasure = MeasureOnBinary(pathForSecondMeasure);

Console.WriteLine($"first measure: text is {resultOfFirstMeasure} times bigger with no BWT.");
Console.WriteLine($"second measure: text is {resultOfSecondMeasure} times bigger with no BWT.");

static double MeasureOnText(string path)
{
    var input = File.ReadAllText(path);
    var outputWithNoBWT = LZW.LZW.Compress(input);
    var outputWithBWT = BWTxLZW.BWTxLZW.Compress(input);
    return (double)outputWithNoBWT.Length / outputWithBWT.Length;
}

static double MeasureOnBinary(string path)
{
    var input = File.ReadAllBytes(path);
    var outputWithNoBWT = LZW.LZW.Compress(input);
    var outputWithBWT = BWTxLZW.BWTxLZW.Compress(input);
    return (double)outputWithNoBWT.Length / outputWithBWT.Length;
}
