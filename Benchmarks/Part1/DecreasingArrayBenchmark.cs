using BenchmarkDotNet.Attributes;

namespace SortBenchmark.Benchmarks.Part1
{
    public class DecreasingArrayBenchmark
    {
        private int[] DecreasingArray = [];

        [Params(50000, 60000, 70000, 80000, 90000, 100000, 110000, 120000, 130000, 140000, 150000, 160000, 170000, 180000, 190000, 200000)] // Test dla różnych rozmiarów tablicy
        public int ArraySize;

        [GlobalSetup]
        public void Setup()
        {
            DecreasingArray = ArraysGenerator.GenerateConstantArray(ArraySize, new Random().Next(1000));
        }

        [Benchmark]
        [BenchmarkCategory("DecreasingArraySort")]
        public void Decreasing_InsertionSort()
        {
            SortHelper.InsertionSort(DecreasingArray);
        }

        [Benchmark]
        [BenchmarkCategory("DecreasingArraySort")]
        public void Decreasing_SelectionSort()
        {
            SortHelper.SelectionSort(DecreasingArray);
        }

        [Benchmark]
        [BenchmarkCategory("DecreasingArraySort")]
        public void Decreasing_HeapSort()
        {
            SortHelper.HeapSort(DecreasingArray);
        }

        [Benchmark]
        [BenchmarkCategory("DecreasingArraySort")]
        public void Decreasing_CocktailSort()
        {
            SortHelper.CocktailSort(DecreasingArray);
        }
    }
}
