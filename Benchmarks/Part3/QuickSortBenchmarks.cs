using BenchmarkDotNet.Attributes;

namespace SortBenchmark.Benchmarks.Part3
{
    public class QuickSortBenchmarks
    {
        private int[] randomArray = [];
        private int[] aShapedArray = [];

        [Params(100, 1000, 10000)] // Rozmiary tablic do testów
        public int ArraySize;

        [GlobalSetup]
        public void Setup()
        {
            var random = new Random();

            // Tablica losowa
            randomArray = Enumerable.Range(0, ArraySize).OrderBy(_ => random.Next()).ToArray();

            // "A-kształtna" tablica
            aShapedArray = Enumerable.Range(0, ArraySize / 2).Concat(Enumerable.Range(0, ArraySize / 2).Reverse()).ToArray();
        }

        [Benchmark]
        public void RecursiveQuickSort_Random_PivotRight() =>
            RecursiveQuickSort((int[])randomArray.Clone(), 0, randomArray.Length - 1, PivotType.Right);

        [Benchmark]
        public void RecursiveQuickSort_Random_PivotMiddle() =>
            RecursiveQuickSort((int[])randomArray.Clone(), 0, randomArray.Length - 1, PivotType.Middle);

        [Benchmark]
        public void RecursiveQuickSort_Random_PivotRandom() =>
            RecursiveQuickSort((int[])randomArray.Clone(), 0, randomArray.Length - 1, PivotType.Random);

        [Benchmark]
        public void IterativeQuickSort_Random_PivotRight() =>
            IterativeQuickSort((int[])randomArray.Clone(), PivotType.Right);

        [Benchmark]
        public void IterativeQuickSort_Random_PivotMiddle() =>
            IterativeQuickSort((int[])randomArray.Clone(), PivotType.Middle);

        [Benchmark]
        public void IterativeQuickSort_Random_PivotRandom() =>
            IterativeQuickSort((int[])randomArray.Clone(), PivotType.Random);

        private enum PivotType { Right, Middle, Random }

        private void RecursiveQuickSort(int[] array, int low, int high, PivotType pivotType)
        {
            if (low < high)
            {
                int pivotIndex = Partition(array, low, high, pivotType);
                RecursiveQuickSort(array, low, pivotIndex - 1, pivotType);
                RecursiveQuickSort(array, pivotIndex + 1, high, pivotType);
            }
        }

        private int Partition(int[] array, int low, int high, PivotType pivotType)
        {
            int pivotIndex = pivotType switch
            {
                PivotType.Right => high,
                PivotType.Middle => (low + high) / 2,
                PivotType.Random => new Random().Next(low, high + 1),
                _ => high
            };

            int pivotValue = array[pivotIndex];
            (array[pivotIndex], array[high]) = (array[high], array[pivotIndex]); // Przenieś pivot na koniec
            int storeIndex = low;

            for (int i = low; i < high; i++)
            {
                if (array[i] < pivotValue)
                {
                    (array[i], array[storeIndex]) = (array[storeIndex], array[i]);
                    storeIndex++;
                }
            }

            (array[storeIndex], array[high]) = (array[high], array[storeIndex]);
            return storeIndex;
        }

        private void IterativeQuickSort(int[] array, PivotType pivotType)
        {
            var stack = new System.Collections.Generic.Stack<(int low, int high)>();
            stack.Push((0, array.Length - 1));

            while (stack.Count > 0)
            {
                var (low, high) = stack.Pop();

                if (low < high)
                {
                    int pivotIndex = Partition(array, low, high, pivotType);
                    stack.Push((low, pivotIndex - 1));
                    stack.Push((pivotIndex + 1, high));
                }
            }
        }
    }
}
