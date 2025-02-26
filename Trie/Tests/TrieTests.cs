namespace Tests;

using Trie;

[TestFixture]
public class TrieTests
{
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
    public void Add_OneElementAsInput()
    {
        var trie = new Trie();

        Assert.That(trie.Add("string"));

        Assert.That(trie.DoesContain("string"));
    }

    [Test]
    public void Add_SequenceAsInput()
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
    public void Add_EmptyStringAsInput()
    {
        var trie = new Trie();

        Assert.Throws<ArgumentException>(() => trie.Add(string.Empty));
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
}