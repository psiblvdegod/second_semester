namespace Tests;

using SkipList;

[TestFixture]
public class SkipListTests
{

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var lists = new SortedLinkLists<int>()
        {
            NextList = new()
            {
                NextList = new(),
            },
        };

        var list = new SkipList<int>(lists);

        list.Add(1);

        list.Add(3);

        list.Add(4);

        list.Add(2);

        Assert.Pass();
    }
}
