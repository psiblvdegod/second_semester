namespace ParseTree.Tests;

public class Tests
{

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
    public void Calculate_()
    {
        var expression = "+ + 2 3 4";

        var expectedResult = 9;

        var actualResult = new Tree(expression).Calculate();

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
