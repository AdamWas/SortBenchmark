using BenchmarkDotNet.Attributes;

namespace SortBenchmark.Benchmarks.Part1
{
    public class VShapedArrayBenchmark
    {
        private int[] VShapedArray = [];

        [Params(50000, 60000, 70000, 80000, 90000, 100000, 110000, 120000, 130000, 140000, 150000, 160000, 170000, 180000, 190000, 200000)] // Test dla różnych rozmiarów tablicy
        public int ArraySize;

        [GlobalSetup]
        public void Setup()
        {
            VShapedArray = ArraysGenerator.GenerateConstantArray(ArraySize, new Random().Next(1000));
        }

        [Benchmark]
        [BenchmarkCategory("VShapedArraySort")]
        public void VShaped_InsertionSort()
        {
            SortHelper.InsertionSort(VShapedArray);
        }

        [Benchmark]
        [BenchmarkCategory("VShapedArraySort")]
        public void VShaped_SelectionSort()
        {
            SortHelper.SelectionSort(VShapedArray);
        }

        [Benchmark]
        [BenchmarkCategory("VShapedArraySort")]
        public void VShaped_HeapSort()
        {
            SortHelper.HeapSort(VShapedArray);
        }

        [Benchmark]
        [BenchmarkCategory("VShapedArraySort")]
        public void VShaped_CocktailSort()
        {
            SortHelper.CocktailSort(VShapedArray);
        }
    }
}
