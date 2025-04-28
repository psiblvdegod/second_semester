namespace Tests;

using SkipList;

public class Tests
{

    SkipLists<int> list;
    [SetUp]
    public void Setup()
    {
        list = new ();
        
    }

    [Test]
    public void Test()
    {
        for (var i = 1; i < 20; ++i)
        {
            list.Add(i);
        }

        Assert.Pass();
    }

    [Test]
    public void Contains()
    {
        for (var i = 1; i < 1000; ++i)
        {
            list.Add(i);
            Assert.That(list.Contains(i));
        }
    }
}
