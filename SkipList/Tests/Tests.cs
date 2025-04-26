namespace Tests;

using SkipList;

public class Tests
{
    private SkipList<int> list; 

    [SetUp]
    public void Setup()
    {
        list = new();
    }

    [Test]
    public void Test1()
    {
        int[] data = [1, 10, -20, 5, 3, 2, 0, 1, 2, 3, 6];

        foreach (var i in data)
        {
            list.Add(i);
        }
        
        foreach (var i in data)
        {
            Assert.That(list.Contains(i));
        }

        Assert.That(list.Contains(4), Is.False);
    }
}
