namespace Deque.Tests;

public partial class Tests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void AsReadOnly(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () => { Assert.Equal(l, d.AsReadOnly()); });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Clear(List<char> l, Deque<char> d)
    {
        Modifies(d, () =>
        {
            d.Clear();
            Assert.Empty(d);
        });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void ToArray(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () => { Assert.Equal(l, d.ToArray()); });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void TrimExcess(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            d.TrimExcess();
            Assert.Equal(NextPowerOfTwo(d.Count), d.Capacity);
        });

        d.EnsureCapacity(2 * d.Capacity);
        Modifies(d, () =>
        {
            d.TrimExcess();
            Assert.Equal(NextPowerOfTwo(d.Count), d.Capacity);
            Assert.Equal(l, d);
        });

        d.Clear();
        Modifies(d, () =>
        {
            d.TrimExcess();
            Assert.Equal(0, d.Capacity);
            Assert.Empty(d);
        });
    }
}