using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Running;
using SortBenchmark;
using SortBenchmark.Benchmarks.Part1;
using SortBenchmark.Benchmarks.Part2;
using SortBenchmark.Benchmarks.Part3;

internal class Program
{
    private static void Main(string[] args)
    {
        // Konfiguracja benchmarka
        var config = ManualConfig.Create(DefaultConfig.Instance)
            .AddExporter(HtmlExporter.Default)
            .AddExporter(CsvExporter.Default)
            .AddExporter(RPlotExporter.Default); // Dodaje eksport wykresów

        var randomSummary = BenchmarkRunner.Run<RandomArrayBenchmark>(config);
        var increasingSummary = BenchmarkRunner.Run<IncreasingArrayBenchmark>(config);
        var decreasingSummary = BenchmarkRunner.Run<DecreasingArrayBenchmark>(config);
        var constantSummary = BenchmarkRunner.Run<ConstantArrayBenchmark>(config);
        var vShapedSummary = BenchmarkRunner.Run<VShapedArrayBenchmark>(config);

        var summarySortingBenchmarks = BenchmarkRunner.Run<SortingBenchmarks>();
        var summaryQuickSortBenchmarks = BenchmarkRunner.Run<QuickSortBenchmarks>();
    }
}