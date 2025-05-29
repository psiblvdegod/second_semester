#pragma warning disable

namespace Calculator.Tests;

using NUnit;

[TestFixture]
public class TestsForCalc2
{
    Calc2 calc;

    [SetUp]
    public void SetUp()
    {
        calc = new();
    }

    [Test]
    public void OnSimpleBinary()
    {
        calc.AddOperand(10);
        calc.AddBinary(_Operation.Addition);
        calc.AddOperand(20);
        Assert.That(calc.Value, Is.EqualTo(30));
    }

    [Test]
    public void OnSimpleUnary()
    {
        calc.AddUnary(_Operation.Floor);
        calc.AddOperand(10.1);
        calc.AddBinary(_Operation.Substraction);
        calc.AddOperand(0.5);
        calc.AddUnary(_Operation.Ceiling);
        Assert.That(calc.Value, Is.EqualTo(10));
    }

    [Test]
    public void IntermediateStates()
    {
        Assert.That(calc.Value, Is.Null);
        calc.AddUnary(_Operation.Floor);
        calc.AddOperand(1.5);
        Assert.That(calc.Value, Is.EqualTo(1.0));
        calc.AddUnary(_Operation.Ceiling);
        Assert.That(calc.Value, Is.EqualTo(1.0));
        calc.AddBinary(_Operation.Addition);
        Assert.That(calc.Value, Is.EqualTo(1.0));
        calc.AddOperand(2.5);
        Assert.That(calc.Value, Is.EqualTo(3.5));
        calc.AddUnary(_Operation.Ceiling);
        Assert.That(calc.Value, Is.EqualTo(4.0));
    }

    [Test]
    public void Throws_BinaryToEmpty()
        => Assert.Throws<InvalidOperationException>(() => calc.AddBinary(_Operation.Addition));

    [Test]
    public void Throws_OnSeveralOperands()
    {
        calc.AddOperand(1);
        Assert.Throws<InvalidOperationException>(() => calc.AddOperand(2));
    }

    [Test]
    public void Throws_OnSeveralUnary()
    {
        calc.AddUnary(_Operation.Floor);
        Assert.Throws<InvalidOperationException>(() => calc.AddUnary(_Operation.Ceiling));
    }

    [Test]
    public void Throws_OnSeveralBinary()
    {
        calc.AddOperand(1);
        calc.AddBinary(_Operation.Division);
        Assert.Throws<InvalidOperationException>(() => calc.AddBinary(_Operation.Substraction));
    }

    [Test]
    public void Throws_OnUnaryThenBinary()
    {
        calc.AddUnary(_Operation.Floor);
        Assert.Throws<InvalidOperationException>(() => calc.AddBinary(_Operation.Division));
    }

    [Test]
    public void Throws_OnBinaryThenUnary()
    {
        calc.AddOperand(1);
        calc.AddBinary(_Operation.Multiplication);
        Assert.Throws<InvalidOperationException>(() => calc.AddUnary(_Operation.Floor));
    }
}
