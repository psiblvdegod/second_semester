using System.Runtime.CompilerServices;

namespace Graph.Tests;

[TestFixture]
public class Tests
{
    [Test]
    public void Add()
    {
        var graph = new Graph();

        graph.Add();

        graph.Add();

        graph.Add();

        graph.Add();

        graph.Link(0, 1, 5);

        graph.Link(2, 1, 10);

        graph.Link(3, 1, 15);

        graph.Link(0, 2, 20);

        graph.Link(0, 3, 25);

        Console.WriteLine(graph.GetTopology());

        Assert.Pass();
    }
}
