// <copyright file="TestsForLeaf.cs" author="psiblvdegod">
// under MIT License.
// </copyright>

namespace ParseTree.Tests;

#pragma warning disable SA1600

/// <summary>
/// Tests methods of class Leaf .
/// </summary>
[TestFixture]
public class TestsForLeaf
{
    [Test]
    public void TestForCalculate()
    {
        var data = 1;
        Leaf leaf = new(data);
        var expectedResult = data;

        var actualResult = leaf.Calculate();

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void TestForPrint()
    {
        var data = 1;
        Leaf leaf = new(data);
        var expectedResult = $"{data}\n";

        var output = new StringWriter();
        Console.SetOut(output);

        leaf.Print();

        Assert.That(output.ToString(), Is.EqualTo(expectedResult));
    }
}
