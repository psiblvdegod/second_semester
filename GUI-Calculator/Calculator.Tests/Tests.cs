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
    public void Calculator_OnSimpleCorrectInput()
    {
        var input = "12+3-";

        foreach (var token in input)
        {
            calculator.AddToken(token);
        }

        var expectedResult = 15.0;

        Assert.That(calculator.Value, Is.EqualTo(expectedResult).Within(0.001));
    }

    [Test]
    public void Calculator_OnNumbersWhichStartWithZero()
    {
        var input = "01*0023-";

        foreach (var token in input)
        {
            calculator.AddToken(token);
        }
        
        var expectedResult = 23.0;
        
        Assert.That(calculator.Value, Is.EqualTo(expectedResult).Within(0.001));
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
