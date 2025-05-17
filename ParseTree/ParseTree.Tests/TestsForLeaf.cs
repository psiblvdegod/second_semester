// <copyright file="TestsForLeaf.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>

namespace ParseTree.Tests;

#pragma warning disable SA1600

/// <summary>
/// Tests methods of class Leaf.
/// </summary>
[TestFixture]
public class TestsForLeaf
{
    [Test]
    public void TestForCalculate()
    {
        var item = 1;
        Leaf leaf = new(item);
        var expectedResult = item;

        var actualResult = leaf.Calculate();

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void TestForPrint()
    {
        var item = 1;
        Leaf leaf = new(item);
        var expectedResult = $"{item}";

        var output = new StringWriter();
        Console.SetOut(output);

        leaf.Print();

        Assert.That(output.ToString(), Is.EqualTo(expectedResult));
    }
}
