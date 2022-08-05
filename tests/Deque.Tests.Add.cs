namespace Deque.Tests;

public partial class Tests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Add(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            var item = 'x';
            l.Add(item);
            d.Add(item);
            Assert.Equal(l, d);
        });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void AddFirst(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            var item = 'x';
            l.Insert(0, item);
            d.AddFirst(item);
            Assert.Equal(l, d);
        });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void AddLast(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            var item = 'x';
            l.Add(item);
            d.AddLast(item);
            Assert.Equal(l, d);
        });
    }

    #region AddRange

    [Theory]
    [MemberData(nameof(TestData))]
    public void AddRange(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            var items = new[] { 'x', 'y' };
            l.AddRange(items);
            d.AddRange(items);
            Assert.Equal(l, d);
        });
    }

    [Fact]
    public void AddRange_NullEnumerable_ArgumentNullException()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.Throws<ArgumentNullException>(() => d.AddRange(null!)); });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void AddRange_Self(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            l.AddRange(l);
            d.AddRange(d);
            Assert.Equal(l, d);
        });
    }

    [Fact]
    public void AddRange_SelfAsIEnumerable_InvalidOperationException()
    {
        var d = SampleDeque();
        Assert.Throws<InvalidOperationException>(() => d.AddRange(d.Select(x => x)));
        Assert.Equal(new[] { 'a', 'b', 'c', 'a' }, d);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void AddRange_List(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            var items = new List<char> { 'x', 'y' };
            l.AddRange(items);
            d.AddRange(items);
            Assert.Equal(l, d);
        });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void AddRange_Deque(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            var items = new Deque<char> { 'x', 'y' };
            l.AddRange(items);
            d.AddRange(items);
            Assert.Equal(l, d);
        });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void AddRange_ICollection(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            var items = new HashSet<char> { 'x', 'y' };
            l.AddRange(items);
            d.AddRange(items);
            Assert.Equal(l, d);
        });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void AddRange_IEnumerable(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            var items = new[] { 'x', 'y' };
            l.AddRange(items.Select(x => x));
            d.AddRange(items.Select(x => x));
            Assert.Equal(l, d);
        });
    }

    #endregion

    #region IList_Add

    [Theory]
    [MemberData(nameof(TestData))]
    public void IList_Add(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            var item = 'x';
            Assert.Equal(((IList)l).Add(item), ((IList)d).Add(item));
            Assert.Equal(l, d);
        });
    }

    [Fact]
    public void IList_Add_ArgumentException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            Assert.Throws<ArgumentNullException>(() => ((IList)d).Add(null));
            Assert.Throws<ArgumentException>(() => ((IList)d).Add("x"));
        });
    }

    #endregion
}