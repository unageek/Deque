namespace Deque.Tests;

public partial class Tests
{
    [Fact]
    public void Constructor()
    {
        var d = EmptyDeque();
        Assert.Equal(0, d.Capacity);
        Assert.Empty(d);
    }

    [Fact]
    public void Constructor_ZeroCapacity()
    {
        var d = new Deque<char>(0);
        Assert.Equal(0, d.Capacity);
        Assert.Empty(d);
    }

    [Fact]
    public void Constructor_Capacity()
    {
        const int capacity = 24;
        var d = new Deque<char>(capacity);
        Assert.Equal(NextPowerOfTwo(capacity), d.Capacity);
        Assert.Empty(d);
    }

    [Fact]
    public void Constructor_MaxCapacity()
    {
        var d = new Deque<char>(MaxCapacity);
        Assert.Equal(MaxCapacity, d.Capacity);
        Assert.Empty(d);
    }

    [Fact]
    public void Constructor_TooLargeCapacity_OutOfMemoryException()
    {
        Assert.Throws<OutOfMemoryException>(() => new Deque<char>(MaxCapacity + 1));
    }

    [Fact]
    public void Constructor_NegativeCapacity_ArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Deque<char>(-1));
    }

    [Fact]
    public void Constructor_IEnumerable()
    {
        var d = new Deque<char>(new[] { 'a', 'b', 'c' });
        Assert.Equal(4, d.Capacity);
        Assert.Equal(new[] { 'a', 'b', 'c' }, d);
    }
}