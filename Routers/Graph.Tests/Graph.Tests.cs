using System.Runtime.CompilerServices;

namespace Graph.Tests;

[TestFixture]
public class Tests
{
    [Test]
    public void Link_OnTwoVertices()
    {
        var graph = new Graph();

        graph.Link(0, 1, 5);

        (int, int)[] expectedResultFor0 = [(1, 5)];
        (int, int)[] expectedResultFor1 = [(0, 5)];

        Assert.That(graph.GetLinked(0), Is.EqualTo(expectedResultFor0));
        Assert.That(graph.GetLinked(1), Is.EqualTo(expectedResultFor1));
    }

    [Test]
    public void Link_OrdinaryInput()
    {
        var graph = new Graph();

        graph.Link(0, 1, 5);
        graph.Link(0, 2, 10);
        graph.Link(0, 3, 15);
        graph.Link(0, 4, 20);

        (int, int)[] expectedResult = [(1, 5), (2, 10), (3, 15), (4, 20)];

        Assert.That(graph.GetLinked(0), Is.EqualTo(expectedResult));
    }
}
