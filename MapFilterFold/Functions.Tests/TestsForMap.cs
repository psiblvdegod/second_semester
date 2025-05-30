// <copyright file="TestsForMap.cs" author="psiblvdegod">
// under MIT License
// </copyright>

// SA1600: Elements should be documented.
#pragma warning disable SA1600

namespace Functions.Tests;

/// <summary>
/// Tests Functions.Map().
/// </summary>
[TestFixture]
public class TestsForMap
{
    [Test]
    public void Map_OnIntAsList()
    {
        Func<int, int> func = x => x < 0 ? -x * x : x * x;

        List<int> source = [0, 1, -2, -3, 4];
        List<int> expectedResult = [0, 1, -4, -9, 16];

        var actualResult = Functions.Map(source, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Map_OnStringAsArray()
    {
        Func<string, string> func = x => x + x.Length;

        string[] source = ["first", "second", "third"];
        string[] expectedResult = ["first5", "second6", "third5"];

        var actualResult = Functions.Map(source, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Map_OnCustomTypeAsIEnumerable()
    {
        Func<CustomType, CustomType> func = e => new(Math.Floor(e.D), !e.B);

        IEnumerable<CustomType> source =
            [new(1.23, false), new(3.14, true), new(-6.66, true)];
        IEnumerable<CustomType> expectedResult =
            [new(1.0, true), new(3, false), new(-7, false)];

        var actualResult = Functions.Map(source, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Map_OnIEnumerablesOfIntAsIEnumerable()
    {
        Func<IEnumerable<int>, IEnumerable<int>> func = e => e.Order();

        IEnumerable<IEnumerable<int>> source =
            [[4, 5, 0], [-2, -4, 12], [9, 0, -5]];
        IEnumerable<IEnumerable<int>> expectedResult =
            [[0, 4, 5], [-4, -2, 12], [-5, 0, 9]];

        var actualResult = Functions.Map(source, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Map_OnDifferentTypesOfInitialAndResultingSequences()
    {
        Func<int, string> func = x => x.ToString();

        IEnumerable<int> source = [1, 2, 3, 4, 5];
        IEnumerable<string> expectedResult = ["1", "2", "3", "4", "5"];

        var actualResult = Functions.Map(source, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Map_OnEmptySequence()
    {
        Func<double, int> func = x => (int)x;

        IEnumerable<double> source = [];
        IEnumerable<int> expectedResult = [];

        var actualResult = Functions.Map(source, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
