using System.Collections;

namespace MyLinq;

public static class IEnumerableExtentions
{
    public static IEnumerable<T> MyTake<T>(this IEnumerable<T> source, int count)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(count, source.Count());
        ArgumentOutOfRangeException.ThrowIfLessThan(count, 1);

        IEnumerator<T> enumerator = source.GetEnumerator();

        for (var counter = 0; counter < count && enumerator.MoveNext(); ++counter)
        {
            yield return enumerator.Current;
        }
    }

    public static IEnumerable<T> MySkip<T>(this IEnumerable<T> source, int count)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(count, source.Count());
        ArgumentOutOfRangeException.ThrowIfLessThan(count, 1);

        IEnumerator<T> enumerator = source.GetEnumerator();

        for (var i = 0; i < count; ++i)
        {
            enumerator.MoveNext();
        }

        while (enumerator.MoveNext())
        {
            yield return enumerator.Current;
        }
    }
}
