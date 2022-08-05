namespace Deque.Tests;

public partial class Tests
{
    #region Find

    [Fact]
    public void Find_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.Equal(default, d.Find(_ => true)); });
    }

    [Theory]
    [MemberData(nameof(TestDataWithDuplicates))]
    public void Find(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            Assert.Equal(
                l.Find(Predicate),
                d.Find(Predicate)
            );
        });
    }

    [Fact]
    public void Find_NullPredicate_ArgumentNullException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () => { Assert.Throws<ArgumentNullException>(() => d.Find(null!)); });
    }

    #endregion

    #region FindIndex

    [Fact]
    public void FindIndex_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.Equal(-1, d.FindIndex(_ => true)); });
    }

    [Theory]
    [MemberData(nameof(TestDataWithDuplicates))]
    public void FindIndex(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            Assert.Equal(
                l.FindIndex(Predicate),
                d.FindIndex(Predicate)
            );
        });
    }

    [Fact]
    public void FindIndex_NullPredicate_ArgumentNullException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () => { Assert.Throws<ArgumentNullException>(() => d.FindIndex(null!)); });
    }

    #endregion

    #region FindIndex_int

    [Fact]
    public void FindIndex_int_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.Equal(-1, d.FindIndex(0, _ => true)); });
    }

    [Theory]
    [MemberData(nameof(TestDataWithIndexWithDuplicates))]
    public void FindIndex_int(List<char> l, Deque<char> d, int index)
    {
        DoesNotModify(d, () =>
        {
            Assert.Equal(
                l.FindIndex(index, Predicate),
                d.FindIndex(index, Predicate)
            );
        });
    }

    [Fact]
    public void FindIndex_int_ArgumentOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            Assert.Throws<ArgumentOutOfRangeException>(() => d.FindIndex(-1, Predicate));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.FindIndex(count + 1, Predicate));
        });
    }

    [Fact]
    public void FindIndex_int_NullPredicate_ArgumentNullException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () => { Assert.Throws<ArgumentNullException>(() => d.FindIndex(0, null!)); });
    }

    #endregion

    #region FindIndex_int_int

    [Fact]
    public void FindIndex_int_int_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.Equal(-1, d.FindIndex(0, 0, _ => true)); });
    }

    [Theory]
    [MemberData(nameof(TestDataWithIndexAndCountWithDuplicates))]
    public void FindIndex_int_int(List<char> l, Deque<char> d, int index, int count)
    {
        DoesNotModify(d, () =>
        {
            Assert.Equal(
                l.FindIndex(index, count, Predicate),
                d.FindIndex(index, count, Predicate)
            );
        });
    }

    [Fact]
    public void FindIndex_int_int_ArgumentOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            Assert.Throws<ArgumentOutOfRangeException>(() => d.FindIndex(-1, 0, Predicate));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.FindIndex(0, -1, Predicate));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.FindIndex(count + 1, 0, Predicate));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.FindIndex(count, 1, Predicate));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.FindIndex(0, count + 1, Predicate));
        });
    }

    [Fact]
    public void FindIndex_int_int_NullPredicate_ArgumentNullException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () => { Assert.Throws<ArgumentNullException>(() => d.FindIndex(0, 0, null!)); });
    }

    #endregion

    #region FindLast

    [Fact]
    public void FindLast_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.Equal(default, d.FindLast(_ => true)); });
    }

    [Theory]
    [MemberData(nameof(TestDataWithDuplicates))]
    public void FindLast(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            Assert.Equal(
                l.FindLast(Predicate),
                d.FindLast(Predicate)
            );
        });
    }

    [Fact]
    public void FindLast_NullPredicate_ArgumentNullException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () => { Assert.Throws<ArgumentNullException>(() => d.FindLast(null!)); });
    }

    #endregion

    #region FindLastIndex

    [Fact]
    public void FindLastIndex_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.Equal(-1, d.FindLastIndex(_ => true)); });
    }

    [Theory]
    [MemberData(nameof(TestDataWithDuplicates))]
    public void FindLastIndex(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            Assert.Equal(
                l.FindLastIndex(Predicate),
                d.FindLastIndex(Predicate)
            );
        });
    }

    [Fact]
    public void FindLastIndex_NullPredicate_ArgumentNullException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () => { Assert.Throws<ArgumentNullException>(() => d.FindLastIndex(null!)); });
    }

    #endregion

    #region FindLastIndex_int

    [Fact]
    public void FindLastIndex_int_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.Equal(-1, d.FindLastIndex(0, _ => true)); });
    }

    [Theory]
    [MemberData(nameof(TestDataWithIndexWithDuplicates))]
    public void FindLastIndex_int(List<char> l, Deque<char> d, int index)
    {
        DoesNotModify(d, () =>
        {
            Assert.Equal(
                l.FindLastIndex(index, Predicate),
                d.FindLastIndex(index, Predicate)
            );
        });
    }

    [Fact]
    public void FindLastIndex_int_ArgumentOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            Assert.Throws<ArgumentOutOfRangeException>(() => d.FindLastIndex(-1, Predicate));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.FindLastIndex(count + 1, Predicate));
        });
    }

    [Fact]
    public void FindLastIndex_int_NullPredicate_ArgumentNullException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () => { Assert.Throws<ArgumentNullException>(() => d.FindLastIndex(0, null!)); });
    }

    #endregion

    #region FindLastIndex_int_int

    [Fact]
    public void FindLastIndex_int_int_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.Equal(-1, d.FindLastIndex(0, 0, _ => true)); });
    }

    [Theory]
    [MemberData(nameof(TestDataWithIndexAndCountWithDuplicates))]
    public void FindLastIndex_int_int(List<char> l, Deque<char> d, int index, int count)
    {
        DoesNotModify(d, () =>
        {
            index = index + count - 1;
            Assert.Equal(
                l.FindLastIndex(index, count, Predicate),
                d.FindLastIndex(index, count, Predicate)
            );
        });
    }

    [Fact]
    public void FindLastIndex_int_int_ArgumentOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            Assert.Throws<ArgumentOutOfRangeException>(() => d.FindLastIndex(-1, 0, Predicate));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.FindLastIndex(0, -1, Predicate));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.FindLastIndex(count, 0, Predicate));
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                d.FindLastIndex(count - 1, count + 1, Predicate));
        });
    }

    [Fact]
    public void FindLastIndex_int_int_NullPredicate_ArgumentNullException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () => { Assert.Throws<ArgumentNullException>(() => d.FindLastIndex(0, 0, null!)); });
    }

    #endregion
}