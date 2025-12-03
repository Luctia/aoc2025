namespace aoc2025.solutions;

public class Day03 : Day
{
  public override void Part1()
  {
    var banks = GetInputLines().Select(l => l.ToCharArray().Select(c => short.Parse(c.ToString())).ToArray()).ToArray();
    Answer(banks.Sum(b => GetMaxValue(b, 2)));
  }

  public override void Part2()
  {
    var banks = GetInputLines().Select(l => l.ToCharArray().Select(c => short.Parse(c.ToString())).ToArray()).ToArray();
    Answer(banks.Sum(b => GetMaxValue(b, 12)));
  }

  private static long GetMaxValue(short[] bank, int numberLength)
  {
    var max = bank.Max();
    if (numberLength == 1)
    {
      return max;
    }
    var index = Array.IndexOf(bank, max);
    while (index < 0 || index + numberLength > bank.Length)
    {
      max--;
      index = Array.IndexOf(bank, max);
    }

    return max * (long)Math.Pow(10, numberLength - 1) + GetMaxValue(bank[(index + 1)..], numberLength - 1);
  }
}