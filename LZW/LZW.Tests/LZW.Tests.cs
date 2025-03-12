namespace LZW.Tests;

using NUnit;
using static LZW;

[TestFixture]
public class Tests
{
    [Test]
    public void Compress_Then_Decompress()
    {
        var input =
        "Аналогично, если бы мы объявили массив из элементов типа-значенияя, то экземпляр был бы сохранен в куче (так как массивы являются ссылочными типами), хотя весь массив потребовал бы только одного выделения памяти.";
        Assert.That(Decompress(Compress(input)), Is.EqualTo(input));
    }
}