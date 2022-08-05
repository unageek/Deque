namespace Deque.Tests;

public partial class Tests
{
    #region Sort

    [Fact]
    public void Sort_Empty()
    {
        var d = EmptyDeque();
        Modifies(d, () =>
        {
            d.Sort();
            Assert.Empty(d);
        });
    }

    [Theory]
    [MemberData(nameof(TestDataShuffled))]
    public void Sort(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            l.Sort();
            d.Sort();
            Assert.Equal(l, d);
        });
    }

    #endregion

    #region Sort_IComparer

    [Fact]
    public void Sort_IComparer_Empty()
    {
        var d = EmptyDeque();
        Modifies(d, () =>
        {
            d.Sort((IComparer<char>?)null);
            Assert.Empty(d);
        });
    }

    [Theory]
    [MemberData(nameof(TestDataShuffled))]
    public void Sort_IComparer(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            var greater = new Greater();
            l.Sort(greater);
            d.Sort(greater);
            Assert.Equal(l, d);
        });
    }

    [Theory]
    [MemberData(nameof(TestDataShuffled))]
    public void Sort_IComparer_NullComparer(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            l.Sort((IComparer<char>?)null);
            d.Sort((IComparer<char>?)null);
            Assert.Equal(l, d);
        });
    }

    #endregion

    #region Sort_int_int_IComparer

    [Fact]
    public void Sort_int_int_IComparer_Empty()
    {
        var d = EmptyDeque();
        Modifies(d, () =>
        {
            d.Sort(0, 0, null);
            Assert.Empty(d);
        });
    }

    [Theory]
    [MemberData(nameof(TestDataWithIndexAndCountShuffled))]
    public void Sort_int_int_IComparer(List<char> l, Deque<char> d, int index, int count)
    {
        Modifies(d, () =>
        {
            var greater = new Greater();
            l.Sort(index, count, greater);
            d.Sort(index, count, greater);
            Assert.Equal(l, d);
        });
    }

    [Theory]
    [MemberData(nameof(TestDataWithIndexAndCountShuffled))]
    public void Sort_int_int_IComparer_NullComparer(List<char> l, Deque<char> d, int index, int count)
    {
        Modifies(d, () =>
        {
            l.Sort(index, count, null);
            d.Sort(index, count, null);
            Assert.Equal(l, d);
        });
    }

    [Fact]
    public void Sort_int_int_IComparer_ArgumentOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            Assert.Throws<ArgumentOutOfRangeException>(() => d.Sort(-1, 0, null));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.Sort(0, -1, null));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.Sort(count + 1, 0, null));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.Sort(count, 1, null));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.Sort(0, count + 1, null));
        });
    }

    #endregion

    #region Sort_Comparison

    [Theory]
    [MemberData(nameof(TestDataShuffled))]
    public void Sort_Comparison(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            l.Sort((x, y) => y - x);
            d.Sort((x, y) => y - x);
            Assert.Equal(l, d);
        });
    }

    [Fact]
    public void Sort_Comparison_NullComparison_ArgumentNullException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () => { Assert.Throws<ArgumentNullException>(() => d.Sort((Comparison<char>)null!)); });
    }

    #endregion
}