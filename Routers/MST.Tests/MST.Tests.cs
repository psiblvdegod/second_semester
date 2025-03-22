namespace MST.Tests;

[TestFixture]
public class Tests
{
    [Test]
    public void Build_SimpleTest1()
    {
        var topology = "0 1 5 2 15\n1 2 10\n2 1 10";

        var result = MST.Build(topology);
    }

    [Test]
    public void Build_SimpleTest2()
    {
        var topology = "0 1 5\n2 1 10\n0 2 15\n1 3 20\n3 0 25";

        var result = MST.Build(topology);

    }

    [Test]
    public void Build_SimpleTest3()
    {
        var topology = "0 1 1 2 1 3 1\n2 1 2 3 2";

        var result = MST.Build(topology);
    }
}
