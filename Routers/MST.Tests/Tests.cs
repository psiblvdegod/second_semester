// <copyright file="MST.Tests.cs" author="psilbvdegod" date="2025">
// under MIT license.
// </copyright>

namespace MST.Tests;

#pragma warning disable SA1600
#pragma warning disable SA1633

[TestFixture]
public class Tests
{
    [Test]
    public void Build_TestingOutputTopology()
    {
        var topology = "0 1 5\n0 2 15\n1 2 10\n2 1 10\n";

        var expectedResult = ("0 2 15\n2 1 10\n", 25);

        var actualResult = MST.Build(topology);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Build_TestingOutputTotalLength()
    {
        var topology = "10 20 30\n10 40 50\n20 40 70\n";

        var expectedResult = 120;

        var actualResult = MST.Build(topology).totalLength;

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Build_OnMST()
    {
        var topology = "1 2 3\n2 3 4\n3 4 5\n";

        var expectedResult = 12;

        var actualResult = MST.Build(topology).totalLength;

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Build_OnTopologyWitchDiscribesDisconnectedGraph_ShouldThrowException()
    {
        var topology1 = "1 2 3\n3 4 5\n";
        var topology2 = "1 2 3\n2 3 4\n1 3 5\n4 5 6\n5 6 7\n4 6 8\n";

        Assert.Throws<Graph.InvalidTopologyException>(() => MST.Build(topology1));
        Assert.Throws<Graph.InvalidTopologyException>(() => MST.Build(topology2));
    }
}
