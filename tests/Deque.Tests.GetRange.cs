namespace Deque.Tests;

public partial class Tests
{
    [Fact]
    public void GetRange_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.Empty(d.GetRange(0, 0)); });
    }

    [Theory]
    [MemberData(nameof(TestDataWithIndexAndCount))]
    public void GetRange(List<char> l, Deque<char> d, int index, int count)
    {
        DoesNotModify(d, () =>
        {
            var lRange = l.GetRange(index, count);
            var dRange = d.GetRange(index, count);
            Assert.Equal(lRange, dRange);
        });
    }

    [Fact]
    public void GetRange_ArgumentOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            Assert.Throws<ArgumentOutOfRangeException>(() => d.GetRange(-1, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.GetRange(0, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.GetRange(count + 1, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.GetRange(count, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.GetRange(0, count + 1));
        });
    }
}