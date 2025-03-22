namespace MST.Tests;

[TestFixture]
public class Tests
{
    [Test]
    public void Get1()
    {
        var topology = "0 1 5\n1 2 10\n0 2 15";

        var result = MST.Build(topology);

        

        Assert.Pass();
    }
}
