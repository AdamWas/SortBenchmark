namespace SortBenchmark
{
    public static class ArraysGenerator
    {
        public static int[] GenerateRandomArray(int size)
        {
            var random = new Random();
            return Enumerable.Range(0, size).Select(_ => random.Next(1, 100)).ToArray();
        }

        public static int[] GenerateIncreasingArray(int size)
        {
            return Enumerable.Range(0, size).ToArray();
        }

        public static int[] GenerateDecreasingArray(int size)
        {
            return Enumerable.Range(0, size).Reverse().ToArray();
        }

        public static int[] GenerateConstantArray(int size, int value)
        {
            return Enumerable.Repeat(value, size).ToArray();
        }

        public static int[] GenerateVShapedArray(int size)
        {
            int mid = size / 2;
            int[] left = Enumerable.Range(0, mid).Reverse().ToArray();  // Malejąca część
            int[] right = Enumerable.Range(0, size - mid).ToArray();    // Rosnąca część
            return left.Concat(right).ToArray();
        }
    }
}
