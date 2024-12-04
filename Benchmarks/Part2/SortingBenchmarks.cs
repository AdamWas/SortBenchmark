using BenchmarkDotNet.Attributes;

namespace SortBenchmark.Benchmarks.Part2
{
    [MemoryDiagnoser]
    public class SortingBenchmarks
    {
        private int[] randomArray = [];
        private int[] sortedArray = [];
        private int[] reversedArray = [];
        private int[] nearlySortedArray = [];
        private int[] duplicateArray = [];

        [Params(100, 1000, 10000)] // Test dla różnych rozmiarów tablicy
        public int ArraySize;

        [GlobalSetup]
        public void Setup()
        {
            var random = new Random();

            // Tablica losowa
            randomArray = Enumerable.Range(0, ArraySize).OrderBy(_ => random.Next()).ToArray();

            // Tablica posortowana
            sortedArray = Enumerable.Range(0, ArraySize).ToArray();

            // Tablica odwrotnie posortowana
            reversedArray = sortedArray.Reverse().ToArray();

            // Tablica prawie posortowana (małe zakłócenia)
            nearlySortedArray = sortedArray.ToArray();
            for (int i = 0; i < ArraySize / 10; i++)
            {
                int index1 = random.Next(ArraySize);
                int index2 = random.Next(ArraySize);
                (nearlySortedArray[index1], nearlySortedArray[index2]) = (nearlySortedArray[index2], nearlySortedArray[index1]);
            }

            // Tablica z duplikatami
            duplicateArray = Enumerable.Repeat(Enumerable.Range(0, ArraySize / 10).ToArray(), 10).SelectMany(x => x).ToArray();
        }

        [Benchmark]
        public void QuickSort_Random() => Array.Sort((int[])randomArray.Clone());

        [Benchmark]
        public void BubbleSort_Random() => BubbleSort((int[])randomArray.Clone());

        [Benchmark]
        public void QuickSort_Sorted() => Array.Sort((int[])sortedArray.Clone());

        [Benchmark]
        public void BubbleSort_Sorted() => BubbleSort((int[])sortedArray.Clone());

        [Benchmark]
        public void QuickSort_Reversed() => Array.Sort((int[])reversedArray.Clone());

        [Benchmark]
        public void BubbleSort_Reversed() => BubbleSort((int[])reversedArray.Clone());

        private void BubbleSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
        }
    }

}
