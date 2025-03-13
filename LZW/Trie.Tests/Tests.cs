// <copyright file="Trie.cs" author="psiblvdegod" date ="2025">
// under MIT license
// </copyright>
namespace Tests;

using Trie;

/// <summary>
/// Tests class Trie.
/// </summary>
[TestFixture]
public class TrieTests
{
    private static readonly string[] InputData = ["first", "second", "third", "fourth", "fifth"];
    private Trie trie;

    [SetUp]
    public void SetUp()
        => this.trie = new();

    [Test]
    public void Find_ElementIsNotInTrie()
        => Assert.That(this.trie.Find("element"), Is.EqualTo(-1));

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
        this.trie.Add(InputData);

        for (var i = 0; i < InputData.Length; ++i)
        {
            Assert.That(this.trie.Find(InputData[i]), Is.EqualTo(i));
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
            Assert.That(this.trie.Find(sequence[i]), Is.EqualTo(i));
        }
    }

    [Test]
    public void Remove_ElementIsInTrie()
    {
        this.trie.Add("element");

        Assert.That(this.trie.Remove("element"));

        Assert.That(this.trie.Find("element"), Is.EqualTo(-1));
    }

    [Test]
    public void Remove_ElementIsNotInTrie()
        => Assert.That(!this.trie.Remove("element"));

    [Test]
    public void Remove_EmptyStringAsInput()
        => Assert.Throws<ArgumentException>(() => this.trie.Remove(string.Empty));

    [Test]
    public void Size_EmptyTrie()
        => Assert.That(this.trie.Size, Is.EqualTo(0));

    [Test]
    public void Size_Ordinary()
    {
        this.trie.Add(InputData);

        Assert.That(this.trie.Size, Is.EqualTo(5));
    }

    [Test]
    public void Size_AddThenRemove()
    {
        this.trie.Add("element");

        Assert.That(this.trie.Size, Is.EqualTo(1));

        this.trie.Remove("element");

        Assert.That(this.trie.Size, Is.EqualTo(0));
    }
}
