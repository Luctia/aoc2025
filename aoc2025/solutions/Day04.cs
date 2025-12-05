using aoc2025.helpers;

namespace aoc2025.solutions;

public class Day04 : Day
{
  public override void Part1()
  {
    var grid = new Grid(GetInputLines());
    var boxes = grid.FindChars('@').ToHashSet();
    Answer(boxes.Count(tuple =>
    {
      var around = new HashSet<(int, int)>();
      around.Add((tuple.x - 1, tuple.y));
      around.Add((tuple.x - 1, tuple.y + 1));
      around.Add((tuple.x - 1, tuple.y - 1));
      around.Add((tuple.x + 1, tuple.y));
      around.Add((tuple.x + 1, tuple.y + 1));
      around.Add((tuple.x + 1, tuple.y - 1));
      around.Add((tuple.x, tuple.y + 1));
      around.Add((tuple.x, tuple.y - 1));
      around.IntersectWith(boxes);
      return around.Count < 4;
    }));
  }

  public override void Part2()
  {
    var grid = new Grid(GetInputLines());
    var boxes = grid.FindChars('@').ToHashSet();
    var removed = 1;
    var totalRemoved = 0;
    while (removed > 0)
    {
      removed = boxes.RemoveWhere(tuple =>
      {
        var around = new HashSet<(int, int)>();
        around.Add((tuple.x - 1, tuple.y));
        around.Add((tuple.x - 1, tuple.y + 1));
        around.Add((tuple.x - 1, tuple.y - 1));
        around.Add((tuple.x + 1, tuple.y));
        around.Add((tuple.x + 1, tuple.y + 1));
        around.Add((tuple.x + 1, tuple.y - 1));
        around.Add((tuple.x, tuple.y + 1));
        around.Add((tuple.x, tuple.y - 1));
        around.IntersectWith(boxes);
        return around.Count < 4;
      });
      totalRemoved += removed;
    }
    Answer(totalRemoved);
  }
}