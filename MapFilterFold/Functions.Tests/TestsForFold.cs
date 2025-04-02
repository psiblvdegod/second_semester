// <copyright file="TestsForFold.cs" author="psiblvdegod">
// under MIT License.
// </copyright>

namespace Functions.Tests;

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

        var actualResult = Functions.Fold(list, initialValue, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Fold_OnStringAsArray()
    {
        string[] array = ["first", "second", "third"];

        Func<string, string, string> func = (x, y) => y + x;

        var initialValue = string.Empty;

        var expectedResult = "thirdsecondfirst";

        var actualResult = Functions.Fold(array, initialValue, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Fold_OnCustomTypeAsIEnumerable()
    {
        IEnumerable<CustomType> elements = [new(1.23, false), new(3.14, true), new(-6.66, true)];

        Func<CustomType, CustomType, CustomType> func =
            (a, b) => a.B || b.B ? new(a.D + b.D, false) : new(a.D * b.D, true);

        CustomType initialValue = new(1, false);

        CustomType expectedResult = new(-2.29, false);

        var actualResult = Functions.Fold(elements, initialValue, func);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Fold_OnIEnumerablesOfIntAsIEnumerable()
    {
        IEnumerable<IEnumerable<int>> elements = [[4, 5, 0], [-2, -4, 12], [9, 0, -5]];

        Func<IEnumerable<int>, IEnumerable<int>, IEnumerable<int>> func =
            (left, right) =>
            {
                IEnumerable<int> result = [];
                var leftAsArray = left.ToArray();
                var rightAsArray = right.ToArray();

                for (var i = 0; i < leftAsArray.Length && i < rightAsArray.Length; ++i)
                {
                    result = result.Append(leftAsArray[i] + rightAsArray[i]);
                }

                return result.AsEnumerable();
            };

        IEnumerable<int> initialValue = [0, 0, 0];

        IEnumerable<int> expectedResult = [11, 1, 7];

        var actualResult = Functions.Fold(elements, initialValue, func);

        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }
}
