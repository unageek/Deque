namespace Deque.Tests;

public partial class Tests
{
    #region IndexOf

    [Fact]
    public void IndexOf_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () =>
        {
            var item = 'x';
            Assert.Equal(-1, d.IndexOf(item));
        });
    }

    [Theory]
    [MemberData(nameof(TestDataWithDuplicates))]
    public void IndexOf(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            foreach (var item in ItemsToSearch)
                Assert.Equal(l.IndexOf(item), d.IndexOf(item));
        });
    }

    #endregion

    #region IndexOf_int

    [Fact]
    public void IndexOf_int_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () =>
        {
            var item = 'x';
            Assert.Equal(-1, d.IndexOf(item, 0));
        });
    }

    [Theory]
    [MemberData(nameof(TestDataWithIndexWithDuplicates))]
    public void IndexOf_int(List<char> l, Deque<char> d, int index)
    {
        DoesNotModify(d, () =>
        {
            foreach (var item in ItemsToSearch)
                Assert.Equal(l.IndexOf(item, index), d.IndexOf(item, index));
        });
    }

    [Fact]
    public void IndexOf_int_ArgumentOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            var item = 'x';
            Assert.Throws<ArgumentOutOfRangeException>(() => d.IndexOf(item, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.IndexOf(item, count + 1));
        });
    }

    #endregion

    #region IndexOf_int_int

    [Fact]
    public void IndexOf_int_int_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () =>
        {
            var item = 'x';
            Assert.Equal(-1, d.IndexOf(item, 0, 0));
        });
    }

    [Theory]
    [MemberData(nameof(TestDataWithIndexAndCountWithDuplicates))]
    public void IndexOf_int_int(List<char> l, Deque<char> d, int index, int count)
    {
        DoesNotModify(d, () =>
        {
            foreach (var item in ItemsToSearch)
                Assert.Equal(l.IndexOf(item, index, count), d.IndexOf(item, index, count));
        });
    }

    [Fact]
    public void IndexOf_int_int_ArgumentOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            var item = 'x';
            Assert.Throws<ArgumentOutOfRangeException>(() => d.IndexOf(item, -1, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.IndexOf(item, 0, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.IndexOf(item, count + 1, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.IndexOf(item, count, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.IndexOf(item, 0, count + 1));
        });
    }

    #endregion

    #region LastIndexOf

    [Fact]
    public void LastIndexOf_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () =>
        {
            var item = 'x';
            Assert.Equal(-1, d.LastIndexOf(item));
        });
    }

    [Theory]
    [MemberData(nameof(TestDataWithDuplicates))]
    public void LastIndexOf(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            foreach (var item in ItemsToSearch)
                Assert.Equal(l.LastIndexOf(item), d.LastIndexOf(item));
        });
    }

    #endregion

    #region LastIndexOf_int

    [Fact]
    public void LastIndexOf_int_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () =>
        {
            var item = 'x';
            Assert.Equal(-1, d.LastIndexOf(item, 0));
        });
    }

    [Theory]
    [MemberData(nameof(TestDataWithIndexWithDuplicates))]
    public void LastIndexOf_int(List<char> l, Deque<char> d, int index)
    {
        DoesNotModify(d, () =>
        {
            foreach (var item in ItemsToSearch)
                Assert.Equal(l.LastIndexOf(item, index), d.LastIndexOf(item, index));
        });
    }

    [Fact]
    public void LastIndexOf_int_ArgumentOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            var item = 'x';
            Assert.Throws<ArgumentOutOfRangeException>(() => d.LastIndexOf(item, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.LastIndexOf(item, count));
        });
    }

    #endregion

    #region LastIndexOf_int_int

    [Fact]
    public void LastIndexOf_int_int_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () =>
        {
            var item = 'x';
            Assert.Equal(-1, d.LastIndexOf(item, 0, 0));
        });
    }

    [Theory]
    [MemberData(nameof(TestDataWithIndexAndCountWithDuplicates))]
    public void LastIndexOf_int_int(List<char> l, Deque<char> d, int index, int count)
    {
        DoesNotModify(d, () =>
        {
            index = index + count - 1;
            foreach (var item in ItemsToSearch)
                Assert.Equal(l.LastIndexOf(item, index, count), d.LastIndexOf(item, index, count));
        });
    }

    [Fact]
    public void LastIndexOf_int_int_ArgumentOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            var item = 'x';
            Assert.Throws<ArgumentOutOfRangeException>(() => d.LastIndexOf(item, -1, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.LastIndexOf(item, 0, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.LastIndexOf(item, count, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.LastIndexOf(item, count - 1, count + 1));
        });
    }

    #endregion

    #region IList_IndexOf

    [Fact]
    public void IList_IndexOf_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () =>
        {
            var item = 'x';
            Assert.Equal(-1, ((IList)d).IndexOf(item));
        });
    }

    [Theory]
    [MemberData(nameof(TestDataWithDuplicates))]
    public void IList_IndexOf(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            foreach (var item in ItemsToSearch)
                Assert.Equal(((IList)l).IndexOf(item), ((IList)d).IndexOf(item));
        });
    }

    [Fact]
    public void IList_IndexOf_IncompatibleObject()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var item = 'x';
            Assert.Equal(-1, ((IList)d).IndexOf(item));
        });
    }

    #endregion
}