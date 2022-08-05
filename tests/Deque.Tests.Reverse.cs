namespace Deque.Tests;

public partial class Tests
{
    [Fact]
    public void Reverse_Empty()
    {
        var d = EmptyDeque();
        Modifies(d, () =>
        {
            d.Reverse();
            Assert.Empty(d);
        });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Reverse(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            l.Reverse();
            d.Reverse();
            Assert.Equal(l, d);
        });
    }

    [Fact]
    public void Reverse_int_int_Empty()
    {
        var d = EmptyDeque();
        Modifies(d, () =>
        {
            d.Reverse(0, 0);
            Assert.Empty(d);
        });
    }

    [Theory]
    [MemberData(nameof(TestDataWithIndexAndCount))]
    public void Reverse_int_int(List<char> l, Deque<char> d, int index, int count)
    {
        Modifies(d, () =>
        {
            l.Reverse(index, count);
            d.Reverse(index, count);
            Assert.Equal(l, d);
        });
    }

    [Fact]
    public void Reverse_int_int_ArgumentOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            Assert.Throws<ArgumentOutOfRangeException>(() => d.Reverse(-1, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.Reverse(0, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.Reverse(count + 1, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.Reverse(count, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.Reverse(0, count + 1));
        });
    }
}