using SkipList;

namespace Tests;
/*
[TestFixture]
public class EnumeratorTests
{
    private SkipList<int> list;
    private int[] data;


    [SetUp]
    public void SetUp()
    {
        list = [];
        data = [0, 1, 2, 3, 4, 5];
    }
    
    [Test]
    public void TestForMoveNextAndCurrent()
    {
        var enumerator = list.GetEnumerator();

        Assert.Throws<InvalidOperationException>(() => { var _ = enumerator.Current; });

        foreach (var i in data)
        {        
            Assert.That(enumerator.MoveNext(), Is.True);
            Assert.That(enumerator.Current, Is.EqualTo(i));
        }

        Assert.Throws<InvalidOperationException>(() => { var _ = enumerator.Current; });
    }
}
*/