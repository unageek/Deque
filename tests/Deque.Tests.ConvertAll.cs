using Xunit.Sdk;

namespace Deque.Tests;

public partial class Tests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void ConvertAll(List<char> l, Deque<char> d)
    {
        DoesNotModify(d, () => { Assert.Equal(l.ConvertAll(x => x + 1), d.ConvertAll(x => x + 1)); });
    }

    [Fact]
    public void ConvertAll_NullConverter_ArgumentNullException()
    {
        var d = SampleDeque();
        DoesNotModify(d, () => { Assert.Throws<ArgumentNullException>(() => d.ConvertAll<int>(null!)); });
    }
}