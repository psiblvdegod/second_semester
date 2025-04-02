// <copyright file="TestsForFilter.cs" author="psiblvdegod">
// under MIT License.
// </copyright>

// SA1600 : Elements should be documented.
#pragma warning disable SA1600

namespace Functions.Tests;

[TestFixture]
public class TestsForFilter
{
    [Test]
    public void Filter_OnIntAsList()
    {
        List<int> list = [0, 1, -2, -3, 4];

        IEnumerable<int> expectedResult = [list[3]];

        Predicate<int> predicate = x => x < 0 && x % 2 != 0;

        var actualResult = Functions.Filter(list, predicate);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Filter_OnStringAsArray()
    {
        string[] array = ["first", "second", "third"];

        Predicate<string> predicate = s => s.Contains('s') && s.Length < 6;

        IEnumerable<string> expectedResult = [array[0]];

        var actualResult = Functions.Filter(array, predicate);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Filter_OnCustomTypeAsIEnumerable()
    {
        IEnumerable<CustomType> elements = [new(1.23, false), new(3.14, true), new(-6.66, true)];

        Predicate<CustomType> predicate = e => e.D > 0 && e.B;

        IEnumerable<CustomType> expectedResult = [elements.ToArray()[1]];

        var actualResult = Functions.Filter(elements, predicate);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Filted_OnIEnumerablesOfIntAsIEnumerable()
    {
        IEnumerable<IEnumerable<int>> elements = [[4, 5, 0], [-2, -4, 12], [9, 0, -5]];

        Predicate<IEnumerable<int>> predicate = e => e.Count(x => x % 2 == 0) > 1;

        IEnumerable<IEnumerable<int>> expectedResult = [elements.ToArray()[0], elements.ToArray()[1]];

        var actualResult = Functions.Filter(elements, predicate);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
