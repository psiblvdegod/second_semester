// <copyright file="TrieTests.cs" author="psiblvdegod">
// under MIT License
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
    private Trie trie;

    [SetUp]
    public void SetUp()
        => this.trie = new();

    [Test]
    public void Contains_ElementIsNotInTrie()
        => Assert.That(!this.trie.Contains("element"));

    [Test]
    public void Add_ElementIsAlreadyInTrie()
    {
        var errorCode = this.trie.Add("element");

        Assert.That(errorCode, Is.True);

        errorCode = this.trie.Add("element");

        Assert.Multiple(() =>
        {
            Assert.That(errorCode, Is.False);
            Assert.That(this.trie.Count, Is.EqualTo(1));
        });
    }

    [Test]
    public void Add_EmptyStringAsInput()
        => Assert.Throws<ArgumentException>(() => this.trie.Add(string.Empty));

    [Test]
    public void Remove_ElementIsNotInTrie()
    {
        var errorCode = this.trie.Remove("element");

        Assert.That(errorCode, Is.False);
    }

    [Test]
    public void Count_OnEmptyTrie()
        => Assert.That(this.trie.Count, Is.EqualTo(0));

    [Test]
    public void Count_WithAdd()
    {
        Assert.That(this.trie.Count, Is.EqualTo(0));

        List<string> data = ["first", "second", "third"];

        bool errorCode;

        for (var i = 0; i < data.Count; ++i)
        {
            errorCode = this.trie.Add(data[i]);
            Assert.Multiple(() =>
            {
                Assert.That(errorCode, Is.True);
                Assert.That(this.trie.Count, Is.EqualTo(i + 1));
            });
        }

        foreach (var s in data)
        {
            Assert.That(this.trie.Contains(s));
        }
    }

    [Test]
    public void Count_WithRemove()
    {
        Assert.That(this.trie.Count, Is.EqualTo(0));

        bool errorCode;

        errorCode = this.trie.Add("element");

        Assert.Multiple(() =>
        {
            Assert.That(errorCode, Is.True);
            Assert.That(this.trie.Count, Is.EqualTo(1));
        });

        errorCode = this.trie.Remove("element");

        Assert.Multiple(() =>
        {
            Assert.That(errorCode, Is.True);
            Assert.That(this.trie.Count, Is.EqualTo(0));
            Assert.That(this.trie.Contains("element"), Is.False);
        });
    }

    [Test]
    public void Count_WithAddAndRemove()
    {
        Assert.That(this.trie.Count, Is.EqualTo(0));

        bool errorCode;

        errorCode = this.trie.Add("element");

        Assert.Multiple(() =>
        {
            Assert.That(errorCode, Is.True);
            Assert.That(this.trie.Count, Is.EqualTo(1));
        });

        errorCode = this.trie.Remove("element");
        Assert.Multiple(() =>
        {
            Assert.That(errorCode, Is.True);
            Assert.That(this.trie.Count, Is.EqualTo(0));
        });
    }

    [Test]
    public void Remove_EmptyStringAsInput()
        => Assert.Throws<ArgumentException>(() => this.trie.Remove(string.Empty));

    [Test]
    public void HowManyStartsWithPrefix_Throws_OnEmptyString()
        => Assert.Throws<ArgumentException>(() => this.trie.HowManyStartsWithPrefix(string.Empty));

    [Test]
    public void HowManyStartsWithPrefix_NoSuchWordsInTrie()
        => Assert.That(this.trie.HowManyStartsWithPrefix("prefix"), Is.EqualTo(0));

    [Test]
    public void HowManyStartsWithPrefix_OrdinaryInput()
    {
        IEnumerable<string> data = ["first_1", "second_1", "second_2", "third_1", "third_2", "third_3"];

        bool errorCode;

        foreach (var s in data)
        {
            errorCode = this.trie.Add(s);
            Assert.That(errorCode, Is.True);
        }

        var prefix = "second";

        var expectedResult = 2;

        Assert.That(this.trie.HowManyStartsWithPrefix(prefix), Is.EqualTo(expectedResult));
    }

    [Test]
    public void AddAndRemove_WithLotsOfAsserts()
    {
        bool errorCode;

        errorCode = this.trie.Add("ABC");
        Assert.Multiple(() =>
        {
            Assert.That(errorCode, Is.True);
            Assert.That(this.trie.Count, Is.EqualTo(1));
            Assert.That(this.trie.Contains("A"), Is.False);
            Assert.That(this.trie.Contains("AB"), Is.False);
            Assert.That(this.trie.Contains("ABC"));
        });

        errorCode = this.trie.Add("AB");
        Assert.Multiple(() =>
        {
            Assert.That(errorCode, Is.True);
            Assert.That(this.trie.Count, Is.EqualTo(2));
            Assert.That(this.trie.Contains("AB"));
            Assert.That(this.trie.Contains("ABC"));
        });

        errorCode = this.trie.Remove("AB");

        Assert.Multiple(() =>
        {
            Assert.That(this.trie.Contains("AB"), Is.False);
            Assert.That(this.trie.Contains("ABC"));
            Assert.That(errorCode, Is.True);
            Assert.That(this.trie.Count, Is.EqualTo(1));
        });

        errorCode = !this.trie.Remove("AB");
        Assert.Multiple(() =>
        {
            Assert.That(errorCode, Is.True);
            Assert.That(this.trie.Count, Is.EqualTo(1));
            Assert.That(this.trie.Contains("AB"), Is.False);
            Assert.That(this.trie.Contains("ABC"));
        });

        errorCode = this.trie.Remove("ABC");
        Assert.Multiple(() =>
        {
            Assert.That(errorCode, Is.True);
            Assert.That(this.trie.Count, Is.EqualTo(0));
            Assert.That(this.trie.Contains("AB"), Is.False);
            Assert.That(this.trie.Contains("ABC"), Is.False);
        });
    }

    [Test]
    public void HowManyStartsWithPrefix1()
    {
        List<string> items = ["he", "he", "she", "h", "his", "hers"];

        foreach (var item in items)
        {
            this.trie.Add(item);
        }

        var prefix = "he";
        var expectedResult = 2;

        var actualResult = this.trie.HowManyStartsWithPrefix(prefix);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void HowManyStartsWithPrefix2()
    {
        this.trie.Add("1");
        Assert.That(this.trie.HowManyStartsWithPrefix("1"), Is.EqualTo(1));

        this.trie.Add("11");
        Assert.That(this.trie.HowManyStartsWithPrefix("1"), Is.EqualTo(2));
        Assert.That(this.trie.HowManyStartsWithPrefix("11"), Is.EqualTo(1));

        this.trie.Add("1111");
        Assert.That(this.trie.HowManyStartsWithPrefix("1"), Is.EqualTo(3));
        Assert.That(this.trie.HowManyStartsWithPrefix("11"), Is.EqualTo(2));
        Assert.That(this.trie.HowManyStartsWithPrefix("111"), Is.EqualTo(1));
        Assert.That(this.trie.HowManyStartsWithPrefix("1111"), Is.EqualTo(1));

        this.trie.Remove("1");
        Assert.That(this.trie.HowManyStartsWithPrefix("1"), Is.EqualTo(2));
        Assert.That(this.trie.HowManyStartsWithPrefix("11"), Is.EqualTo(2));
        Assert.That(this.trie.HowManyStartsWithPrefix("111"), Is.EqualTo(1));
        Assert.That(this.trie.HowManyStartsWithPrefix("1111"), Is.EqualTo(1));

        this.trie.Remove("1111");
        Assert.That(this.trie.HowManyStartsWithPrefix("1"), Is.EqualTo(1));
        Assert.That(this.trie.HowManyStartsWithPrefix("11"), Is.EqualTo(1));
        Assert.That(this.trie.HowManyStartsWithPrefix("111"), Is.EqualTo(0));
        Assert.That(this.trie.HowManyStartsWithPrefix("1111"), Is.EqualTo(0));

        this.trie.Add("111");
        Assert.That(this.trie.HowManyStartsWithPrefix("1"), Is.EqualTo(2));
        Assert.That(this.trie.HowManyStartsWithPrefix("11"), Is.EqualTo(2));
        Assert.That(this.trie.HowManyStartsWithPrefix("111"), Is.EqualTo(1));
        Assert.That(this.trie.HowManyStartsWithPrefix("1111"), Is.EqualTo(0));
    }
}
