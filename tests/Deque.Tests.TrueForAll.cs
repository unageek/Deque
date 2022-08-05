namespace Deque.Tests;

public partial class Tests
{
    [Fact]
    public void TrueForAll_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.True(d.TrueForAll(_ => true)); });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void TrueForAll(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            Assert.Equal(
                l.TrueForAll(c => c <= 'h'),
                d.TrueForAll(c => c <= 'h')
            );
        });
    }

    [Fact]
    public void TrueForAll_NullPredicate_ArgumentNullException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () => { Assert.Throws<ArgumentNullException>(() => d.TrueForAll(null!)); });
    }
}