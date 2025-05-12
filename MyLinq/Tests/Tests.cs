// <copyright file="Tests.cs" company="_">
// psiblvdegod, 2025, under MIT License.
// </copyright>

namespace Tests;

using MyLinq;

#pragma warning disable SA1600

public class Tests
{
    private static readonly IEnumerable<int> IntSource = [1, 2, 3, 5, 7, 11, 13, 17, 19, 23, 29];

    private static readonly IEnumerable<string> StringSource = ["2", "4", "6", "1", "3", "5"];

    [Test]
    public void MyTake_OnInts()
    {
        var count = 3;
        var expectedResult = IntSource.Take(count);
        var actualResult = IntSource.MyTake(count);
        Assert.That(actualResult.SequenceEqual(expectedResult));
    }

    [Test]
    public void MySkip_OnStrings()
    {
        var count = 5;
        var expectedResult = StringSource.Skip(count);
        var actualResult = StringSource.MySkip(count);
        Assert.That(actualResult.SequenceEqual(expectedResult));
    }

    [Test]
    public void MySkip_OnNonPozitiveCount_ShouldReturnInitialSequence()
    {
        var count = -5;
        var expectedResult = IntSource.Skip(count);
        Assert.That(expectedResult.SequenceEqual(IntSource));
        var actualResult = IntSource.MySkip(count);
        Assert.That(actualResult.SequenceEqual(expectedResult));
    }

    [Test]
    public void MyTake_OnNonPozitiveCount_ShouldReturnEmptySequence()
    {
        var count = 0;
        var expectedResult = StringSource.Take(count);
        Assert.That(expectedResult.SequenceEqual([]));
        var actualResult = StringSource.MyTake(count);
        Assert.That(actualResult.SequenceEqual(expectedResult));
    }

    [Test]
    public void MyTake_OnIndexOutOfRange_ShouldReturnInitialSequence()
    {
        var count = IntSource.Count() + 1;
        var expectedResult = IntSource.Take(count);
        Assert.That(expectedResult.SequenceEqual(IntSource));
        var actualResult = IntSource.MyTake(count);
        Assert.That(actualResult.SequenceEqual(expectedResult));
    }

    [Test]
    public void MySkip_OnIndexOutOfRange_ShouldReturnEmptySequence()
    {
        var count = StringSource.Count() + 1;
        var expectedResult = StringSource.Skip(count);
        Assert.That(expectedResult.SequenceEqual([]));
        var actualResult = StringSource.MySkip(count);
        Assert.That(actualResult.SequenceEqual(expectedResult));
    }

    [Test]
    public void Primes_Get_WithMyTake()
    {
        var count = 7;
        var expectedResult = IntSource.Take(count);
        var actualResult = Primes.Get().MyTake(count);
        Assert.That(actualResult.SequenceEqual(expectedResult));
    }

    [Test]
    public void Primes_Get_WithMySkipThenMyTake()
    {
        var skipCount = 4;
        var takeCount = 3;
        var expectedResult = IntSource.Skip(skipCount).Take(takeCount);
        var actualResult = Primes.Get().MySkip(skipCount).MyTake(takeCount);
        Assert.That(actualResult.SequenceEqual(expectedResult));
    }
}
