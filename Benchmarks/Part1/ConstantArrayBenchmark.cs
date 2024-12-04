using BenchmarkDotNet.Attributes;

namespace SortBenchmark.Benchmarks.Part1
{
    public class ConstantArrayBenchmark
    {
        private int[] ConstantArray = [];

        [Params(50000, 60000, 70000, 80000, 90000, 100000, 110000, 120000, 130000, 140000, 150000, 160000, 170000, 180000, 190000, 200000)] // Test dla różnych rozmiarów tablicy
        public int ArraySize;

        [GlobalSetup]
        public void Setup()
        {
            ConstantArray = ArraysGenerator.GenerateConstantArray(ArraySize, new Random().Next(1000));
        }

        [Benchmark]
        [BenchmarkCategory("ConstantArraySort")]
        public void Constant_InsertionSort()
        {
            SortHelper.InsertionSort(ConstantArray);
        }

        [Benchmark]
        [BenchmarkCategory("ConstantArraySort")]
        public void Constant_SelectionSort()
        {
            SortHelper.SelectionSort(ConstantArray);
        }

        [Benchmark]
        [BenchmarkCategory("ConstantArraySort")]
        public void Constant_HeapSort()
        {
            SortHelper.HeapSort(ConstantArray);
        }

        [Benchmark]
        [BenchmarkCategory("ConstantArraySort")]
        public void Constant_CocktailSort()
        {
            SortHelper.CocktailSort(ConstantArray);
        }
    }
}
