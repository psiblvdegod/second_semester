namespace Routers.Tests;

[TestFixture]
public class Tests
{
    [Test]
    public void ConstructorThenGetTopology_OnSpecifiedTopology()
    {
        var topology = "0 1 5\n1 2 10\n2 0 15";

        var expectedResult = "0 1 5 2 15\n1 0 5 2 10\n2 1 10 0 15\n";
        
        var graph = new Routers(topology);

        Assert.That(graph.GetTopology(), Is.EqualTo(expectedResult));
    }
}
