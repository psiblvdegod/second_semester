// <copyright file="TestsForMap.cs" author="psiblvdegod">
// under MIT License.
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
        List<int> list = [0, 1, -2, -3, 4];

        Func<int, int> func = x => x < 0 ? -x * x : x * x;

        List<int> expectedResult = [0, 1, -4, -9, 16];

        var actualResult = Functions.Map(list, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Map_OnStringAsArray()
    {
        string[] array = ["first", "second", "third"];

        Func<string, string> func = x => x + x.Length;

        string[] expectedResult = ["first5", "second6", "third5"];

        var actualResult = Functions.Map(array, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Map_OnCustomTypeAsIEnumerable()
    {
        IEnumerable<CustomType> elements =
            [new(1.23, false), new(3.14, true), new(-6.66, true)];

        Func<CustomType, CustomType> func =
            a => new(Math.Floor(a.D), !a.B);

        IEnumerable<CustomType> expectedResult =
            [new(1.0, true), new(3, false), new(-7, false)];

        var actualResult = Functions.Map(elements, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Map_OnIEnumerablesOfIntAsIEnumerable()
    {
        IEnumerable<IEnumerable<int>> elements =
            [[4, 5, 0], [-2, -4, 12], [9, 0, -5]];

        Func<IEnumerable<int>, IEnumerable<int>> func = e => e.Order();

        IEnumerable<IEnumerable<int>> expectedResult =
            [[0, 4, 5], [-4, -2, 12], [-5, 0, 9]];

        var actualResult = Functions.Map(elements, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
