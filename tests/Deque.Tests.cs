namespace Deque.Tests;

public partial class Tests
{
    private const int MaxCapacity = 1073741824; // 2^30

    private static readonly char[] ItemsToSearch =
    {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q'
    };

    private static readonly char[][] TestArrays =
    {
        new[] { 'b' },
        new[] { 'b', 'd' },
        new[] { 'b', 'd', 'f' },
        new[] { 'b', 'd', 'f', 'h' },
        new[] { 'b', 'd', 'f', 'h', 'j' },
        new[] { 'b', 'd', 'f', 'h', 'j', 'l' },
        new[] { 'b', 'd', 'f', 'h', 'j', 'l', 'n' },
        new[] { 'b', 'd', 'f', 'h', 'j', 'l', 'n', 'p' }
    };

    private static readonly object[][] TestArraysReferenceType =
    {
        new object[] { 'b' },
        new object[] { 'b', 'd' },
        new object[] { 'b', 'd', 'f' },
        new object[] { 'b', 'd', 'f', 'h' },
        new object[] { 'b', 'd', 'f', 'h', 'j' },
        new object[] { 'b', 'd', 'f', 'h', 'j', 'l' },
        new object[] { 'b', 'd', 'f', 'h', 'j', 'l', 'n' },
        new object[] { 'b', 'd', 'f', 'h', 'j', 'l', 'n', 'p' }
    };

    private static readonly char[][] TestArraysWithDuplicates =
    {
        new[] { 'b', 'b' },
        new[] { 'b', 'd', 'b' },
        new[] { 'b', 'd', 'd', 'b' },
        new[] { 'b', 'd', 'f', 'd', 'b' },
        new[] { 'b', 'd', 'f', 'f', 'd', 'b' },
        new[] { 'b', 'd', 'f', 'h', 'f', 'd', 'b' },
    };

    private static Deque<char> EmptyDeque()
    {
        return new Deque<char>();
    }

    private static Deque<char> SampleDeque()
    {
        return new Deque<char> { 'a', 'b', 'c' };
    }

    private static Deque<T> MakeDeque<T>(T[] a, int offset)
    {
        var d = new Deque<T>(a.Length);

        if (offset >= 0)
            for (var i = 0; i < offset; i++)
            {
                d.AddLast(default!);
                d.RemoveFirst();
            }
        else
            for (var i = 0; i < -offset; i++)
            {
                d.AddFirst(default!);
                d.RemoveLast();
            }

        foreach (var item in a)
            d.AddLast(item);

        return d;
    }

    private static IEnumerable<int> Offsets(int capacity)
    {
        if (capacity == 1)
            yield return 0;
        else
            for (var offset = -capacity / 2; offset < capacity / 2; offset++)
                yield return offset;
    }

    private static IEnumerable<object[]> TestData()
    {
        foreach (var a in TestArrays)
        {
            var capacity = NextPowerOfTwo(a.Length);
            foreach (var offset in Offsets(capacity))
                yield return new object[] { a.ToList(), MakeDeque(a, offset) };
        }
    }

    private static IEnumerable<object[]> TestDataWithIndex()
    {
        foreach (var a in TestArrays)
        {
            var capacity = NextPowerOfTwo(a.Length);
            foreach (var offset in Offsets(capacity))
                for (var index = 0; index < a.Length; index++)
                    yield return new object[] { a.ToList(), MakeDeque(a, offset), index };
        }
    }

    private static IEnumerable<object[]> TestDataWithIndexAndCount()
    {
        foreach (var a in TestArrays)
        {
            var capacity = NextPowerOfTwo(a.Length);
            foreach (var offset in Offsets(capacity))
                for (var index = 0; index < a.Length; index++)
                    for (var count = 1; index + count <= a.Length; count++)
                        yield return new object[] { a.ToList(), MakeDeque(a, offset), index, count };
        }
    }

    // For insertion.

    private static IEnumerable<object[]> TestDataWithInsertionIndex()
    {
        foreach (var a in TestArrays)
        {
            var capacity = NextPowerOfTwo(a.Length);
            foreach (var offset in Offsets(capacity))
                for (var index = 0; index <= a.Length; index++)
                    yield return new object[] { a.ToList(), MakeDeque(a, offset), index };
        }
    }

    // For removal.

    private static IEnumerable<object[]> TestDataReferenceType()
    {
        foreach (var a in TestArraysReferenceType)
        {
            var capacity = NextPowerOfTwo(a.Length);
            foreach (var offset in Offsets(capacity))
                yield return new object[] { a.ToList(), MakeDeque(a, offset) };
        }
    }

    private static IEnumerable<object[]> TestDataWithIndexReferenceType()
    {
        foreach (var a in TestArraysReferenceType)
        {
            var capacity = NextPowerOfTwo(a.Length);
            foreach (var offset in Offsets(capacity))
                for (var index = 0; index < a.Length; index++)
                    yield return new object[] { a.ToList(), MakeDeque(a, offset), index };
        }
    }

