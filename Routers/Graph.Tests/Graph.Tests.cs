using System.Runtime.CompilerServices;
using System.Security.Cryptography;

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
    public void Link_OnOrdinaryInput()
    {
        var graph = new Graph();

        graph.Link(0, 1, 5);
        graph.Link(0, 2, 10);
        graph.Link(0, 3, 15);
        graph.Link(0, 4, 20);

        (int, int)[] expectedResult = [(1, 5), (2, 10), (3, 15), (4, 20)];

        Assert.That(graph.GetLinked(0), Is.EqualTo(expectedResult));
    }

    [Test]
    public void Constructor_OnTopologyWithInvalidSymbols_ShouldThrowException()
    {
        var topology = "1 2 3\nA 2 3\n";

        Assert.Throws<InvalidTopologyException>(() => new Graph(topology));
    }

    [Test]
    public void Constructor_OnTopologyWithInvalidExpression_ShouldThrowException()
    {
        var topology = "1 2 3\n4 5 6 7\n";

        Assert.Throws<InvalidTopologyException>(() => new Graph(topology));
    }
}
