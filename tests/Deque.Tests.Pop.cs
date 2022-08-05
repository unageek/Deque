namespace Deque.Tests;

public partial class Tests
{
    #region PopFirst

    [Fact]
    public void PopFirst_Empty_InvalidOperationException()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.Throws<InvalidOperationException>(() => d.PopFirst()); });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void PopFirst(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            Assert.Equal(l[0], d.PopFirst());
            l.RemoveAt(0);
            Assert.Equal(l, d);
        });
    }

    #endregion

    #region PopLast

    [Fact]
    public void PopLast_Empty_InvalidOperationException()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.Throws<InvalidOperationException>(() => d.PopLast()); });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void PopLast(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            Assert.Equal(l[^1], d.PopLast());
            l.RemoveAt(l.Count - 1);
            Assert.Equal(l, d);
        });
    }

    #endregion

    #region TryPopFirst

    [Fact]
    public void TryPopFirst_Empty()
    {
        var d = new Deque<char>();
        DoesNotModify(d, () =>
        {
            Assert.False(d.TryPopFirst(out var c));
            Assert.Equal('\0', c);
        });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void TryPopFirst(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            Assert.True(d.TryPopFirst(out var first));
            Assert.Equal(l[0], first);
            l.RemoveAt(0);
            Assert.Equal(l, d);
        });
    }

    #endregion

    #region TryPopLast

    [Fact]
    public void TryPopLast_Empty()
    {
        var d = new Deque<char>();
        DoesNotModify(d, () =>
        {
            Assert.False(d.TryPopLast(out var c));
            Assert.Equal('\0', c);
        });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void TryPopLast(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            Assert.True(d.TryPopLast(out var last));
            Assert.Equal(l[^1], last);
            l.RemoveAt(l.Count - 1);
            Assert.Equal(l, d);
        });
    }

    #endregion
}