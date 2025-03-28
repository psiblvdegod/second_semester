namespace Functions;

public static class Functions
{
    public static IEnumerable<T> Map<T>(IEnumerable<T> elements, Func<T, T> func)
    {
        IEnumerable<T> result = [];

        foreach (var element in elements)
        {
            result = result.Append(func(element));
        }

        return result;
    }

    public static IEnumerable<T> Filter<T>(IEnumerable<T> elements, Predicate<T> predicate)
    {
        IEnumerable<T> result = [];

        foreach (var element in elements)
        {
            if (predicate(element))
            {
                result = result.Append(element);
            }
        }

        return result;
    }

    public static T Fold<T>(IEnumerable<T> elements, T initialValue, Func<T, T, T> func)
    {
        var result = initialValue;

        foreach (var element in elements)
        {
            result = func(result, element);
        }

        return result;
    }
}
