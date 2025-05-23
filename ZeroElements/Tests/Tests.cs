// <copyright file="Tests.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>
namespace Tests;

using MyList;

#pragma warning disable SA1600 // Elements should be documented

public class Tests
{
    private static readonly int[] IntItems = [1, 2, 3, 4, 5, 6, 7, 8];

    private static readonly string[] StringItems = [string.Empty, "123", "100", string.Empty, string.Empty, "A"];

    private static readonly bool[] BoolItems = [false, true, false, true, false];

    [Test]
    public void CountNulls_OnInts()
    {
        var list = new MyList.List<int>();

        foreach (var item in IntItems)
        {
            list.Add(item);
        }

        Predicate<int> isNull = x => x % 2 == 0;

        var expectedResult = IntItems.Count(x => x % 2 == 0);
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

        var expectedResult = StringItems.Count(x => x == string.Empty);
        var actualResult = list.CountNulls(isNull);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void CountNulls_OnCustomRecognizer()
    {
        var list = new MyList.List<bool>();

        foreach (var item in BoolItems)
        {
            list.Add(item);
        }

        var recognizer = new NullRecognizer();

        var expectedResult = BoolItems.Count(x => x is false);

        var actualResult = list.CountNulls(recognizer);

        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [Test]
    public void AssertThat_EnumeratorInvalidates_IfCollectionChanges()
    {
        var list = new MyList.List<int>();

        list.Add(1);

        var enumerator = list.GetEnumerator();

        Assert.That(enumerator.MoveNext(), Is.True);

        list.Add(2);

        Assert.Throws<InvalidOperationException>(() => enumerator.MoveNext());
    }
}