    private static IEnumerable<object[]> TestDataWithIndexAndCountReferenceType()
    {
        foreach (var a in TestArraysReferenceType)
        {
            var capacity = NextPowerOfTwo(a.Length);
            foreach (var offset in Offsets(capacity))
                for (var index = 0; index < a.Length; index++)
                    for (var count = 1; index + count <= a.Length; count++)
                        yield return new object[] { a.ToList(), MakeDeque(a, offset), index, count };
        }
    }

    // For sorting.

    private static IEnumerable<object[]> TestDataShuffled()
    {
        foreach (var a in TestArrays)
        {
            var a2 = a.ToArray();
            a2.Shuffle();
            var capacity = NextPowerOfTwo(a2.Length);
            foreach (var offset in Offsets(capacity))
                yield return new object[] { a2.ToList(), MakeDeque(a2, offset) };
        }
    }

    private static IEnumerable<object[]> TestDataWithIndexAndCountShuffled()
    {
        foreach (var a in TestArrays)
        {
            var a2 = a.ToArray();
            a2.Shuffle();
            var capacity = NextPowerOfTwo(a2.Length);
            foreach (var offset in Offsets(capacity))
                for (var index = 0; index < a2.Length; index++)
                    for (var count = 1; index + count <= a2.Length; count++)
                        yield return new object[] { a2.ToList(), MakeDeque(a2, offset), index, count };
        }
    }

    // For binary search

    private static IEnumerable<object[]> TestDataReversed()
    {
        foreach (var a in TestArrays)
        {
            var a2 = a.ToArray();
            Array.Reverse(a2);
            var capacity = NextPowerOfTwo(a2.Length);
            foreach (var offset in Offsets(capacity))
                yield return new object[] { a2.ToList(), MakeDeque(a2, offset) };
        }
    }

    private static IEnumerable<object[]> TestDataWithIndexAndCountReversed()
    {
        foreach (var a in TestArrays)
        {
            var a2 = a.ToArray();
            Array.Reverse(a2);
            var capacity = NextPowerOfTwo(a2.Length);
            foreach (var offset in Offsets(capacity))
                for (var index = 0; index < a2.Length; index++)
                    for (var count = 1; index + count <= a2.Length; count++)
                        yield return new object[] { a2.ToList(), MakeDeque(a2, offset), index, count };
        }
    }

    // For linear search.

    private static IEnumerable<object[]> TestDataWithDuplicates()
    {
        foreach (var a in TestArraysWithDuplicates)
        {
            var capacity = NextPowerOfTwo(a.Length);
            foreach (var offset in Offsets(capacity))
                yield return new object[] { a.ToList(), MakeDeque(a, offset) };
        }
    }

    private static IEnumerable<object[]> TestDataWithIndexWithDuplicates()
    {
        foreach (var a in TestArraysWithDuplicates)
        {
            var capacity = NextPowerOfTwo(a.Length);
            foreach (var offset in Offsets(capacity))
                for (var index = 0; index < a.Length; index++)
                    yield return new object[] { a.ToList(), MakeDeque(a, offset), index };
        }
    }

    private static IEnumerable<object[]> TestDataWithIndexAndCountWithDuplicates()
    {
        foreach (var a in TestArraysWithDuplicates)
        {
            var capacity = NextPowerOfTwo(a.Length);
            foreach (var offset in Offsets(capacity))
                for (var index = 0; index < a.Length; index++)
                    for (var count = 1; index + count <= a.Length; count++)
                        yield return new object[] { a.ToList(), MakeDeque(a, offset), index, count };
        }
    }

    private static bool Predicate(char c)
    {
        return c is 'b' or 'f' or 'j' or 'n';
    }

    private static bool PredicateReferenceType(object c)
    {
        return c is 'b' or 'f' or 'j' or 'n';
    }

    private static void Modifies<T>(Deque<T> d, Action action)
    {
        var e = d.GetEnumerator();
        action();
        Assert.Throws<InvalidOperationException>(() => e.MoveNext());
    }

    private static void DoesNotModify<T>(Deque<T> d, Action action)
    {
        var a = d.ToArray();
        var e = d.GetEnumerator();
        action();
        Assert.Equal(a, d);
        e.MoveNext();
    }

    private static int NextPowerOfTwo(int x)
    {
        return x switch
        {
            <= 1 => 1,
            <= 2 => 2,
            <= 4 => 4,
            <= 8 => 8,
            <= 16 => 16,
            <= 32 => 32,
            <= 64 => 64,
            <= 128 => 128,
            _ => throw new NotImplementedException()
        };
    }

    private class Greater : IComparer<char>
    {
        public int Compare(char x, char y)
        {
            return y - x;
        }
    }
}

internal static class ArrayExtensions
{
    // Performs Fisher-Yates shuffle.
    public static void Shuffle<T>(this T[] array)
    {
        var random = new Random();
        for (var i = array.Length - 1; i > 0; i--)
        {
            var j = random.Next(i + 1);
            (array[i], array[j]) = (array[j], array[i]);
        }
    }
}