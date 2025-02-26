namespace Tests;

using Trie;

/// <summary>
/// Tests class Trie.
/// </summary>
[TestFixture]
public class TrieTests
{
    [Test]
    public void DoesContain_ElementIsNotInTrie()
    {
        var trie = new Trie();

        Assert.That(!trie.DoesContain("element"));
    }

    [Test]
    public void Add_OrdinaryInput()
    {
        var trie = new Trie();

        List<string> sequence = ["first", "second", "third"];

        for (var i = 0; i < sequence.Count; ++i)
        {
            Assert.That(trie.Add(sequence[i]));
        }

        for (var i = 0; i < sequence.Count; ++i)
        {
            Assert.That(trie.DoesContain(sequence[i]));
        }
    }

    [Test]
    public void Add_ElementIsAlreadyInTrie()
    {
        var trie = new Trie(["element"]);

        Assert.That(!trie.Add("element"));
    }

    [Test]
    public void Add_EmptyStringAsInput()
    {
        var trie = new Trie();

        Assert.Throws<ArgumentException>(() => trie.Add(string.Empty));
    }

    [Test]
    public void Constructor_SequenceAsInput()
    {
        List<string> sequence = ["first", "second", "third"];

        var trie = new Trie(sequence);

        for (var i = 0; i < sequence.Count; ++i)
        {
            Assert.That(trie.DoesContain(sequence[i]));
        }
    }

    [Test]
    public void Remove_ElementIsInTrie()
    {
        var trie = new Trie(["element"]);

        Assert.That(trie.Remove("element"));

        Assert.That(!trie.DoesContain("element"));
    }

    [Test]
    public void Remove_ElementIsNotInTrie()
    {
        var trie = new Trie();

        Assert.That(!trie.Remove("element"));
    }

    [Test]
    public void Remove_EmptyStringAsInput()
    {
        var trie = new Trie();

        Assert.Throws<ArgumentException>(() => trie.Remove(string.Empty));
    }

    [Test]
    public void CountWordsWithSuchPrefix_NoSuchWordsInTrie()
    {
        var trie = new Trie();

        Assert.That(trie.CountWordsWithSuchPrefix("prefix"), Is.EqualTo(0));
    }

    [Test]
    public void CountWordsWithSuchPrefix_OrdinaryInput()
    {
        var trie = new Trie(["first_1", "second_1", "second_2", "third_1", "third_2", "third_3"]);

        Assert.That(trie.CountWordsWithSuchPrefix("second"), Is.EqualTo(2));
    }

    [Test]
    public void CountWordsWithSuchPrefix_EmptyStringAsInput()
    {
        var trie = new Trie();

        Assert.Throws<ArgumentException>(() => trie.CountWordsWithSuchPrefix(string.Empty));
    }
}