namespace Deque.Tests;

public partial class Tests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void EnsureCapacity(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            d.EnsureCapacity(d.Count);
            Assert.Equal(NextPowerOfTwo(d.Count), d.Capacity);
        });

        Modifies(d, () =>
        {
            d.EnsureCapacity(2 * d.Count);
            Assert.Equal(NextPowerOfTwo(2 * d.Count), d.Capacity);
        });
    }

    [Fact]
    public void EnsureCapacity_ZeroCapacity()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () =>
        {
            d.EnsureCapacity(0);
            Assert.Equal(0, d.Capacity);
        });
    }

    [Fact]
    public void EnsureCapacity_MaxCapacity()
    {
        var d = SampleDeque();
        Modifies(d, () =>
        {
            d.EnsureCapacity(MaxCapacity);
            Assert.Equal(MaxCapacity, d.Capacity);
            Assert.Equal(new[] { 'a', 'b', 'c' }, d);
        });
    }

    [Fact]
    public void EnsureCapacity_TooLargeCapacity_OutOfMemoryException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            Assert.Throws<OutOfMemoryException>(() => d.EnsureCapacity(MaxCapacity + 1));
            Assert.Equal(4, d.Capacity);
        });
    }

    [Fact]
    public void EnsureCapacity_NegativeCapacity_ArgumentOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => d.EnsureCapacity(-1));
            Assert.Equal(4, d.Capacity);
        });
    }
}