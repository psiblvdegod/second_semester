namespace Calculator.Tests;

public class Tests
{
    Calculator calculator;

    private static readonly char floor =
        Calculator.UnaryOperations.First(x => x.Value == Math.Floor).Key;
    private static readonly char ceiling =
        Calculator.UnaryOperations.First(x => x.Value == Math.Ceiling).Key;

    [SetUp]
    public void Setup()
    {
        calculator = new();
    }

    [Test]
    public void Calculator_OnSimpleCorrectInput()
    {
        var input = "12+3=";

        foreach (var token in input)
        {
            calculator.AddToken(token);
        }

        var expectedResult = "15";

        Assert.That(calculator.State, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Calculator_OnNumbersWhichStartWithZero()
    {
        var input = "01*0023=";

        foreach (var token in input)
        {
            calculator.AddToken(token);
        }
        
        var expectedResult = "23";
        
        Assert.That(calculator.State, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Calculator_OnNegativeNumbers()
    {
        var input = "-10--20+30*-1=";

        foreach (var token in input)
        {
            calculator.AddToken(token);
        }

        var expectedResult = "-40";

        Assert.That(calculator.State, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Calculator_OnIncorrectExpression()
    {
        var input = "==10++20//***30=";

        foreach (var token in input)
        {
            calculator.AddToken(token);
        }

        var expectedResult = "1";

        Assert.That(calculator.State, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Calculator_TestingIntermediateStates()
    {
        var input = "10*20+";

        string[] expectedStates = ["1", "10", "10*", "10*2", "10*20", "200+"];

        for (var i = 0; i < input.Length; ++i)
        {
            calculator.AddToken(input[i]);
            Assert.That(calculator.State, Is.EqualTo(expectedStates[i]));
        }
    }

    [Test]
    public void Calculator_TestingIntermediateStates_WithIncorrectExpression()
    {
        var input = "-10++20--20*/=20=";

        string[] expectedStates =
            ["-", "-1", "-10", "-10+", "-10+", "-10+2", "-10+20", "10-", "10--", "10--2", "10--20", "30*", "30*", "30*", "30*2", "30*20", "600"];

        for (var i = 0; i < input.Length; ++i)
        {
            calculator.AddToken(input[i]);
            Assert.That(calculator.State, Is.EqualTo(expectedStates[i]));
        }
    }

    [Test]
    public void Calculator_TestingUnaryOperations()
    {
        var input = $"10.5{floor}.25{ceiling}+2.01={ceiling}";

        string[] expectedStates =
            ["1", "10", "10.", "10.5", "10", "10.", "10.2", "10.25", "11", "11+", "11+2", "11+2.", "11+2.0", "11+2.01", "13.01", "14"];

        for (var i = 0; i < input.Length; ++i)
        {
            calculator.AddToken(input[i]);
            Assert.That(calculator.State, Is.EqualTo(expectedStates[i]));
        }
    }

    [Test]
    public void Calculator_TestingUnaryAndBinaryOperations()
    {
        var input = $"2^4+0.5={ceiling}*1.5={floor}";

        string[] expectedStates =
            ["2", "2^", "2^4", "16+", "16+0", "16+0.", "16+0.5", "16.5", "17", "17*", "17*1", "17*1.", "17*1.5", "25.5", "25"];

        for (var i = 0; i < input.Length; ++i)
        {
            calculator.AddToken(input[i]);
            Assert.That(calculator.State, Is.EqualTo(expectedStates[i]));
        }
    }

    [Test]
    public void Calculator_WhenGetsOperatorsWithNoOperands_ShouldNotReact()
    {
        var tokens = $"{floor}{ceiling}/*=+^";

        for (var i = 0; i < tokens.Length; ++i)
        {
            calculator.AddToken(tokens[i]);
            Assert.That(calculator.State, Is.EqualTo(string.Empty));
        }

        calculator.AddToken('-');
        Assert.That(calculator.State, Is.EqualTo("-"));

        for (var i = 0; i < tokens.Length; ++i)
        {
            calculator.AddToken(tokens[i]);
            Assert.That(calculator.State, Is.EqualTo("-"));
        }
    }
}
