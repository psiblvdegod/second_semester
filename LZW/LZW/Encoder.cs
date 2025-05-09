namespace LZW;

public class Encoder
{
    public int Base { get; }

    public Dictionary<char, int> Codes { get; }

    public string Digits { get; }

    public Encoder(string digits)
    {
        this.Digits = digits;

        this.Base = this.Digits.Length;

        var codes = new Dictionary<char, int>();

        for (var i = 0; i < this.Digits.Length; ++i)
        {
            codes[this.Digits[i]] = i;
        }

        this.Codes = codes;
    }

    public string Encode(int value)
    {
        var result = string.Empty;

        while (value > 0)
        {
            result = this.Digits[value % this.Base] + result;
            value /= this.Base;
        }

        return result;
    }

    public int Decode(string code)
    {
        var result = 0;
        var exp = 0;

        foreach (var symbol in code.Reverse())
        {
            result += this.Codes[symbol] * (int)Math.Pow(this.Base, exp);
            ++exp;
        }

        return result;
    }
}
