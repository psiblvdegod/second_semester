using System.Runtime.CompilerServices;

namespace Graph.Tests;

[TestFixture]
public class Tests
{
    [Test]
    public void Link_OnTwoVertices()
    {
        var graph = new Graph(2);

        graph.Link(0, 1, 5);

        var expectedResult = 5;

        Assert.That(graph.GetWeight(0, 1), Is.EqualTo(expectedResult));
    }

    [Test]
    public void AddAndLink_WithConstructorWhichCreatesSpecifiedAmountOfVertices()
    {
        var graph = new Graph(5);

        graph.Link(0, 1, 5);
        graph.Link(1, 2, 10);
        graph.Link(2, 3, 15);
        graph.Link(3, 4, 20);

        int[] expectedResult = [5, 10, 15, 20];

        for (var i = 0; i < graph.VerticesAmount - 1; ++i)
        {
            Assert.That(graph.GetWeight(i , i + 1), Is.EqualTo(expectedResult[i]));
        }
    }
}
