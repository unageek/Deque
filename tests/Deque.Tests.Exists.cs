namespace Deque.Tests;

public partial class Tests
{
    [Fact]
    public void Exists_Empty()
    {
        var d = EmptyDeque();
        DoesNotModify(d, () => { Assert.False(d.Exists(_ => true)); });
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Exists(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            foreach (var item in ItemsToSearch)
                Assert.Equal(l.Exists(c => c == item), d.Exists(c => c == item));
        });
    }

    [Fact]
    public void Exists_NullPredicate_ArgumentNullException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () => { Assert.Throws<ArgumentNullException>(() => d.Exists(null!)); });
    }
}