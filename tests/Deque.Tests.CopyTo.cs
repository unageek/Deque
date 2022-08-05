namespace Deque.Tests;

public partial class Tests
{
    #region CopyTo

    [Fact]
    public void CopyTo_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () =>
        {
            var a = Array.Empty<char>();
            d.CopyTo(a);
            Assert.Empty(a);
        });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void CopyTo(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            var la = new char[l.Count];
            l.CopyTo(la);

            var da = new char[d.Count];
            d.CopyTo(da);

            Assert.Equal(la, da);
        });
    }

    [Fact]
    public void CopyTo_NullArray_ArgumentNullException()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.Throws<ArgumentNullException>(() => d.CopyTo(null!)); });
    }

    [Fact]
    public void CopyTo_ShorterArray_ArgumentOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var a = new char[2];
            Assert.Throws<ArgumentOutOfRangeException>(() => d.CopyTo(a));
        });
    }

    #endregion

    #region CopyTo_int

    [Fact]
    public void CopyTo_int_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () =>
        {
            var a = Array.Empty<char>();
            d.CopyTo(a, 0);
            Assert.Empty(a);
        });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void CopyTo_int(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            var la = new char[l.Count + 3];
            l.CopyTo(la, 3);

            var da = new char[d.Count + 3];
            d.CopyTo(da, 3);

            Assert.Equal(la, da);
        });
    }

    [Fact]
    public void CopyTo_int_NullArray_ArgumentNullException()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.Throws<ArgumentNullException>(() => d.CopyTo(null!, 0)); });
    }

    [Fact]
    public void CopyTo_int_ArgumentOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            foreach (var aLen in new[] { 2, 3, 5 })
            {
                var a = new char[aLen];
                Assert.Throws<ArgumentOutOfRangeException>(() => d.CopyTo(a, -1));
                Assert.Throws<ArgumentOutOfRangeException>(() => d.CopyTo(a, Math.Max(aLen - count + 1, 0)));
            }
        });
    }

    #endregion

    #region CopyTo_int_int

    [Fact]
    public void CopyTo_int_int_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () =>
        {
            var a = Array.Empty<char>();
            d.CopyTo(0, a, 0, 0);
            Assert.Empty(a);
        });
    }

    [Theory]
    [MemberData(nameof(TestDataWithIndexAndCount))]
    public void CopyTo_int_int(List<char> l, Deque<char> d, int index, int count)
    {
        DoesNotModify(d, () =>
        {
            var la = new char[l.Count + 3];
            l.CopyTo(index, la, 3, count);

            var da = new char[d.Count + 3];
            d.CopyTo(index, da, 3, count);

            Assert.Equal(la, da);
        });
    }

    [Fact]
    public void CopyTo_int_int_NullArray_ArgumentNullException()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.Throws<ArgumentNullException>(() => d.CopyTo(0, null!, 0, 0)); });
    }

    [Fact]
    public void CopyTo_int_int_ArgumentOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            foreach (var aLen in new[] { 2, 3, 5 })
            {
                var a = new char[aLen];
                Assert.Throws<ArgumentOutOfRangeException>(() => d.CopyTo(-1, a, 0, 0));
                Assert.Throws<ArgumentOutOfRangeException>(() => d.CopyTo(0, a, -1, 0));
                Assert.Throws<ArgumentOutOfRangeException>(() => d.CopyTo(0, a, 0, -1));
                Assert.Throws<ArgumentOutOfRangeException>(() => d.CopyTo(count + 1, a, 0, 0));
                Assert.Throws<ArgumentOutOfRangeException>(() => d.CopyTo(count, a, 0, 1));
                Assert.Throws<ArgumentOutOfRangeException>(() => d.CopyTo(0, a, 0, count + 1));
                Assert.Throws<ArgumentOutOfRangeException>(() => d.CopyTo(0, a, aLen + 1, 0));
                Assert.Throws<ArgumentOutOfRangeException>(() => d.CopyTo(0, a, aLen, 1));
                Assert.Throws<ArgumentOutOfRangeException>(() => d.CopyTo(0, a, 0, aLen + 1));
            }
        });
    }

    #endregion

    #region ICollection_CopyTo

    [Fact]
    public void ICollection_CopyTo_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () =>
        {
            var a = Array.Empty<int>();
            ((ICollection)d).CopyTo(a, 0);
            Assert.Empty(a);
        });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void ICollection_CopyTo(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            var la = new char[l.Count + 3];
            ((ICollection)l).CopyTo(la, 3);

            var da = new char[d.Count + 3];
            ((ICollection)d).CopyTo(da, 3);

            Assert.Equal(la, da);
        });
    }

    [Fact]
    public void ICollection_CopyTo_NullArray_ArgumentNullException()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.Throws<ArgumentNullException>(() => ((ICollection)d).CopyTo(null!, 0)); });
    }

    [Fact]
    public void ICollection_CopyTo_ArgumentOutOfRangeException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var count = d.Count;
            foreach (var aLen in new[] { 2, 3, 5 })
            {
                var a = new char[aLen];
                Assert.Throws<ArgumentOutOfRangeException>(() => ((ICollection)d).CopyTo(a, -1));
                Assert.Throws<ArgumentOutOfRangeException>(() => ((ICollection)d).CopyTo(a, Math.Max(aLen - count + 1, 0)));
            }
        });
    }

    [Fact]
    public void ICollection_CopyTo_ArrayWithNonZeroLowerBound_ArgumentException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var a = Array.CreateInstance(typeof(char), new[] { d.Count }, new[] { 1 });
            Assert.Throws<ArgumentException>(() => ((ICollection)d).CopyTo(a, 0));
        });
    }

    [Fact]
    public void ICollection_CopyTo_WrongArrayRank_ArgumentException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var a = new char[3, 3];
            Assert.Throws<ArgumentException>(() => ((ICollection)d).CopyTo(a, 0));
        });
    }

    [Fact]
    public void ICollection_CopyTo_WrongArrayType_ArgumentException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () =>
        {
            var a = new string[3];
            Assert.Throws<ArgumentException>(() => ((ICollection)d).CopyTo(a, 0));
        });
    }

    #endregion
}