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
    private readonly int[] data = [1, 2, 3, 4, 5];

    /// <summary>
    /// Tests enumerator for SkipList.
    /// </summary>
    [Test]
    public void VerifyMoveNextAndCurrentWorkProperly()
    {
        var list = new SkipList<int>();

        foreach (var i in this.data)
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
    public void VerifyForEachWorksCorrectly()
    {
        SkipList<int> list = [1, 2, 3, 4, 5];

        Assert.That(list, Has.Count.EqualTo(5));

        foreach (var i in list)
        {
            Assert.That(this.data, Does.Contain(i));
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
