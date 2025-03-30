using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace ParseTree.Tests;

[TestFixture]
public class TestsForOperator
{
    [Test]
    public void Calculate_OnTwoLeavesAsOperands()
    {
        Func<int,int,int> operation = (x,y) => x * y;
        
        var root = new Operator(operation, string.Empty);

        root.LeftChild = new Leaf(2);
        root.RightChild = new Leaf(3);

        var expectedResult = 6;

        var actualResult = root.Calculate();

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Calculate_OnTwoOperatorsAsOperands()
    {
        Func<int,int,int> operation1 = (x,y) => x * y;
        Func<int,int,int> operation2 = (x,y) => x - y;
        Func<int,int,int> operation3 = (x,y) => x % y;

        var root = new Operator(operation1, string.Empty);

        var left = new Operator(operation2, string.Empty)
        {
            LeftChild = new Leaf(3),
            RightChild = new Leaf(1)
        };

        var right = new Operator(operation3, string.Empty)
        {
            LeftChild = new Leaf(5),
            RightChild = new Leaf(3)
        };

        root.LeftChild = left;
        root.RightChild = right;

        var expectedResult = 4;

        var actualResult = root.Calculate();

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Calculate_OnOperatorWithOneOrWithNoOperands_ShouldThrowException()
    {
        var root = new Operator((x,y) => x + y, string.Empty);

        Assert.Throws<InvalidOperationException>(() => root.Calculate());

        root.LeftChild = new Leaf(1);

        Assert.Throws<InvalidOperationException>(() => root.Calculate());

        root.RightChild = new Leaf(2);

        Assert.DoesNotThrow(() => root.Calculate());
    }

    [Test]
    public void TestForPrint()
    {
        var token = "+";
        var node = new Operator((x,y) => x + y, token);
        var expectedResult = $"{token}\n";

        var output = new StringWriter();
        Console.SetOut(output);

        node.Print();

        Assert.That(output.ToString(), Is.EqualTo(expectedResult));
    }
}
