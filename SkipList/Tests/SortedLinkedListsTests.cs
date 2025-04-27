namespace Tests;

using SkipList;

[TestFixture]
public class SortedLinkListsTests
{
    SortedLinkLists<int> lists;

    [SetUp]
    public void SetUp()
    {
        lists = new()
        {
            NextList = new()
            {
                NextList = new(),
            }
        };
    }

    [Test]
    public void Test1()
    {
        lists.Add(new Node<int>(1));
        lists.Add(new Node<int>(3));
        lists.Add(new Node<int>(2));

        Assert.Pass();
    }
}