using BenchmarkDotNet.Attributes;

namespace SortBenchmark.Benchmarks.Part1
{
    public class RandomArrayBenchmark
    {
        private int[] RandomArray = [];

        [Params(50000, 60000, 70000, 80000, 90000, 100000, 110000, 120000, 130000, 140000, 150000, 160000, 170000, 180000, 190000, 200000)] // Test dla różnych rozmiarów tablicy
        public int ArraySize;

        [GlobalSetup]
        public void Setup()
        {
            RandomArray = ArraysGenerator.GenerateConstantArray(ArraySize, new Random().Next(1000));
        }

        [Benchmark]
        [BenchmarkCategory("RandomArraySort")]
        public void Random_InsertionSort()
        {
            SortHelper.InsertionSort(RandomArray);
        }

        [Benchmark]
        [BenchmarkCategory("RandomArraySort")]
        public void Random_SelectionSort()
        {
            SortHelper.SelectionSort(RandomArray);
        }

        [Benchmark]
        [BenchmarkCategory("RandomArraySort")]
        public void Random_HeapSort()
        {
            SortHelper.HeapSort(RandomArray);
        }

        [Benchmark]
        [BenchmarkCategory("RandomArraySort")]
        public void Random_CocktailSort()
        {
            SortHelper.CocktailSort(RandomArray);
        }
    }
}
