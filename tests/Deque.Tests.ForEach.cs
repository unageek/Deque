namespace Deque.Tests;

public partial class Tests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void ForEach(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () =>
        {
            var lVisited = new List<char>();
            var dVisited = new List<char>();

            l.ForEach(x => lVisited.Add(x));
            d.ForEach(x => dVisited.Add(x));
            Assert.Equal(lVisited, dVisited);
        });
    }

    [Fact]
    public void ForEach_NullAction_ArgumentNullException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () => { Assert.Throws<ArgumentNullException>(() => d.ForEach(null!)); });
    }

    [Fact]
    public void ForEach_Modify_InvalidOperationException()
    {
        var d = SampleDeque();
        var item = 'x';
        Assert.Throws<InvalidOperationException>(() => d.ForEach(_ => d.Add(item)));
        Assert.Equal(new[] { 'a', 'b', 'c', 'x' }, d);
    }
}