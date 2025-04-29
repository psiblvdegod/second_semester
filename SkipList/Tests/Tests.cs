namespace Tests;

using SkipList;

public class Tests
{
    [Test]
    public void Contains_OnEmptyList_ShouldReturnFalse()
    {
        SkipLists<int> list = new ();

        for (var i = 1; i < 100; ++i)
        {
            Assert.That(list.Contains(i), Is.False);
        }
    }

    [Test]
    public void Add_OnRandom()
    {
        SkipLists<int> list = new ();

        var data = new int[10000];
        var rand = new Random();
        for (var i = 0; i < data.Length; ++i)
        {
            data[i] = Math.Abs(rand.Next() % 1000 - 500) + 1;
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
        SkipLists<int> list = new ();

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

    [Test]
    public void Add_OnString()
    {
        SkipLists<string> list = new();

        var rand = new Random();

        var data = new string[1000];

        for (var i = 0; i < data.Length; ++i)
        {
            data[i] = rand.Next().ToString();
        }

        foreach (var s in data)
        {
            list.Add(s);
        }

        foreach (var s in data)
        {
            Assert.That(list.Contains(s));
        }
    }

    /*
    [Test]
    public void Contains_OnZero()
    {
        Assert.That(list.Contains(0), Is.False);

        list.Add(0);

        Assert.That(list.Contains(0));
    }
    */
}
