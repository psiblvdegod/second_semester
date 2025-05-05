// <copyright file="TestsForFold.cs" author="psiblvdegod">
// under MIT License
// </copyright>

// SA1600: Elements should be documented.
#pragma warning disable SA1600

namespace Functions.Tests;

/// <summary>
/// Tests Functions.Fold().
/// </summary>
[TestFixture]
public class TestsForFold
{
    [Test]
    public void Fold_OnIntAsList()
    {
        Func<int, int, int> func = (x, y) => y - x;

        List<int> data = [0, 1, -2, -3, 4];
        var initialValue = 1;
        var expectedResult = 3;

        var actualResult = Functions.Fold(data, initialValue, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Fold_OnStringAsArray()
    {
        Func<string, string, string> func = (x, y) => y + x;

        string[] data = ["first", "second", "third"];
        var initialValue = string.Empty;
        var expectedResult = "thirdsecondfirst";

        var actualResult = Functions.Fold(data, initialValue, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Fold_OnCustomTypeAsIEnumerable()
    {
        Func<CustomType, CustomType, CustomType> func =
            (a, b) => a.B || b.B ? new(a.D + b.D, false) : new(a.D * b.D, true);

        IEnumerable<CustomType> data = [new(1.23, false), new(3.14, true), new(-6.66, true)];
        CustomType initialValue = new(1, false);
        CustomType expectedResult = new(-2.29, false);

        var actualResult = Functions.Fold(data, initialValue, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Fold_OnIEnumerablesOfIntAsIEnumerable()
    {
        IEnumerable<IEnumerable<int>> data = [[4, 5, 0], [-2, -4, 12], [9, 0, -5]];
        IEnumerable<int> initialValue = [0, 0, 0];
        IEnumerable<int> expectedResult = [11, 1, 7];

        var actualResult = Functions.Fold(data, initialValue, Func);

        Assert.That(expectedResult, Is.EqualTo(actualResult));

        static IEnumerable<int> Func(IEnumerable<int> left, IEnumerable<int> right)
        {
            var result = left.ToArray();
            var i = 0;
            foreach (var j in right)
            {
                result[i] += j;
                ++i;
            }

            return result.AsEnumerable();
        }
    }
}
