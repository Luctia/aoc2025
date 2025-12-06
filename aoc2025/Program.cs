using aoc2025.solutions;

namespace aoc2025;

internal static class Program
{
  [STAThread]
  private static void Main()
  {
    var watch = System.Diagnostics.Stopwatch.StartNew();
    new Day06().Part1();
    watch.Stop();
    Console.WriteLine(watch.ElapsedMilliseconds);
    watch = System.Diagnostics.Stopwatch.StartNew();
    new Day06().Part2();
    watch.Stop();
    Console.WriteLine(watch.ElapsedMilliseconds);
  }
}