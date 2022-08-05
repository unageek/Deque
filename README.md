[![nuget](https://img.shields.io/nuget/v/Unageek.Collections.Deque)](https://www.nuget.org/packages/Unageek.Collections.Deque)
[![build](https://img.shields.io/github/workflow/status/unageek/Deque/build/main)](https://github.com/unageek/Deque/actions?query=branch%3Amain+workflow%3Abuild)

# Deque&lt;T&gt;

`Deque<T>` is a .NET implementation of [double-ended queue](https://en.wikipedia.org/wiki/Double-ended_queue).

```cs
using Unageek.Collections;

var queue = new Deque<string>();
queue.AddLast("one");
queue.AddLast("two");
queue.AddLast("three");

var stack = new Deque<string>();
stack.AddFirst("three");
stack.AddFirst("two");
stack.AddFirst("one");

Console.WriteLine(queue.SequenceEqual(stack)); // True
```

## Features

- **Drop-in replacement for `List<T>`**

  `Deque<T>` implements the same interfaces, methods, and properties as `List<T>`, including random access, bulk insertion/removal, and binary search.

- **Performance**

  Random insertion and removal are expected to be twice as fast as `List<T>`.

- **Additional methods**

  `Deque<T>` also provides the following methods:

  - `void AddFirst(T item)` (equivalent to `Add`)
  - `void AddLast(T item)`
  - `void RemoveFirst()`
  - `void RemoveLast()`
  - `T PeekFirst()`
  - `T PeekLast()`
  - `T PopFirst()`
  - `T PopLast()`
  - `bool TryPeekFirst(out T item)`
  - `bool TryPeekLast(out T item)`
  - `bool TryPopFirst(out T item)`
  - `bool TryPopLast(out T item)`

## Limitations

- The maximum number of elements a `Deque<T>` can hold is 2<sup>30</sup> = 1,073,741,824. If you try to add more items, an `OutOfMemoryException` is thrown.

- The capacity of a `Deque<T>` can only be zero or a power of two (up to 2<sup>30</sup>).

- Serialization is not supported.

## Supported .NET Versions

.NET 6+ is supported.
