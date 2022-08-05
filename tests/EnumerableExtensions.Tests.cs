namespace Deque.Tests;

public partial class Tests
{
    [Fact]
    public void ToDeque()
    {
        var d = new[] { 'a', 'b', 'c' }.ToDeque();
        Assert.Equal(new[] { 'a', 'b', 'c' }, d);
    }

    [Fact]
    public void ToDeque_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => ((IEnumerable<int>)null!).ToDeque());
    }
}