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
            NextList = new(),
        };
    }

    [Test]
    public void Test1()
    {
        int[] top = [30, 40, 20, 10];

        int[] bottom = [40, 20];

        foreach (var i in top)
        {
            lists.Add(new Node<int>(i));
        }

        foreach (var i in bottom)
        {
            lists.NextList.Add(new Node<int>(i));
        }

        Assert.Pass();
    }
}