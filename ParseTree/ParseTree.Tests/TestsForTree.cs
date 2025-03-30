using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ParseTree.Tests;

public class TestsForTree
{
    [Test]
    public void Constructor_OnNonExistentOperation_ShouldThrowException()
    {
        var expression = "- 2 ^ 5 2";

        Assert.Throws<NotSupportedException>(() => new Tree(expression));
    }

    [Test]
    public void Constructor_OnIncorrectExpression_ShouldThrowException()
    {
        var expression = "+ 2 3 4";

        Assert.Throws<InvalidExpressionException>(() => new Tree(expression));
    }

    [Test]
    public void Calculate_OnSimpleExpression()
    {
        var expression = "+ * 1 2 5";

        var expectedResult = 7;

        var actualResult = new Tree(expression).Calculate();

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Calculate_OnExpressionWithNegativeNumbers()
    {
        var expression = "+ * 1 -2 5";

        var expectedResult = 3;

        var actualResult = new Tree(expression).Calculate();

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Calculate_OnExpressionWithUnusualOperator()
    {
        var expression = "- pow 2 5 2";

        var expectedResult = 30;

        var actualResult = new Tree(expression).Calculate();

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void AddOperationToSupportedOnes_OnSimpleOperationToAdd()
    {
        Func<int, int, int> operation = (x, y) => int.Parse($"{x}{y}");

        var token = "concat";

        Tree.AddOperationToSupportedOnes(token, operation);

        var expression = $"+ {token} 1 2 {token} 3 4";

        var expectedResult = 46;

        var actualResult = new Tree(expression).Calculate();

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void AddOperationToSupportedOnes_OnExistingOperation_ShouldThrowException()
    {
        Assert.Throws<InvalidOperationException>
        (
            () => Tree.AddOperationToSupportedOnes("+", (x, y) => x + y)
        );
    }
}
