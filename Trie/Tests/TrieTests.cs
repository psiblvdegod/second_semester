// <copyright file="TrieTests.cs" author="psiblvdegod" date ="2025">
// under MIT license
// </copyright>

// SA1600: Elements should be documented.
#pragma warning disable SA1600

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
            var errorCode = trie.Add(sequence[i]);

            Assert.That(errorCode, Is.True);
            Assert.That(trie.Size, Is.EqualTo(i + 1));
        }

        for (var i = 0; i < sequence.Count; ++i)
        {
            Assert.That(trie.DoesContain(sequence[i]), Is.True);
        }
    }

    [Test]
    public void Add_ElementIsAlreadyInTrie()
    {
        var trie = new Trie(["element"]);

        var errorCode = !trie.Add("element");

        Assert.That(errorCode, Is.True);
        Assert.That(trie.Size, Is.EqualTo(1));
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

        Assert.That(trie.Size, Is.EqualTo(1));

        var errorCode = trie.Remove("element");

        Assert.That(errorCode, Is.True);
        Assert.That(trie.Size, Is.EqualTo(0));
        Assert.That(!trie.DoesContain("element"));
    }

    [Test]
    public void Remove_ElementIsNotInTrie()
    {
        var trie = new Trie();

        var errorCode = !trie.Remove("element");

        Assert.That(errorCode, Is.True);
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

        var input = "second";

        var expectedResult = 0;

        Assert.That(trie.CountWordsWithSuchPrefix(input), Is.EqualTo(expectedResult));
    }

    [Test]
    public void CountWordsWithSuchPrefix_OrdinaryInput()
    {
        IEnumerable<string> data = ["first_1", "second_1", "second_2", "third_1", "third_2", "third_3"];

        var trie = new Trie(data);

        var input = "second";

        var expectedResult = 2;

        Assert.That(trie.CountWordsWithSuchPrefix(input), Is.EqualTo(expectedResult));
    }

    [Test]
    public void CountWordsWithSuchPrefix_EmptyStringAsInput()
    {
        var trie = new Trie();

        Assert.Throws<ArgumentException>(() => trie.CountWordsWithSuchPrefix(string.Empty));
    }

    [Test]
    public void Size_EmptyTrie()
    {
        var trie = new Trie();

        var expectedResult = 0;

        Assert.That(trie.Size, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Size_Ordinary()
    {
        IEnumerable<string> data = ["1", "2", "3", "4", "5"];

        var trie = new Trie(data);

        var expectedResult = data.Count();

        Assert.That(trie.Size, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Size_AddThenRemove()
    {
        var trie = new Trie();

        bool errorCode;

        errorCode = trie.Add("element");

        Assert.That(errorCode, Is.True);
        Assert.That(trie.Size, Is.EqualTo(1));

        errorCode = trie.Remove("element");
        Assert.That(errorCode, Is.True);

        Assert.That(trie.Size, Is.EqualTo(0));
    }

    [Test]
    public void AddAndRemove_WithLotsOfAsserts()
    {
        var trie = new Trie();

        bool errorCode;

        errorCode = trie.Add("ABC");
        Assert.That(errorCode, Is.True);
        Assert.That(trie.Size, Is.EqualTo(1));
        Assert.That(trie.DoesContain("A"), Is.False);
        Assert.That(trie.DoesContain("AB"), Is.False);
        Assert.That(trie.DoesContain("ABC"));

        errorCode = trie.Add("AB");
        Assert.That(errorCode, Is.True);
        Assert.That(trie.Size, Is.EqualTo(2));
        Assert.That(trie.DoesContain("AB"));
        Assert.That(trie.DoesContain("ABC"));

        errorCode = trie.Remove("AB");
        Assert.That(errorCode, Is.True);
        Assert.That(trie.Size, Is.EqualTo(1));
        Assert.That(trie.DoesContain("AB"), Is.False);
        Assert.That(trie.DoesContain("ABC"));

        errorCode = !trie.Remove("AB");
        Assert.That(errorCode, Is.True);
        Assert.That(trie.Size, Is.EqualTo(1));
        Assert.That(trie.DoesContain("AB"), Is.False);
        Assert.That(trie.DoesContain("ABC"));

        errorCode = trie.Remove("ABC");
        Assert.That(errorCode, Is.True);
        Assert.That(trie.Size, Is.EqualTo(0));
        Assert.That(trie.DoesContain("AB"), Is.False);
        Assert.That(trie.DoesContain("ABC"), Is.False);
    }

    [Test]
    public void AddAndRemove_OnRootSymbol()
    {
        var trie = new Trie();

        Assert.That(trie.DoesContain("/"), Is.False);

        bool errorCode;

        errorCode = !trie.Remove("/");
        Assert.That(errorCode, Is.True);
        Assert.That(trie.Size, Is.EqualTo(0));
        Assert.That(trie.DoesContain("/"), Is.False);

        errorCode = trie.Add("/");
        Assert.That(errorCode, Is.True);
        Assert.That(trie.Size, Is.EqualTo(1));
        Assert.That(trie.DoesContain("/"));

        errorCode = trie.Remove("/");
        Assert.That(errorCode, Is.True);
        Assert.That(trie.Size, Is.EqualTo(0));
        Assert.That(trie.DoesContain("/"), Is.False);
    }
}
