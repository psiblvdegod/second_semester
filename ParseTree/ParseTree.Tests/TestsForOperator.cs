// <copyright file="TestsForOperator.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>

namespace ParseTree.Tests;

// Elements should be documented
#pragma warning disable SA1600

/// <summary>
/// Tests methods of class Operator.
/// </summary>
[TestFixture]
public class TestsForOperator
{
    [Test]
    public void Calculate_OnTwoLeavesAsOperands()
    {
        Func<int, int, int> operation = (x, y) => x * y;
        var root = new Operator(operation)
        {
            LeftChild = new Leaf(2),
            RightChild = new Leaf(3),
        };

        var expectedResult = 6;

        var actualResult = root.Calculate();

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Calculate_OnTwoOperatorsAsOperands()
    {
        Func<int, int, int> operation1 = (x, y) => x * y;
        Func<int, int, int> operation2 = (x, y) => x - y;
        Func<int, int, int> operation3 = (x, y) => x % y;

        var root = new Operator(operation1);

        var left = new Operator(operation2)
        {
            LeftChild = new Leaf(3),
            RightChild = new Leaf(1),
        };

        var right = new Operator(operation3)
        {
            LeftChild = new Leaf(5),
            RightChild = new Leaf(3),
        };

        root.LeftChild = left;
        root.RightChild = right;

        var expectedResult = 4;

        var actualResult = root.Calculate();

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Calculate_Throws_OnOperatorWithOneOrWithNoOperands()
    {
        var root = new Operator((x, y) => x + y);

        Assert.Throws<InvalidOperationException>(() => root.Calculate());

        root.LeftChild = new Leaf(1);

        Assert.Throws<InvalidOperationException>(() => root.Calculate());

        root.RightChild = new Leaf(2);

        Assert.DoesNotThrow(() => root.Calculate());
    }

    [Test]
    public void Print_WithNoOperands()
    {
        var token = "+";
        var node = new Operator((x, y) => x + y, token);

        var output = new StringWriter();
        Console.SetOut(output);

        node.Print();

        Assert.That(output.ToString(), Is.EqualTo(token));
    }

    [Test]
    public void Print_WithOperands()
    {
        var token = "+";
        var node = new Operator((x, y) => x + y, token)
        {
            LeftChild = new Leaf(100),
            RightChild = new Leaf(200),
        };

        var expectedResult = "+ 100 200";

        var actualResult = new StringWriter();
        Console.SetOut(actualResult);
        node.Print();

        Assert.That(actualResult.ToString(), Is.EqualTo(expectedResult));
    }
}
