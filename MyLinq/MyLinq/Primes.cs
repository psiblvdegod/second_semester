namespace MyLinq;

public static class Primes
{
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
