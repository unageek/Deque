namespace Deque.Tests;

public partial class Tests
{
    #region Insert

    [Theory]
    [MemberData(nameof(TestDataWithInsertionIndex))]
    public void Insert(List<char> l, Deque<char> d, int index)
    {
        Modifies(d, () =>
        {
            l.Insert(index, 'x');
            d.Insert(index, 'x');
            Assert.Equal(l, d);
        });
    }

    [Fact]
    public void Insert_ArgumentOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            var item = 'x';
            Assert.Throws<ArgumentOutOfRangeException>(() => d.Insert(-1, item));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.Insert(count + 1, item));
        });
    }

    #endregion

    #region InsertRange

    [Theory]
    [MemberData(nameof(TestDataWithInsertionIndex))]
    public void InsertRange1(List<char> l, Deque<char> d, int index)
    {
        Modifies(d, () =>
        {
            var items = new[] { 'x' };
            l.InsertRange(index, items);
            d.InsertRange(index, items);
            Assert.Equal(l, d);
        });
    }

    [Theory]
    [MemberData(nameof(TestDataWithInsertionIndex))]
    public void InsertRange2(List<char> l, Deque<char> d, int index)
    {
        Modifies(d, () =>
        {
            var items = new[] { 'x', 'y' };
            l.InsertRange(index, items);
            d.InsertRange(index, items);
            Assert.Equal(l, d);
        });
    }

    [Theory]
    [MemberData(nameof(TestDataWithInsertionIndex))]
    public void InsertRange3(List<char> l, Deque<char> d, int index)
    {
        Modifies(d, () =>
        {
            var items = new[] { 'x', 'y', 'z' };
            l.InsertRange(index, items);
            d.InsertRange(index, items);
            Assert.Equal(l, d);
        });
    }

    [Theory]
    [MemberData(nameof(TestDataWithInsertionIndex))]
    public void InsertRange4(List<char> l, Deque<char> d, int index)
    {
        Modifies(d, () =>
        {
            var items = new[] { 'x', 'y', 'z', 'w' };
            l.InsertRange(index, items);
            d.InsertRange(index, items);
            Assert.Equal(l, d);
        });
    }

    [Fact]
    public void InsertRange_ArgumentOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            var items = new[] { 'x' };
            Assert.Throws<ArgumentOutOfRangeException>(() => d.InsertRange(-1, items));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.InsertRange(count + 1, items));
        });
    }

    [Fact]
    public void InsertRange_NullEnumerable_ArgumentNullException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () => { Assert.Throws<ArgumentNullException>(() => d.InsertRange(0, null!)); });
    }

    [Theory]
    [MemberData(nameof(TestDataWithInsertionIndex))]
    public void InsertRange_Self(List<char> l, Deque<char> d, int index)
    {
        Modifies(d, () =>
        {
            l.InsertRange(index, l);
            d.InsertRange(index, d);
            Assert.Equal(l, d);
        });
    }

    [Fact]
    public void InsertRange_SelfAsIEnumerable_InvalidOperationException()
    {
        var d = SampleDeque();
        Assert.Throws<InvalidOperationException>(() => d.InsertRange(0, d.Select(x => x)));
        Assert.Equal(new[] { 'a', 'a', 'b', 'c' }, d);
    }

    [Theory]
    [MemberData(nameof(TestDataWithInsertionIndex))]
    public void InsertRange_List(List<char> l, Deque<char> d, int index)
    {
        Modifies(d, () =>
        {
            var items = new List<char> { 'x', 'y' };
            l.InsertRange(index, items);
            d.InsertRange(index, items);
            Assert.Equal(l, d);
        });
    }

    [Theory]
    [MemberData(nameof(TestDataWithInsertionIndex))]
    public void InsertRange_Deque(List<char> l, Deque<char> d, int index)
    {
        Modifies(d, () =>
        {
            var items = new Deque<char> { 'x', 'y' };
            l.InsertRange(index, items);
            d.InsertRange(index, items);
            Assert.Equal(l, d);
        });
    }

    [Theory]
    [MemberData(nameof(TestDataWithInsertionIndex))]
    public void InsertRange_Collection(List<char> l, Deque<char> d, int index)
    {
        Modifies(d, () =>
        {
            var items = new HashSet<char> { 'x', 'y' };
            l.InsertRange(index, items);
            d.InsertRange(index, items);
            Assert.Equal(l, d);
        });
    }

    [Theory]
    [MemberData(nameof(TestDataWithInsertionIndex))]
    public void InsertRange_IEnumerable(List<char> l, Deque<char> d, int index)
    {
        Modifies(d, () =>
        {
            var items = new[] { 'x', 'y' };
            l.InsertRange(index, items.Select(x => x));
            d.InsertRange(index, items.Select(x => x));
            Assert.Equal(l, d);
        });
    }

    #endregion

    #region IList_Insert

    [Theory]
    [MemberData(nameof(TestDataWithInsertionIndex))]
    public void IList_Insert(List<char> l, Deque<char> d, int index)
    {
        Modifies(d, () =>
        {
            ((IList)l).Insert(index, 'x');
            ((IList)d).Insert(index, 'x');
            Assert.Equal(l, d);
        });
    }

    [Fact]
    public void IList_Insert_ArgumentException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            Assert.Throws<ArgumentNullException>(() => ((IList)d).Insert(0, null));
            Assert.Throws<ArgumentException>(() => ((IList)d).Insert(0, "x"));
        });
    }

    #endregion
}