namespace aoc2025.solutions;

public class Day05 : Day
{
  public override void Part1()
  {
    var lines = GetInputLines();
    List<(long, long)> ranges = [];
    List<long> ids = [];
    foreach (var line in lines)
    {
      if (line.Length > 1)
      {
        if (line.Contains('-'))
        {
          ranges.Add((long.Parse(line.Split('-')[0]), long.Parse(line.Split('-')[1])));
        }
        else
        {
          ids.Add(long.Parse(line));
        }
      }
    }

    var ans = 0;
    foreach (var id in ids)
    {
      foreach (var range in ranges)
      {
        if (id >= range.Item1 && id <= range.Item2)
        {
          ans++;
          break;
        }
      }
    }

    Answer(ans);
  }

  public override void Part2()
  {
    var lines = GetInputLines();
    List<(long, long)> ranges = [];
    foreach (var line in lines)
    {
      if (line.Contains('-'))
      {
        ranges.Add((long.Parse(line.Split('-')[0]), long.Parse(line.Split('-')[1])));
      }
      else
      {
        break;
      }
    }
    ranges = ranges.OrderBy(r => r.Item1).ToList();
    var changed = true;
    while (changed)
    {
      changed = false;
      for (int i = 1; i < ranges.Count; i++)
      {
        if (ranges[i].Item1 <= ranges[i - 1].Item2)
        {
          if (ranges[i].Item2 > ranges[i - 1].Item2)
          {
            ranges[i - 1] = (ranges[i - 1].Item1, ranges[i].Item2);
          }

          ranges.Remove(ranges[i]);
          changed = true;
        }
      }
    }
    
    Answer(ranges.Sum(r => r.Item2 - r.Item1 + 1));
  }
}