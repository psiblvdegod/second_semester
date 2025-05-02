// <copyright file="Tests.cs" company="_">
// psiblvdegod, 2025, under MIT License
// </copyright>

namespace Tests;

using SkipList;

/// <summary>
/// Tests SkipList methods.
/// </summary>
public class Tests
{
    /// <summary>
    /// Tests Contains.
    /// </summary>
    [Test]
    public void Contains_OnEmptyList_ShouldReturnFalse()
    {
        SkipList<int> list = [];

        for (var i = 1; i < 100; ++i)
        {
            Assert.That(list.Contains(i), Is.False);
        }
    }

    /// <summary>
    /// Tests Add().
    /// </summary>
    [Test]
    public void Add_OnRandom()
    {
        SkipList<int> list = [];

        var data = new int[10000];
        for (var i = 0; i < data.Length; ++i)
        {
            data[i] = Math.Abs((Random.Shared.Next() % 1000) - 500) + 1;
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

    /// <summary>
    /// Tests Add().
    /// </summary>
    [Test]
    public void Add_OnRandomNumbers()
    {
        SkipList<int> list = [];

        var data = new int[10000];

        for (var i = 0; i < data.Length; ++i)
        {
            data[i] = Random.Shared.Next();
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

    /// <summary>
    /// Tests Add().
    /// </summary>
    [Test]
    public void Add_OnString()
    {
        SkipList<string> list = [];

        var data = new string[1000];

        for (var i = 0; i < data.Length; ++i)
        {
            data[i] = Random.Shared.Next().ToString();
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

    /// <summary>
    /// Tests Contains.
    /// </summary>
    [Test]
    public void Contains_OnBool()
    {
        var list = new SkipList<bool>();

        Assert.That(list.Contains(true), Is.False);
        Assert.That(list.Contains(false), Is.False);

        list.Add(false);

        Assert.That(list.Contains(true), Is.False);
        Assert.That(list.Contains(false));

        list.Add(true);

        Assert.That(list.Contains(true));
        Assert.That(list.Contains(false));
    }

    /// <summary>
    /// Tests Remove().
    /// </summary>
    [Test]
    public void Remove()
    {
        var list = new SkipList<int>();

        var data = new int[1000];

        for (var i = 0; i < data.Length; ++i)
        {
            data[i] = Random.Shared.Next() % 1000;
        }

        foreach (var i in data)
        {
            list.Add(i);
        }

        foreach (var i in data)
        {
            Assert.That(list.Contains(i));
        }

        var deletingElements = data.Where(i => i % 2 == 0);

        foreach (var i in deletingElements)
        {
            list.Remove(i);
        }

        foreach (var i in deletingElements)
        {
            Assert.That(list.Contains(i), Is.False);
        }

        foreach (var i in data.Except(deletingElements))
        {
            Assert.That(list.Contains(i));
        }
    }

    /// <summary>
    /// Tests Remove().
    /// </summary>
    [Test]
    public void Remove_OnOneElement()
    {
        var list = new SkipList<string>();

        var item = "string";

        Assert.That(list.Contains(item), Is.False);
        Assert.That(list.Count, Is.EqualTo(0));

        list.Add(item);

        Assert.That(list.Contains(item));
        Assert.That(list.Count, Is.EqualTo(1));

        list.Remove(item);

        Assert.That(list.Contains(item), Is.False);
        Assert.That(list.Count, Is.EqualTo(0));
    }

    /// <summary>
    /// Tests Remove().
    /// </summary>
    [Test]
    public void Remove_WithRepeatingElements()
    {
        var list = new SkipList<string>();

        List<string> data =
            ["100", "200", "300", "400", "100", "200", "300", "100", "200", "100"];

        foreach (var s in data)
        {
            Assert.That(list.Contains(s), Is.False);
            Assert.That(list.Count, Is.EqualTo(0));
        }

        foreach (var s in data)
        {
            list.Add(s);
        }

        Assert.That(list.Count, Is.EqualTo(data.Count));

        var unique = data.Distinct();

        foreach (var s in unique)
        {
            Assert.That(list.Contains(s));
        }

        foreach (var s in unique)
        {
            Assert.That(list.Remove(s), Is.True);
        }

        Assert.Multiple(() =>
        {
            Assert.That(list.Contains("100"));
            Assert.That(list.Contains("200"));
            Assert.That(list.Contains("300"));
            Assert.That(list.Contains("400"), Is.False);
            Assert.That(list.Count, Is.EqualTo(6));

            Assert.That(list.Remove("400"), Is.False);
            Assert.That(list.Count, Is.EqualTo(6));
            Assert.That(list.Remove("300"), Is.True);
            Assert.That(list.Count, Is.EqualTo(5));

            Assert.That(list.Contains("100"));
            Assert.That(list.Contains("200"));
            Assert.That(list.Contains("300"), Is.False);
            Assert.That(list.Contains("400"), Is.False);
            Assert.That(list.Count, Is.EqualTo(5));
        });
    }

    /// <summary>
    /// Tests CopyTo().
    /// </summary>
    [Test]
    public void CopyTo()
    {
        var list = new SkipList<int>();

        var data = new int[100];

        for (var i = 0; i < data.Length; ++i)
        {
            data[i] = Random.Shared.Next();
        }

        foreach (var i in data)
        {
            list.Add(i);
        }

        foreach (var i in data)
        {
            Assert.That(list.Contains(i));
        }

        var copy = new int[100];

        list.CopyTo(copy);

        Assert.That(copy.Order(), Is.EqualTo(data.Order()));
    }

    /// <summary>
    /// Tests Clear().
    /// </summary>
    [Test]
    public void Clear()
    {
        var list = new SkipList<string>();
        Assert.That(list.Count, Is.EqualTo(0));
        list.Add("string");
        Assert.That(list.Contains("string"));
        Assert.That(list.Count, Is.EqualTo(1));
        list.Clear();
        Assert.That(list.Contains("string"), Is.False);
        Assert.That(list.Count, Is.EqualTo(0));
    }

    /// <summary>
    /// Tests IndexOf().
    /// </summary>
    [Test]
    public void IndexOf()
    {
        var list = new SkipList<int>();

        int[] data = [-10, 10, -20, 20, -30, 30];

        foreach (var i in data)
        {
            list.Add(i);
        }

        foreach (var i in data)
        {
            Assert.That(list.Contains(i));
        }

        Assert.Multiple(() =>
        {
            Assert.That(list.IndexOf(40), Is.EqualTo(-1));
            Assert.That(list.IndexOf(10), Is.EqualTo(3));
            Assert.That(list.IndexOf(-30), Is.EqualTo(0));
        });
    }

    /// <summary>
    /// Tests RemoveAt().
    /// </summary>
    [Test]
    public void RemoveAt()
    {
        var list = new SkipList<int>();

        Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(0));

        int[] data = [0, 1, 2, 3, 4, 5];

        foreach (var i in data)
        {
            list.Add(i);
        }

        foreach (var i in data)
        {
            Assert.That(list.Contains(i));
        }

        list.RemoveAt(5);

        Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(5));

        Assert.That(list.Count, Is.EqualTo(5));
        Assert.That(list.Contains(5), Is.False);

        list.RemoveAt(0);

        Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(4));

        Assert.That(list.Count, Is.EqualTo(4));
        Assert.That(list.Contains(0), Is.False);

        foreach (var i in data[1..^1])
        {
            Assert.That(list.Contains(i));
        }
    }

    /// <summary>
    /// Tests get of indexator.
    /// </summary>
    [Test]
    public void IndexatorGet()
    {
        var list = new SkipList<string>();

        string[] data = ["0", "1", "2", "3", "4", "5"];

        foreach (var s in data)
        {
            list.Add(s);
        }

        foreach (var s in data)
        {
            Assert.That(list.Contains(s));
        }

        for (var i = 0; i < data.Length; ++i)
        {
            Assert.That(list[i], Is.EqualTo(data[i]));
        }
    }

    /// <summary>
    /// Tests methods which is not supported.
    /// </summary>
    [Test]
    public void NotSupported()
    {
        var list = new SkipList<bool>();

        Assert.Throws<NotSupportedException>(() => { list[0] = false; });
        Assert.Throws<NotSupportedException>(() => { list.Insert(0, false); });
    }
}
