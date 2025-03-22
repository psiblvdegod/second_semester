namespace MST.Tests;

[TestFixture]
public class Tests
{
    [Test]
    public void Build_SimpleTest1()
    {
        var topology = "0 1 5 2 15\n1 2 10\n2 1 10";

        var expectedResult = ("0 2 15\n2 1 10\n", 25);

        var actualResult = MST.Build(topology);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Build_TestingCountingLengthOfMST()
    {
        var topology = "0 1 1 2 1 3 1\n2 1 2 3 2";

        var expectedResult = 5;

        var actualResult = MST.Build(topology);

        Assert.That(actualResult.totalLength, Is.EqualTo(expectedResult));
    }
}
