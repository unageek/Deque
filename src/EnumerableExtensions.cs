namespace Unageek.Collections;

public static class EnumerableExtensions
{
    public static Deque<TSource> ToDeque<TSource>(this IEnumerable<TSource> source)
    {
        return new Deque<TSource>(source);
    }
}