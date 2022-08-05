namespace Deque.Tests;

public partial class Tests
{
    #region Remove

    [Fact]
    public void Remove_Empty()
    {
        var d = EmptyDeque();
        var item = 'x';
        DoesNotModify(d, () => { d.Remove(item); });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Remove(List<char> l, Deque<char> d)
    {
        foreach (var item in ItemsToSearch)
            if (l.Contains(item))
                Modifies(d, () =>
                {
                    l.Remove(item);
                    d.Remove(item);
                    Assert.Equal(l, d);
                });
            else
                DoesNotModify(d, () =>
                {
                    l.Remove(item);
                    d.Remove(item);
                    Assert.Equal(l, d);
                });
    }

    [Theory]
    [MemberData(nameof(TestDataReferenceType))]
    public void Remove_ReferenceType(List<object> l, Deque<object> d)
    {
        foreach (var item in ItemsToSearch)
            if (l.Contains(item))
                Modifies(d, () =>
                {
                    l.Remove(item);
                    d.Remove(item);
                    Assert.Equal(l, d);
                });
            else
                DoesNotModify(d, () =>
                {
                    l.Remove(item);
                    d.Remove(item);
                    Assert.Equal(l, d);
                });
    }

    #endregion

    #region RemoveAll

    [Fact]
    public void RemoveAll_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { d.RemoveAll(_ => true); });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void RemoveAll_AllItems(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            Assert.Equal(l.RemoveAll(_ => true), d.RemoveAll(_ => true));
            Assert.Equal(l, d);
        });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void RemoveAll_NoItems(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            Assert.Equal(l.RemoveAll(_ => false), d.RemoveAll(_ => false));
            Assert.Equal(l, d);
        });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void RemoveAll(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            Assert.Equal(
                l.RemoveAll(Predicate),
                d.RemoveAll(Predicate)
            );
            Assert.Equal(l, d);
        });
    }

    [Theory]
    [MemberData(nameof(TestDataReferenceType))]
    public void RemoveAll_ReferenceType(List<object> l, Deque<object> d)
    {
        Modifies(d, () =>
        {
            Assert.Equal(
                l.RemoveAll(PredicateReferenceType),
                d.RemoveAll(PredicateReferenceType)
            );
            Assert.Equal(l, d);
        });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void RemoveAll_NullPredicate_ArgumentNullException(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () => { Assert.Throws<ArgumentNullException>(() => d.RemoveAll(null!)); });
    }

    #endregion

    #region RemoveAt

    [Theory]
    [MemberData(nameof(TestDataWithIndex))]
    public void RemoveAt(List<char> l, Deque<char> d, int index)
    {
        Modifies(d, () =>
        {
            l.RemoveAt(index);
            d.RemoveAt(index);
            Assert.Equal(l, d);
        });
    }

    [Theory]
    [MemberData(nameof(TestDataWithIndexReferenceType))]
    public void RemoveAt_ReferenceType(List<object> l, Deque<object> d, int index)
    {
        Modifies(d, () =>
        {
            l.RemoveAt(index);
            d.RemoveAt(index);
            Assert.Equal(l, d);
        });
    }

    [Fact]
    public void RemoveAt_ArgumentOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            Assert.Throws<ArgumentOutOfRangeException>(() => d.RemoveAt(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.RemoveAt(count));
        });
    }

    #endregion

    #region RemoveFirst

    [Fact]
    public void RemoveFirst_Empty_InvalidOperationException()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.Throws<InvalidOperationException>(() => d.RemoveFirst()); });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void RemoveFirst(List<char> l, Deque<char> d)
    {
        while (l.Count > 0)
            Modifies(d, () =>
            {
                l.RemoveAt(0);
                d.RemoveFirst();
                Assert.Equal(l, d);
            });
    }

    [Theory]
    [MemberData(nameof(TestDataReferenceType))]
    public void RemoveFirst_ReferenceType(List<object> l, Deque<object> d)
    {
        while (l.Count > 0)
            Modifies(d, () =>
            {
                l.RemoveAt(0);
                d.RemoveFirst();
                Assert.Equal(l, d);
            });
    }

    #endregion

    #region RemoveLast

    [Fact]
    public void RemoveLast_Empty_InvalidOperationException()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.Throws<InvalidOperationException>(() => d.RemoveLast()); });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void RemoveLast(List<char> l, Deque<char> d)
    {
        while (l.Count > 0)
            Modifies(d, () =>
            {
                l.RemoveAt(l.Count - 1);
                d.RemoveLast();
                Assert.Equal(l, d);
            });
    }

    [Theory]
    [MemberData(nameof(TestDataReferenceType))]
    public void RemoveLast_ReferenceType(List<object> l, Deque<object> d)
    {
        while (l.Count > 0)
            Modifies(d, () =>
            {
                l.RemoveAt(l.Count - 1);
                d.RemoveLast();
                Assert.Equal(l, d);
            });
    }

    #endregion

    #region RemoveRange

    [Fact]
    public void RemoveRange_Empty()
    {
        var d = EmptyDeque();
        Modifies(d, () =>
        {
            d.RemoveRange(0, 0);
            Assert.Empty(d);
        });
    }

    [Theory]
    [MemberData(nameof(TestDataWithIndexAndCount))]
    public void RemoveRange(List<char> l, Deque<char> d, int index, int count)
    {
        Modifies(d, () =>
        {
            l.RemoveRange(index, count);
            d.RemoveRange(index, count);
            Assert.Equal(l, d);
        });
    }

    [Theory]
    [MemberData(nameof(TestDataWithIndexAndCountReferenceType))]
    public void RemoveRange_ReferenceType(List<object> l, Deque<object> d, int index, int count)
    {
        Modifies(d, () =>
        {
            l.RemoveRange(index, count);
            d.RemoveRange(index, count);
            Assert.Equal(l, d);
        });
    }

    [Fact]
    public void RemoveRange_ArgumentOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            Assert.Throws<ArgumentOutOfRangeException>(() => d.RemoveRange(-1, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.RemoveRange(0, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.RemoveRange(count + 1, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.RemoveRange(count, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => d.RemoveRange(0, count + 1));
        });
    }

    #endregion

    #region IList_Remove

    [Fact]
    public void IList_Remove_Empty()
    {
        var d = EmptyDeque();
        var item = 'x';
        DoesNotModify(d, () => { ((IList)d).Remove(item); });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void IList_Remove(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            foreach (var item in ItemsToSearch)
            {
                ((IList)l).Remove(item);
                ((IList)d).Remove(item);
                Assert.Equal(l, d);
            }
        });
    }

    [Fact]
    public void IList_Remove_IncompatibleObject()
    {
        var d = SampleDeque();
        var item = 'x';
        DoesNotModify(d, () => { ((IList)d).Remove(item); });
    }

    #endregion
}