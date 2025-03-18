var firstPath = "../DataForTests/TestData.txt";

var firstInput = File.ReadAllText(firstPath);

var firstResult = MeasureOnText(firstInput);

Console.WriteLine($"text when BWT was not used is {firstResult} times bigger.");

static double MeasureOnText(string input)
{
    var outputWithNoBWT = LZW.LZW.Compress(input);

    var outputWithBWT = BWTxLZW.BWTxLZW.Compress(input);

    return (double)outputWithNoBWT.Length / outputWithBWT.Length;
}
