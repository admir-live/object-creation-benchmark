using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;

namespace GCBenchmark
{
    public class GCBenchmarks
    {
        private const int AllocationSize = 100_000;
        private const int NumberOfAllocations = 1000;

        [Benchmark]
        public void AllocateSmallObjects()
        {
            for (int i = 0; i < NumberOfAllocations; i++)
            {
                var data = new byte[AllocationSize];
            }
        }

        [Benchmark]
        public void AllocateLargeObjects()
        {
            for (int i = 0; i < NumberOfAllocations; i++)
            {
                var data = new byte[10 * AllocationSize]; // Increase the size to stress large object heap
            }
        }

        [Benchmark]
        public void AllocateAndKeepReferences()
        {
            var references = new List<byte[]>();
            for (int i = 0; i < NumberOfAllocations; i++)
            {
                references.Add(new byte[AllocationSize]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<GCBenchmarks>();
        }
    }
}
