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
    public void Calculate()
    {
        var item = 1;
        var leaf = new Leaf(item);
        var expectedResult = item;

        var actualResult = leaf.Calculate();

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Print()
    {
        var item = 1;
        var leaf = new Leaf(item);
        var expectedResult = $"{item}";

        var actualResult = new StringWriter();
        Console.SetOut(actualResult);
        leaf.Print();

        Assert.That(actualResult.ToString(), Is.EqualTo(expectedResult));
    }
}
