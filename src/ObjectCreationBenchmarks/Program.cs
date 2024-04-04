using BenchmarkDotNet.Running;
using ObjectCreationBenchmarks;

public class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<Benchmarks>();
    }
}
