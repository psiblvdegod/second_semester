namespace Tests;

using MyLinq;

public class Tests
{
    private static readonly IEnumerable<int> IntSource = [ 5, 4, 3, 2, 1 ];

    private static readonly IEnumerable<string> StringSource = [ "2", "4", "6", "1", "3", "5" ];

    [Test]
    public void MyTake_OnInts()
    {
        int count = 3;
        var expectedResult = IntSource.Take(count);
        var actualResult = IntSource.MyTake(count);
        Assert.That(actualResult.SequenceEqual(expectedResult));
    }

    [Test]
    public void MySkip_OnStrings()
    {
        int count = 1;
        var expectedResult = IntSource.Skip(count);
        var actualResult = IntSource.MySkip(count);
        Assert.That(actualResult.SequenceEqual(expectedResult));
    }

    [Test]
    public void MyTake_Throws_WhenCountIsNegative()
        => Assert.Throws<ArgumentOutOfRangeException>(() => StringSource.MyTake(-5).First());
    
    [Test]
    public void MySkip_Throws_WhenCountIsNegative()
        => Assert.Throws<ArgumentOutOfRangeException>(() => IntSource.MySkip(-5).First());

    [Test]
    public void MyTake_Throws_WhenCountIsToBig()
        => Assert.Throws<ArgumentOutOfRangeException>(() => IntSource.MyTake(IntSource.Count()).First());
    
    [Test]
    public void MySkip_Throws_WhenCountIsToBig()
        => Assert.Throws<ArgumentOutOfRangeException>(() => StringSource.MySkip(StringSource.Count() + 1).First());

    [Test]
    public void MyTake_ShouldBeLazy()
    {
        IEnumerable<int>? incorrertSequence = null;
        Assert.DoesNotThrow(() => incorrertSequence = IntSource.MyTake(-1));
        Assert.That(incorrertSequence, Is.Not.Null);
        Assert.Throws<ArgumentOutOfRangeException>(() => incorrertSequence.First());
    }

    [Test]
    public void MySkip_ShouldBeLazy()
    {
        IEnumerable<int>? incorrertSequence = null;
        Assert.DoesNotThrow(() => incorrertSequence = IntSource.MySkip(-1));
        Assert.That(incorrertSequence, Is.Not.Null);
        Assert.Throws<ArgumentOutOfRangeException>(() => incorrertSequence.First());
    }
}
