namespace PQueue;

public class Tests
{
    [Test]
    public void qtest1()
    {
        var q = new PQueue<int>();

        q.Enqueue(1, 1);
        
        q.Enqueue(3, 3);
        
        q.Enqueue(2, 2);

        q.Enqueue(4, 4);

        Assert.That(q.Dequeue(),  Is.EqualTo(1));
        
        Assert.That(q.Dequeue(),  Is.EqualTo(2));
        
        Assert.That(q.Dequeue(),  Is.EqualTo(3));
        
        Assert.That(q.Dequeue(),  Is.EqualTo(4));
    }
}
