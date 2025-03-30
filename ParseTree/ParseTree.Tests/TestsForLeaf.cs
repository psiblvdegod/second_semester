using Microsoft.VisualBasic;

namespace ParseTree.Tests;

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
