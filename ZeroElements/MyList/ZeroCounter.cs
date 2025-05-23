namespace MyList;

public static class MyListExtensions
{
    public static int CountNulls<T>(this MyList.List<T> items, Predicate<T> recognizer)
    {
        var counter = 0;
        foreach (var item in items)
        {
            if (recognizer(item))
            {
                ++counter;
            }
        }

        return counter;
    }

    public static int CountNulls<T>(this MyList.List<T> items, INullRecognizer<T> recognizer)
        => CountNulls(items, recognizer.IsNull);
}
