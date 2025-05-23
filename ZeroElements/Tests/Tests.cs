namespace Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var list = new MyList.List<int>();

        for (var i = 0; i < 15; ++i)
        {
            list.Add(i);
        }

        foreach (var i in list)
        {
            Console.WriteLine(i);
        }
    }
}
