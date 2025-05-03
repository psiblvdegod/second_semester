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
    private readonly int[] sortedData = [1, 2, 3, 4, 5];

    private readonly string[] unsortedData = ["b", "c", "c", "a", "b"];

    /// <summary>
    /// Tests enumerator for SkipList.
    /// </summary>
    [Test]
    public void VerifyMoveNextAndCurrentWorkProperly()
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

    /// <summary>
    /// Tests enumerator for SkipList.
    /// </summary>
    [Test]
    public void VerifyCollectionIsInitializedCorrectly()
    {
        SkipList<int> list = [1, 2, 3, 4, 5];

        Assert.That(list, Has.Count.EqualTo(5));

        foreach (var i in list)
        {
            Assert.That(this.sortedData, Does.Contain(i));
        }
    }

    /// <summary>
    /// Tests enumerator for SkipList.
    /// </summary>
    [Test]
    public void VerifyListIsSorted()
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

    /// <summary>
    /// Tests enumerator for SkipList.
    /// </summary>
    [Test]
    public void VerifyEnumeratorInvalidatesOnChanges()
    {
        SkipList<bool> list = [false, true, false];

        var enumerator = list.GetEnumerator();

        Assert.That(enumerator.MoveNext(), Is.True);

        Assert.That(enumerator.Current, Is.False);

        list.Add(true);

        Assert.Throws<InvalidOperationException>(() => enumerator.MoveNext());

        Assert.That(enumerator.Current, Is.False);
    }
}
