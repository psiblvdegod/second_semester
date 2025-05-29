// <copyright file="TestsForTree.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>

namespace ParseTree.Tests;

#pragma warning disable SA1600

/// <summary>
/// Tests methods of class Tree.
/// </summary>
public class TestsForTree
{
    private ParseTree.Tree tree;

    [SetUp]
    public void SetUp()
        => this.tree = new();

    [Test]
    public void Constructor_OnNonExistentOperation_ShouldThrowException()
    {
        var expression = "- 2 ^ 5 2";

        Assert.Throws<NotSupportedException>(() => this.tree.Parse(expression));
    }

    [Test]
    public void Constructor_OnIncorrectExpression_ShouldThrowException()
    {
        var expression = "+ 2 3 4";

        Assert.Throws<InvalidExpressionException>(() => this.tree.Parse(expression));
    }

    [Test]
    public void Calculate_OnSimpleExpression()
    {
        var expression = "+ * 1 2 5";
        this.tree.Parse(expression);

        var expectedResult = 7;

        var actualResult = this.tree.Calculate();

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Calculate_OnExpressionWithNegativeNumbers()
    {
        var expression = "+ * 1 -2 5";
        this.tree.Parse(expression);

        var expectedResult = 3;

        var actualResult = this.tree.Calculate();

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void RegisterOperation_OnPow()
    {
        Func<int, int, int> operation = (x, y) => (int)Math.Pow(x, y);
        var token = "pow";
        this.tree.RegisterOperation(token, operation);

        var expression = $"- {token} 2 5 2";
        this.tree.Parse(expression);

        var expectedResult = 30;

        var actualResult = this.tree.Calculate();

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void RegisterOperation_OnConcat()
    {
        Func<int, int, int> operation = (x, y) => int.Parse($"{x}{y}");
        var token = "concat";
        this.tree.RegisterOperation(token, operation);

        var expression = $"+ {token} 1 2 {token} 3 4";
        this.tree.Parse(expression);

        var expectedResult = 46;

        var actualResult = this.tree.Calculate();

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void TryGetRegisteredOperation_OnExistingOperator()
        => Assert.That(this.tree.TryGetRegisteredOperation("+", out _), Is.True);

    [Test]
    public void TryGetRegisteredOperation_OnNonExistingOperator()
        => Assert.That(this.tree.TryGetRegisteredOperation("_", out _), Is.False);

    [Test]
    public void RegisterOperation_Throws_OnExistingOperation()
        => Assert.Throws<InvalidOperationException>(() => this.tree.RegisterOperation("+", (x, y) => x + y));

    [Test]
    public void Calculate_Throws_OnEmptyTree()
        => Assert.Throws<InvalidOperationException>(() => this.tree.Calculate());
}
