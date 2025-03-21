using System.Runtime.CompilerServices;

namespace Graph.Tests;

[TestFixture]
public class Tests
{
    [Test]
    public void Add_And_Link_On_Two_Vertices()
    {
        var graph = new Graph();

        graph.Add();

        graph.Add();

        graph.Link(0, 1, 5);

        var expectedResult = "0 : 1(5) \n1 : 0(5) \n";

        Assert.That(graph.GetTopology, Is.EqualTo(expectedResult));
    }
}
