namespace MST.Tests;

[TestFixture]
public class Tests
{
    [Test]
    public void Build_SimpleTest1()
    {
        var topology = "0 1 5\n0 2 15\n1 2 10\n2 1 10\n";

        var expectedResult = ("0 2 15\n2 1 10\n", 25);

        var actualResult = MST.Build(topology);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Build_TestingCountingLengthOfMST()
    {
        var topology = "0 1 1\n0 2 1\n0 3 1\n2 1 2\n2 3 2\n";

        var expectedResult = 5;

        var actualResult = MST.Build(topology);

        Assert.That(actualResult.totalLength, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Build_Test3()
    {
        var topology = "10 20 30\n10 40 50\n20 40 70\n";

        var expectedResult = 120;

        var actualResult = MST.Build(topology).totalLength;

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Build_Test4()
    {
        var topology = "1 2 -3\n1 3 -4\n1 5 -1\n2 3 -5\n3 4 -2\n3 5 -6\n4 5 -7\n";

        var expectedResult = -10;

        var actualResult = MST.Build(topology).totalLength;

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
