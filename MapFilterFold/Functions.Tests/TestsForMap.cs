namespace Functions.Tests;

using static Functions;

[TestFixture]
public class TestsForMap
{
    [Test]
    public void Map_OnIntAsList()
    {
        List<int> list = [0, 1, -2, -3, 4];

        Func<int, int> func = x => x < 0 ? -x * x : x * x;

        List<int> expectedResult = [0, 1, -4, -9, 16];

        var actualResult = Map(list, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Map_OnStringAsArray()
    {
        string[] array = ["first", "second", "third"];

        Func<string, string> func = x => x + x.Length;

        string[] expectedResult = ["first5", "second6", "third5"];

        var actualResult = Map(array, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Map_OnCustomTypeAsIEnumerable()
    {
        IEnumerable<CustomType> elements = [new(1.23, false), new(3.14, true), new(-6.66, true)];

        Func<CustomType, CustomType> func = a => new(Math.Floor(a.x), !a.y);

        IEnumerable<CustomType> expectedResult = [new(1.0, true), new(3, false), new(-7, false)];

        var actualResult = Map(elements, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    readonly struct CustomType (double x, bool y)
    {
        public readonly double x = x;
        public readonly bool y = y;
    }
}
