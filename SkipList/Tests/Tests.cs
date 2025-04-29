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
    public void Contains_OnEmptyList_ShouldReturnFalse()
    {
        for (var i = 1; i < 100; ++i)
        {
            Assert.That(list.Contains(i), Is.False);
        }
    }

    [Test]
    public void Add_OnRandomPositiveNumbers()
    {
        var data = new int[50];
        var rand = new Random();
        for (var i = 0; i < data.Length; ++i)
        {
            data[i] = Math.Abs(rand.Next() % 100) + 1;
        }
        foreach (var i in data)
        {
            list.Add(i);
        }
        foreach (var i in data)
        {
            Assert.That(list.Contains(i));
        }
    }

    [Test]
    public void Add_OnRandomNumbers()
    {
        var data = new int[10000];

        var rand = new Random();

        for (var i = 0; i < data.Length; ++i)
        {
            data[i] = rand.Next();
        }

        foreach (var i in data)
        {
            list.Add(i);
        }

        foreach (var i in data)
        {
            Assert.That(list.Contains(i));
        }
    }
}
