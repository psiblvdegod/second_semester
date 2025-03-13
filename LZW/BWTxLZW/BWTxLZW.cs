namespace BWTxLZW;

using LZW;

using BWT;

public static class BWTxLZW
{
    public static (string Output, int Position) Compress(string input)
        => BWT.Transform(LZW.Compress(input));

    public static string Decompress(string input, int position)
        => LZW.Decompress(BWT.Detransform(input, position));   
}