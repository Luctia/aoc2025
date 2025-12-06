namespace aoc2025.solutions;

public class Day06 : Day
{
  public override void Part1()
  {
    var lines = GetInputLines();
    var columns = new List<List<long>>();
    for (int i = 0; i < lines[0].Split(' ').Count(c => c.Length > 0); i++)
    {
      columns.Add(new List<long>());
    }
    foreach (var line in lines[..^1])
    {
      var cols = line.Split(' ').Where(c => c.Length > 0).ToArray();
      for (int i = 0; i < cols.Length; i++)
      {
        columns[i].Add(long.Parse(cols[i]));
      }
    }

    var ans = 0L;
    for (int i = 0; i < columns.Count; i++)
    {
      var op = lines[^1].Split(' ').Where(c => c.Length > 0).ToArray()[i];
      switch (op)
      {
        case "*": ans += columns[i].Aggregate(1L, (l, r) => l * r); break;
        case "+": ans += columns[i].Aggregate(0L, (l, r) => l + r); break;
      }
    }
    Answer(ans);
  }

  public override void Part2()
  {
    var lines = GetInputLines();
    var maxNumberLength = lines.Length - 1;
    var ans = 0L;
    var numbers = new List<long>();
    for (var i = lines[0].Length - 1; i >= 0; i--)
    {
      var charArray = new char[maxNumberLength];
      for (var j = 0; j < maxNumberLength; j++)
      {
        charArray[j] = lines[j][i];
      }
      numbers.Add(long.Parse(charArray));
      if (lines[^1][i] == '*')
      {
        ans += numbers.Aggregate((a, b) => a * b);
        numbers.Clear();
        i--;
        continue;
      }
      if (lines[^1][i] == '+')
      {
        ans += numbers.Aggregate((a, b) => a + b);
        numbers.Clear();
        i--;
      }
    }
    Answer(ans);
  }
}
