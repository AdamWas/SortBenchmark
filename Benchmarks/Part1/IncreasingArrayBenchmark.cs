using BenchmarkDotNet.Attributes;

namespace SortBenchmark.Benchmarks.Part1
{
    public class IncreasingArrayBenchmark
    {
        private int[] IncreasingArray = [];

        [Benchmark]
        [BenchmarkCategory("IncreasingArraySort")]
        public void Increasing_InsertionSort()
        {
            SortHelper.InsertionSort(IncreasingArray);
        }

        [Benchmark]
        [BenchmarkCategory("IncreasingArraySort")]
        public void Increasing_SelectionSort()
        {
            SortHelper.SelectionSort(IncreasingArray);
        }

        [Benchmark]
        [BenchmarkCategory("IncreasingArraySort")]
        public void Increasing_HeapSort()
        {
            SortHelper.HeapSort(IncreasingArray);
        }

        [Benchmark]
        [BenchmarkCategory("IncreasingArraySort")]
        public void Increasing_CocktailSort()
        {
            SortHelper.CocktailSort(IncreasingArray);
        }
    }
}
