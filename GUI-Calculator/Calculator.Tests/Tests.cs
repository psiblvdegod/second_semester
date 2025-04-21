namespace Calculator.Tests;

public class Tests
{
    Calculator calculator;

    [SetUp]
    public void Setup()
    {
        calculator = new();
    }

    [Test]
    public void Test1()
    {
        calculator.AddToken('1');
        calculator.AddToken('2');
        calculator.AddToken('+');
        calculator.AddToken('3');
        calculator.AddToken('-');
        Assert.That(calculator.Value, Is.EqualTo(15.0).Within(0.001));
    }

    [Test]
    public void Test2()
    {
        calculator.AddToken('1');
        calculator.AddToken('*');
        calculator.AddToken('2');
        calculator.AddToken('3');
        calculator.AddToken('-');
        Assert.That(calculator.Value, Is.EqualTo(23.0).Within(0.001));
    }

    [Test]
    public void Test3()
    {
        calculator.AddToken('1');
        calculator.AddToken('0');
        calculator.AddToken('0');
        calculator.AddToken('0');
        calculator.AddToken('-');
        calculator.AddToken('9');
        calculator.AddToken('9');
        calculator.AddToken('9');
        calculator.AddToken('-');
        calculator.AddToken('1');
        calculator.AddToken('+');
        calculator.AddToken('5');
        calculator.AddToken('0');
        calculator.AddToken('-');
        Assert.That(calculator.Value, Is.EqualTo(50.0).Within(0.001));
    }
}
