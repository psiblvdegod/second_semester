namespace PQueue;

public class Tests
{
    [Test]
    public void IsEmpty_OnEmptyQueue()
    {
        var queue = new PQueue<int>();

        Assert.That(queue.IsEmpty());
    }

    [Test]
    public void IsEmpty_OnNonEmptyQueue()
    {
        var queue = new PQueue<int>();

        queue.Enqueue(2, 1);

        Assert.That(queue.IsEmpty(), Is.False);
    }
}
