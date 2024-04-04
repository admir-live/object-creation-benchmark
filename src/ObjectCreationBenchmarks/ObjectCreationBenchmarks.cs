using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace ObjectCreationBenchmarks;

[MemoryDiagnoser]
public class Benchmarks
{
    [Benchmark(Baseline = true)]
    public Person NewKeyword() 
        => new Person();

    [Benchmark]
    public object ActivatorCreateInstanceWithTypeOf() 
        => Activator.CreateInstance(typeof(Person));

    [Benchmark]
    public Person ActivatorCreateInstanceGeneric() 
        => Activator.CreateInstance<Person>();

    [Benchmark]
    public object GetUninitializedObject() 
        => RuntimeHelpers.GetUninitializedObject(typeof(Person));
}
