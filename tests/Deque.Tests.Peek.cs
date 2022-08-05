namespace Deque.Tests;

public partial class Tests
{
    #region PeekFirst

    [Fact]
    public void PeekFirst_Empty_InvalidOperationException()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.Throws<InvalidOperationException>(() => d.PeekFirst()); });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void PeekFirst(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () => { Assert.Equal(l[0], d.PeekFirst()); });
    }

    #endregion

    #region PeekLast

    [Fact]
    public void PeekLast_Empty_InvalidOperationException()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.Throws<InvalidOperationException>(() => d.PeekLast()); });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void PeekLast(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () => { Assert.Equal(l[^1], d.PeekLast()); });
    }

    #endregion

    #region TryPeekFirst

    [Fact]
    public void TryPeekFirst_Empty()
    {
        var d = new Deque<char>();
        DoesNotModify(d, () =>
        {
            Assert.False(d.TryPeekFirst(out var c));
            Assert.Equal('\0', c);
        });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void TryPeekFirst(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            Assert.True(d.TryPeekFirst(out var first));
            Assert.Equal(l[0], first);
        });
    }

    #endregion

    #region TryPeekLast

    [Fact]
    public void TryPeekLast_Empty()
    {
        var d = new Deque<char>();
        DoesNotModify(d, () =>
        {
            Assert.False(d.TryPeekLast(out var c));
            Assert.Equal('\0', c);
        });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void TryPeekLast(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            Assert.True(d.TryPeekLast(out var last));
            Assert.Equal(l[^1], last);
        });
    }

    #endregion
}