namespace Functions.Tests;

using System.Security.Cryptography.X509Certificates;
using static Functions;

[TestFixture]
public class TestsForFilter
{
    [Test]
    public void Filter_OnIntAsList()
    {
        List<int> list = [0, 1, -2, -3, 4];

        IEnumerable<int> expectedResult = [-3];

        Predicate<int> predicate = x => x < 0 && x % 2 != 0;

        var actualResult = Filter(list, predicate);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Filter_OnStringAsArray()
    {
        string[] array = ["first", "second", "third"];

        IEnumerable<string> expectedResult = ["first"];

        Predicate<string> predicate = s => s.Contains('s') && s.Length < 6;

        var actualResult = Filter(array, predicate);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Filter_OnCustomTypeAsIEnumerable()
    {
        IEnumerable<CustomType> elements = [new(1.23, false), new(3.14, true), new(-6.66, true)];

        IEnumerable<CustomType> expectedResult = [new(3.14, true)];

        Predicate<CustomType> predicate = e => e.x > 0 && e.y;

        var actualResult = Filter(elements, predicate);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    readonly struct CustomType (double x, bool y)
    {
        public readonly double x = x;
        public readonly bool y = y;
    }
}
