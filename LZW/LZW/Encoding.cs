namespace LZW;

public static class Base64Encoding
{
    public static int Base { get; } = 64;

    public static Dictionary<char, int> Codes { get; }

    public static string Symbols { get; } =
        "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ()";

    static Base64Encoding()
    {
        var codes = new Dictionary<char, int>();

        for (var i = 0; i < Symbols.Length; ++i)
        {
            codes[Symbols[i]] = i;
        }

        Codes = codes;
    }

    public static string Encode(int value)
    {
        var result = string.Empty;

        while (value > 0)
        {
            result = Symbols[value % Base] + result;
            value /= Base;
        }

        return result;
    }

    public static int Decode(string code)
    {
        var result = 0;
        var exp = 0;

        foreach (var symbol in code.Reverse())
        {
            result += Codes[symbol] * (int)Math.Pow(Base, exp);
            ++exp;
        }

        return result;
    }
}
