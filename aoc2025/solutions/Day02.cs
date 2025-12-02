namespace aoc2025.solutions;

public class Day02 : Day
{
  public override void Part1()
  {
    var ids = GetInput().Split(',');
    var ans = 0L;
    foreach (var id in ids)
    {
      var parts = id.Split('-');
      var start = long.Parse(parts[0]);
      var end = long.Parse(parts[1]);
      for (long i = start; i <= end; i++)
      {
        if (IsDouble(i.ToString()))
        {
          ans += i;
        }
      }
    }
    Answer(ans);
  }

  public override void Part2()
  {
    var ids = GetInput().Split(',');
    var ans = 0L;
    foreach (var id in ids)
    {
      var parts = id.Split('-');
      var start = long.Parse(parts[0]);
      var end = long.Parse(parts[1]);
      for (long i = start; i <= end; i++)
      {
        if (IsRepeating(i.ToString()))
        {
          ans += i;
        }
      }
    }
    Answer(ans);
  }

  private bool IsDouble(string id)
  {
    if (id.Length % 2 != 0)
    {
      return false;
    }
    if (string.Equals(id[..(id.Length / 2)], id[(id.Length / 2)..], StringComparison.Ordinal))
    {
      return true;
    }

    return false;
  }

  private bool IsRepeating(string id)
  {
    for (int i = 1; i < id.Length; i++)
    {
      if (id.Length % i == 0)
      {
        if (id.Replace(id[..i], "").Length == 0)
        {
          return true;
        }
      }
    }

    return false;
  }
}
