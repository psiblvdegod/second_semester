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
}
