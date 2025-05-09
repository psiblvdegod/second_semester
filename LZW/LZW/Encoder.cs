// <copyright file="Encoder.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>

namespace LZW;

/// <summary>
/// Implements a number systems converter with custom digits.
/// </summary>
public class Encoder
{
    private readonly int basis;

    private readonly Dictionary<char, int> codes;

    private readonly string digits;

    /// <summary>
    /// Initializes a new instance of the <see cref="Encoder"/> class.
    /// </summary>
    /// <param name="digits">Digits that will be used as alphabet of number system.</param>
    public Encoder(string digits)
    {
        this.digits = digits;

        this.basis = this.digits.Length;

        var codes = new Dictionary<char, int>();

        for (var i = 0; i < this.digits.Length; ++i)
        {
            codes[this.digits[i]] = i;
        }

        this.codes = codes;
    }

    /// <summary>
    /// Encrypts number.
    /// </summary>
    /// <param name="value">Number to encrypt.</param>
    /// <returns>Encrypted number as string.</returns>
    public string Encode(int value)
    {
        var result = string.Empty;

        while (value > 0)
        {
            result = this.digits[value % this.basis] + result;
            value /= this.basis;
        }

        return result;
    }

    /// <summary>
    /// Decrypts code to number.
    /// </summary>
    /// <param name="code">Code of encrypted number.</param>
    /// <returns>The number that was encrypted.</returns>
    public int Decode(string code)
    {
        var result = 0;
        var exp = 0;

        foreach (var symbol in code.Reverse())
        {
            result += this.codes[symbol] * (int)Math.Pow(this.basis, exp);
            ++exp;
        }

        return result;
    }
}
