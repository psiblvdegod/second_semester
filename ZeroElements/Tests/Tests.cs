using MyList;

namespace Tests;

public class Tests
{
    private static readonly int[] IntItems = [ 1, 0, 2, 0, 3, 0, 4, 0];

    private static readonly string[] StringItems;

    [Test]
    public void Test1()
    {
        var list = new MyList.List<int>();

        foreach (var item in IntItems)
        {
            list.Add(item);
        }

        Predicate<int> IsNull = x => x == 0;

        var expectedResult = 4;

        var actualResult = list.CountNulls(IsNull);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
