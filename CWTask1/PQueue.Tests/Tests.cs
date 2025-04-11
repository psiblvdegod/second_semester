// <copyright file="Tests.cs" author="psiblvdegod">
// under MIT License.
// </copyright>

#pragma warning disable SA1600

namespace PQueue.Tests;

/// <summary>
/// Tests class PQueue.
/// </summary>
public class Tests
{
    [Test]
    public void IsEmpty_OnEmptyIntQueue()
    {
        var queue = new PQueue<int>();

        Assert.That(queue.IsEmpty());
    }

    [Test]
    public void IsEmpty_OnEmptyStringQueue()
    {
        var queue = new PQueue<string>();

        Assert.That(queue.IsEmpty());
    }

    [Test]
    public void IsEmpty_OnNonEmptyIntQueue()
    {
        var queue = new PQueue<int>();

        queue.Enqueue(2, 1);

        Assert.That(queue.IsEmpty(), Is.False);
    }

    [Test]
    public void IsEmpty_OnNonEmptyStringQueue()
    {
        var queue = new PQueue<string>();

        queue.Enqueue("2", 1);

        Assert.That(queue.IsEmpty(), Is.False);
    }
}
