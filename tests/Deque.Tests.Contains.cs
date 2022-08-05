namespace Deque.Tests;

public partial class Tests
{
    #region Contains

    [Fact]
    public void Contains_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () =>
        {
            var item = 'x';
            Assert.False(d.Contains(item));
        });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Contains(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            foreach (var item in ItemsToSearch)
                Assert.Equal(l.Contains(item), d.Contains(item));
        });
    }

    #endregion

    #region IList_Contains

    [Fact]
    public void IList_Contains_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () =>
        {
            var item = 'x';
            Assert.False(((IList)d).Contains(item));
        });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void IList_Contains(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            foreach (var item in ItemsToSearch)
                Assert.Equal(((IList)l).Contains(item), ((IList)d).Contains(item));
        });
    }

    [Fact]
    public void IList_Contains_IncompatibleObject()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var item = 'x';
            Assert.False(((IList)d).Contains(item));
        });
    }

    #endregion
}