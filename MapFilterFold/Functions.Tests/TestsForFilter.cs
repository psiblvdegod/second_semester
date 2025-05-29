// <copyright file="TestsForFilter.cs" author="psiblvdegod">
// under MIT License
// </copyright>

// SA1600: Elements should be documented.
#pragma warning disable SA1600

namespace Functions.Tests;

/// <summary>
/// Tests Functions.Filter().
/// </summary>
[TestFixture]
public class TestsForFilter
{
    [Test]
    public void Filter_OnIntAsList()
    {
        Predicate<int> predicate = x => x < 0 && x % 2 != 0;

        List<int> source = [0, 1, -2, -3, 4];
        IEnumerable<int> expectedResult = [source[3]];

        var actualResult = Functions.Filter(source, predicate);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Filter_OnStringAsArray()
    {
        Predicate<string> predicate = s => s.Contains('s') && s.Length < 6;

        string[] source = ["first", "second", "third"];
        IEnumerable<string> expectedResult = source.Take(1);

        var actualResult = Functions.Filter(source, predicate);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Filter_OnCustomTypeAsIEnumerable()
    {
        Predicate<CustomType> predicate = e => e.D > 0 && e.B;

        IEnumerable<CustomType> source = [new(1.23, false), new(3.14, true), new(-6.66, true)];
        IEnumerable<CustomType> expectedResult = source.Skip(1).Take(1);

        var actualResult = Functions.Filter(source, predicate);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Filted_OnIEnumerablesOfIntAsIEnumerable()
    {
        Predicate<IEnumerable<int>> predicate = e => e.Count(x => x % 2 == 0) > 1;

        IEnumerable<IEnumerable<int>> source = [[4, 5, 0], [-2, -4, 12], [9, 0, -5]];
        IEnumerable<IEnumerable<int>> expectedResult = source.Take(2);

        var actualResult = Functions.Filter(source, predicate);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Filter_WhenAllItemsSatisfyPredicate_ShouldReturnEmptySequence()
    {
        Predicate<string> predicate = s => s.Length < 0;

        IEnumerable<string> source = [string.Empty, "123"];
        IEnumerable<string> expectedResult = [];

        var actualResult = Functions.Filter(source, predicate);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Filter_OnEmptySequence()
    {
        Predicate<int> predicate = x => true;

        IEnumerable<int> source = [];
        IEnumerable<int> expectedResult = [];

        var actualResult = Functions.Filter(source, predicate);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
