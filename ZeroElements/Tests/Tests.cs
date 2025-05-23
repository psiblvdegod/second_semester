// <copyright file="Tests.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>
namespace Tests;

using MyList;

#pragma warning disable SA1600 // Elements should be documented

public class Tests
{
    private static readonly int[] IntItems = [1, 0, 2, 0, 3, 0, 4, 0];

    private static readonly string[] StringItems = [string.Empty, "123", "100", string.Empty, string.Empty, "A"];

    [Test]
    public void CountNulls_OnInts()
    {
        var list = new MyList.List<int>();

        foreach (var item in IntItems)
        {
            list.Add(item);
        }

        Predicate<int> isNull = x => x == 0;

        var expectedResult = 4;
        var actualResult = list.CountNulls(isNull);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void CountNulls_OnString()
    {
        var list = new MyList.List<string>();

        foreach (var item in StringItems)
        {
            list.Add(item);
        }

        Predicate<string> isNull = x => x == string.Empty;

        var expectedResult = 3;
        var actualResult = list.CountNulls(isNull);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
