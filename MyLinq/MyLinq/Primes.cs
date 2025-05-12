// <copyright file="Primes.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>

namespace MyLinq;

/// <summary>
/// Implements operations with prime numbers.
/// </summary>
public static class Primes
{
    /// <summary>
    /// Gets sequence of prime numbers.
    /// </summary>
    /// <returns>An IEnumerable which represents infinity sequence of prime numbers.</returns>
    public static IEnumerable<int> Get()
    {
        for (var current = 1; ; current = GetNextPrime(current))
        {
            yield return current;
        }
    }

    private static int GetNextPrime(int current)
    {
        while (true)
        {
            ++current;

            var isPrime = true;

            for (var divider = 2; divider <= (int)Math.Sqrt(current); ++divider)
            {
                if (current % divider == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                return current;
            }
        }
    }
}
