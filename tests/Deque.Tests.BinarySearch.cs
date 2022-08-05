namespace Deque.Tests;

public partial class Tests
{
    #region BinarySearch

    [Fact]
    public void BinarySearch_Empty()
    {
        var d = EmptyDeque();
        var item = 'x';
        DoesNotModify(d, () => { Assert.Equal(~0, d.BinarySearch(item)); });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void BinarySearch(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            foreach (var item in ItemsToSearch)
                Assert.Equal(l.BinarySearch(item), d.BinarySearch(item));
        });
    }

    #endregion

    #region BinarySearch_IComparer

    [Fact]
    public void BinarySearch_IComparer_Empty()
    {
        var d = EmptyDeque();
        var item = 'x';
        DoesNotModify(d, () => { Assert.Equal(~0, d.BinarySearch(item, null)); });
    }

    [Theory]
    [MemberData(nameof(TestDataReversed))]
    public void BinarySearch_IComparer(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            var greater = new Greater();
            foreach (var item in ItemsToSearch)
                Assert.Equal(l.BinarySearch(item, greater), d.BinarySearch(item, greater));
        });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void BinarySearch_IComparer_NullComparer(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            foreach (var item in ItemsToSearch)
                Assert.Equal(l.BinarySearch(item, null), d.BinarySearch(item, null));
        });
    }

    #endregion

    #region BinarySearch_int_int_IComparer

    [Fact]
    public void BinarySearch_int_int_IComparer_Empty()
    {
        var d = EmptyDeque();
        var item = 'x';
        DoesNotModify(d, () => { Assert.Equal(~0, d.BinarySearch(0, 0, item, null)); });
    }

    [Theory]
    [MemberData(nameof(TestDataWithIndexAndCountReversed))]
    public void BinarySearch_int_int_IComparer(List<char> l, Deque<char> d, int index, int count)
    {
        DoesNotModify(d, () =>
        {
            var greater = new Greater();
            foreach (var item in ItemsToSearch)
                Assert.Equal(l.BinarySearch(index, count, item, greater), d.BinarySearch(index, count, item, greater));
        });
    }

    [Theory]
    [MemberData(nameof(TestDataWithIndexAndCount))]
    public void BinarySearch_int_int_IComparer_NullComparer(List<char> l, Deque<char> d, int index, int count)
    {
        DoesNotModify(d, () =>
        {
            foreach (var item in ItemsToSearch)
                Assert.Equal(l.BinarySearch(index, count, item, null), d.BinarySearch(index, count, item, null));
        });
    }

    [Fact]
    public void BinarySearch_int_int_IComparer_ArgumentOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            var item = 'x';
            Assert.Throws<ArgumentOutOfRangeException>(() => d.BinarySearch(-1, 0, item, null));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.BinarySearch(0, -1, item, null));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.BinarySearch(count + 1, 0, item, null));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.BinarySearch(count, 1, item, null));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.BinarySearch(0, count + 1, item, null));
        });
    }

    #endregion
}