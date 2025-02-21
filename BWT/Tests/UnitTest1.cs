namespace Tests;

using Xunit;

using BWT;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        int a = 10;
        int b = 20;
        Assert.True(BWT.sum(a,b) == a + b);
    }
}