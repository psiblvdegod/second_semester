// <copyright file="Tests.cs" author="psiblvdegod">
// under MIT License
// </copyright>

// Elements should be documented.
#pragma warning disable SA1600
#pragma warning disable CS1591

namespace Calculator.Tests;

/// <summary>
/// Tests class Calculator.
/// </summary>
public class Tests
{
    private static readonly char Floor = Calculator.GetTokenByNameOfOperation(_Operation.Floor);
    private static readonly char Ceiling = Calculator.GetTokenByNameOfOperation(_Operation.Ceiling);

    private Calculator calculator;

    [SetUp]
    public void Setup()
    {
        this.calculator = new();
    }

    [Test]
    public void Calculator_OnSimpleCorrectExpression()
    {
        var expression = "12+3=";

        foreach (var token in expression)
        {
            this.calculator.AddToken(token);
        }

        var expectedResult = "15";

        Assert.That(this.calculator.State, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Calculator_OnNumbersWhichStartWithZero()
    {
        var expression = "01*0023=";

        foreach (var token in expression)
        {
            this.calculator.AddToken(token);
        }

        var expectedResult = "23";

        Assert.That(this.calculator.State, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Calculator_OnNegativeNumbers()
    {
        var expression = "-10--20+30*-1=";

        foreach (var token in expression)
        {
            this.calculator.AddToken(token);
        }

        var expectedResult = "-40";

        Assert.That(this.calculator.State, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Calculator_TestingIntermediateStates()
    {
        var expression = "10*20+";

        string[] expectedStates = ["1", "10", "10*", "10*2", "10*20", "200+"];

        for (var i = 0; i < expression.Length; ++i)
        {
            this.calculator.AddToken(expression[i]);
            Assert.That(this.calculator.State, Is.EqualTo(expectedStates[i]));
        }
    }

    [Test]
    public void Calculator_Throws_WhenRightOperandIsMissing()
    {
        var expression = "-10+";

        foreach (var token in expression)
        {
            this.calculator.AddToken(token);
        }

        Assert.Throws<ArgumentException>(() => this.calculator.AddToken('='));
    }

    [Test]
    public void Calculator_WithUnaryOperations()
    {
        var expression = $"10.5{Floor}.25{Ceiling}+2.01={Ceiling}";

        string[] expectedStates =
            ["1", "10", "10.", "10.5", "10", "10.", "10.2", "10.25", "11", "11+", "11+2", "11+2.", "11+2.0", "11+2.01", "13.01", "14"];

        for (var i = 0; i < expression.Length; ++i)
        {
            this.calculator.AddToken(expression[i]);
            Assert.That(this.calculator.State, Is.EqualTo(expectedStates[i]));
        }
    }

    [Test]
    public void Calculator_WithUnaryAndBinaryOperations()
    {
        var expression = $"2^4+0.5={Ceiling}*1.5={Floor}";

        string[] expectedStates =
            ["2", "2^", "2^4", "16+", "16+0", "16+0.", "16+0.5", "16.5", "17", "17*", "17*1", "17*1.", "17*1.5", "25.5", "25"];

        for (var i = 0; i < expression.Length; ++i)
        {
            this.calculator.AddToken(expression[i]);
            Assert.That(this.calculator.State, Is.EqualTo(expectedStates[i]));
        }
    }

    [Test]
    public void Calculator_Throws_OnSeveralDotsInOneNumber()
    {
        var expression = "10+1.1.1=";

        Assert.Throws<ArgumentException>(AddTokens);

        void AddTokens()
        {
            foreach (var token in expression)
            {
                this.calculator.AddToken(token);
            }
        }
    }

    [Test]
    public void Calculator_Throws_IfGetsOperatorsWithNoOperands()
    {
        var tokens = $"{Floor}{Ceiling}/*=+^";

        foreach (var token in tokens)
        {
            Assert.Throws<ArgumentException>(() => this.calculator.AddToken(token));
        }
    }

    [Test]
    public void Calculator_Throws_OnInvalidCharacters()
    {
        var tokens = "_&!@#$%{}[]()help";

        foreach (var token in tokens)
        {
            Assert.Throws<ArgumentException>(() => this.calculator.AddToken(token));
        }
    }

    [Test]
    public void Calculator_OnCleanToken()
    {
        var tokens = $"C1+1=C0";
        string[] expectedStates = [string.Empty, "1", "1+", "1+1", "2", string.Empty, "0"];

        for (var i = 0; i < tokens.Length; ++i)
        {
            this.calculator.AddToken(tokens[i]);
            Assert.That(this.calculator.State, Is.EqualTo(expectedStates[i]));
        }
    }

    [Test]
    public void Calculator_Throws_OnDivizionByZero()
    {
        var expression = "10/0=";

        Assert.Throws<DivideByZeroException>(AddTokens);

        void AddTokens()
        {
            foreach (var token in expression)
            {
                this.calculator.AddToken(token);
            }
        }
    }

    [Test]
    public void Calculator_DoesNotThrow_IfDivizionByZeroWasCanceledByClean()
    {
        var expression = "10/0C";

        Assert.DoesNotThrow(AddTokens);

        void AddTokens()
        {
            foreach (var token in expression)
            {
                this.calculator.AddToken(token);
            }
        }
    }
}
