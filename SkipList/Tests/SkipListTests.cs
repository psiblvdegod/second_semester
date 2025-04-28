namespace Test;

using SkipList;

public class Tests
{

    SkipLists<int> list;
    [SetUp]
    public void Setup()
    {
        list = new ();
        list.AddLevel();
        list.AddLevel();
        
    }

    [Test]
    public void Test()
    {
        for (var i = 1; i < 3; ++i)
        {
            list.Add(i);
        }

        Assert.Pass();
    }
}
