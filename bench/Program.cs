using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Unageek.Collections;

BenchmarkRunner.Run<Bench>();

public class Bench
{
    private const int N = 100000;
    
    [Benchmark]
    public void List_RandomInsertion()
    {
        var list = new List<int>();
        var random = new Random();
        for (var i = 0; i < N; i++)
        {
            list.Insert(random.Next(list.Count + 1), i);
        }
    }
    
    [Benchmark]
    public void Deque_RandomInsertion()
    {
        var deque = new Deque<int>();
        var random = new Random();
        for (var i = 0; i < N; i++)
        {
            deque.Insert(random.Next(deque.Count + 1), i);
        }
    }
    
    [Benchmark]
    public void List_RandomRemoval()
    {
        var list = new List<int>(N);
        list.AddRange(Enumerable.Repeat(0, N));
        var random = new Random();
        for (var i = 0; i < N; i++)
        {
            list.RemoveAt(random.Next(0, list.Count));
        }
    }
    
    [Benchmark]
    public void Deque_RandomRemoval()
    {
        var deque = new Deque<int>(N);
        deque.AddRange(Enumerable.Repeat(0, N));
        var random = new Random();
        for (var i = 0; i < N; i++)
        {
            deque.RemoveAt(random.Next(0, deque.Count));
        }
    }
}
