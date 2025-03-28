namespace Functions.Tests;

using static Functions;

[TestFixture]
public class TestsForFold
{
    [Test]
    public void Fold_OnIntAsList()
    {
        List<int> list = [0, 1, -2, -3, 4];

        Func<int, int, int> func = (x, y) => y - x;

        var initialValue = 1; 

        var expectedResult = 3;

        var actualResult = Fold(list, initialValue, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Fold_OnStringAsArray()
    {
        string[] array = ["first", "second", "third"];

        Func<string, string, string> func = (x, y) => y + x;

        var initialValue = string.Empty;

        var expectedResult = "thirdsecondfirst";

        var actualResult = Fold(array, initialValue, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Fold_OnCustomTypeAsIEnumerable()
    {
        IEnumerable<CustomType> elements = [new(1.23, false), new(3.14, true), new(-6.66, true)];

        Func<CustomType, CustomType, CustomType> func = (a, b) => a.y || b.y ? new(a.x + b.x, false) : new(a.x * b.x, true);

        CustomType initialValue = new(1, false);

        CustomType expectedResult = new(-2.29, false);

        var actualResult = Fold(elements, initialValue, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    readonly struct CustomType (double x, bool y)
    {
        public readonly double x = x;
        public readonly bool y = y;
    }
}
