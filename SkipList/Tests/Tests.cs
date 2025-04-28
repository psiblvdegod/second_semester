namespace Tests;

using SkipList;

public class Tests
{
    SkipList<int> list;
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
        Assert.That(list.Contains(-1), Is.False);

        for (var i = 1; i < 1000; ++i)
        {
            list.Add(i);
            Assert.That(list.Contains(i));
        }

        Assert.That(list.Contains(1000), Is.False);
    }

}
