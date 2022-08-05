namespace Deque.Tests;

public partial class Tests
{
    #region Indexer

    [Theory]
    [MemberData(nameof(TestDataWithIndex))]
    public void Indexer_Get(List<char> l, Deque<char> d, int index)
    {
        DoesNotModify(d, () => { Assert.Equal(l[index], d[index]); });
    }

    [Fact]
    public void Indexer_Get_IndexOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            Assert.Throws<IndexOutOfRangeException>(() => d[-1]);
            Assert.Throws<IndexOutOfRangeException>(() => d[count]);
        });
    }

    [Fact]
    public void Indexer_Set()
    {
        var d = SampleDeque();
        Modifies(d, () =>
        {
            var item = 'x';
            d[1] = item;
            Assert.Equal(item, d[1]);
        });
    }

    [Fact]
    public void Indexer_Set_IndexOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            var item = 'x';
            Assert.Throws<IndexOutOfRangeException>(() => d[-1] = item);
            Assert.Throws<IndexOutOfRangeException>(() => d[count] = item);
            Assert.Equal(new[] { 'a', 'b', 'c' }, d);
        });
    }

    #endregion

    #region IList_Indexer

    [Theory]
    [MemberData(nameof(TestDataWithIndex))]
    public void IList_Indexer_Get(List<char> l, Deque<char> d, int index)
    {
        DoesNotModify(d, () => { Assert.Equal(((IList)l)[index], ((IList)d)[index]); });
    }

    [Fact]
    public void IList_Indexer_Get_IndexOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            Assert.Throws<IndexOutOfRangeException>(() => ((IList)d)[-1]);
            Assert.Throws<IndexOutOfRangeException>(() => ((IList)d)[count]);
        });
    }

    [Fact]
    public void IList_Indexer_Set()
    {
        var d = SampleDeque();
        Modifies(d, () =>
        {
            var item = 'x';
            ((IList)d)[1] = item;
            Assert.Equal(item, d[1]);
        });
    }

    [Fact]
    public void IList_Indexer_Set_IndexOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            var item = 'x';
            Assert.Throws<IndexOutOfRangeException>(() => ((IList)d)[-1] = item);
            Assert.Throws<IndexOutOfRangeException>(() => ((IList)d)[count] = item);
            Assert.Equal(new[] { 'a', 'b', 'c' }, d);
        });
    }

    [Fact]
    public void IList_Indexer_Set_ArgumentException()
    {
        var d = SampleDeque();

        DoesNotModify(d, () =>
        {
            Assert.Throws<ArgumentNullException>(() => ((IList)d)[1] = null);
            Assert.Throws<ArgumentException>(() => ((IList)d)[1] = "x");
        });
    }

    #endregion
}