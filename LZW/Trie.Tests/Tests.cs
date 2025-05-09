// <copyright file="Tests.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>

#pragma warning disable SA1600

namespace Trie.Tests;

/// <summary>
/// Tests class Trie.
/// </summary>
[TestFixture]
public class Tests
{
    private static readonly string[] InputData = ["first", "second", "third", "fourth", "fifth"];
    private Trie trie;

    [SetUp]
    public void SetUp()
        => this.trie = new();

    [Test]
    public void Find_ElementIsNotInTrie()
        => Assert.That(this.trie.FindNumberOf("element"), Is.EqualTo(-1));

    [Test]
    public void Add_OnSequenceOfString_ShouldReturnTrue_Multiply()
    {
        foreach (var s in InputData)
        {
            Assert.That(this.trie.Add(s));
        }
    }

    [Test]
    public void Find_SequenceAsInput()
    {
        foreach (var c in InputData)
        {
            Assert.That(this.trie.Add(c), Is.True);
        }

        for (var i = 0; i < InputData.Length; ++i)
        {
            Assert.That(this.trie.FindNumberOf(InputData[i]), Is.EqualTo(i));
        }
    }

    [Test]
    public void Add_ElementIsAlreadyInTrie()
    {
        this.trie.Add("element");

        Assert.That(!this.trie.Add("element"));
    }

    [Test]
    public void Add_EmptyStringAsInput()
        => Assert.Throws<ArgumentException>(() => this.trie.Add(string.Empty));

    [Test]
    public void Constructor_SequenceAsInput()
    {
        List<string> sequence = ["first", "second", "third"];

        foreach (var s in sequence)
        {
            this.trie.Add(s);
        }

        for (var i = 0; i < sequence.Count; ++i)
        {
            Assert.That(this.trie.FindNumberOf(sequence[i]), Is.EqualTo(i));
        }
    }

    [Test]
    public void Remove_ElementIsInTrie()
    {
        this.trie.Add("element");

        Assert.That(this.trie.Remove("element"));

        Assert.That(this.trie.FindNumberOf("element"), Is.EqualTo(-1));
    }

    [Test]
    public void Remove_ElementIsNotInTrie()
        => Assert.That(!this.trie.Remove("element"));

    [Test]
    public void Remove_EmptyStringAsInput()
        => Assert.Throws<ArgumentException>(() => this.trie.Remove(string.Empty));

    [Test]
    public void Count_EmptyTrie()
        => Assert.That(this.trie.Count, Is.EqualTo(0));

    [Test]
    public void Count_Ordinary()
    {
        foreach (var c in InputData)
        {
            Assert.That(this.trie.Add(c), Is.True);
        }

        Assert.That(this.trie.Count, Is.EqualTo(5));
    }

    [Test]
    public void Count_AddThenRemove()
    {
        this.trie.Add("element");

        Assert.That(this.trie.Count, Is.EqualTo(1));

        this.trie.Remove("element");

        Assert.That(this.trie.Count, Is.EqualTo(0));
    }
}
