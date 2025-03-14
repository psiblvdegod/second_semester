// <copyright file = "BWT.cs" author = "psiblvdegod" date = "2025">
// under MIT license
// </copyright>

var input = "../../../TestData.txt";

var outputWithNoBWT = LZW.LZW.Compress(input);

var outputWithBWT = BWTxLZW.BWTxLZW.Compress(input);

var difference = (double)outputWithNoBWT.Length / outputWithBWT.Length;

Console.WriteLine($"Text with no BWT is {difference} times bigger.");
