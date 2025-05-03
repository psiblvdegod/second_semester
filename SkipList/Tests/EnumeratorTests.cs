// <copyright file="EnumeratorTests.cs" company="_">
// psiblvdegod, 2025, under MIT License
// </copyright>

namespace Tests;

using SkipList;

/// <summary>
/// Tests enumerator of SkipList class.
/// </summary>
[TestFixture]
public class EnumeratorTests
{
    private int[] sortedData;

    private string[] unsortedData;

    [SetUp]
    public void SetUp()
    {
        this.sortedData = [1, 2, 3, 4, 5];
        this.unsortedData = ["b", "c", "c", "a", "b"];
    }

    [Test]
    public void Test1()
    {
        var list = new SkipList<int>();

        foreach (var i in this.sortedData)
        {
            list.Add(i);
        }

        var enumerator = list.GetEnumerator();

        for (var i = 0; i < 5; ++i)
        {
            Assert.That(enumerator.Current, Is.EqualTo(i));
            Assert.That(enumerator.MoveNext(), Is.True);
        }

        Assert.That(enumerator.Current, Is.EqualTo(5));
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void Test2()
    {
        SkipList<int> list = [1, 2, 3, 4, 5];

        Assert.That(list, Has.Count.EqualTo(5));

        foreach (var i in list)
        {
            Assert.That(this.sortedData, Does.Contain(i));
        }
    }

    [Test]
    public void Test3()
    {
        SkipList<string> list = [];

        foreach (var s in this.unsortedData)
        {
            list.Add(s);
        }

        var enumerator = list.GetEnumerator();

        foreach (var s in this.unsortedData.Order())
        {
            enumerator.MoveNext();
            Assert.That(enumerator.Current, Is.EqualTo(s));
        }
    }
}
