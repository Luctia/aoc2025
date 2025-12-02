using aoc2025.helpers;

namespace aoc2025.solutions;

public class Day01 : Day
{
  public override void Part1()
  {
    var dial = 50;
    var password = 0;
    var lines = GetInputLines();
    foreach (var line in lines)
    {
      var rotation = int.Parse(line[1..]);
      dial += line[0] == 'L' ? -rotation : rotation;
      
      dial = Helpers.Mod(dial, 100);

      if (dial == 0)
      {
        password++;
      }
    }

    Answer(password);
  }

  public override void Part2()
  {
    var dial = 50;
    var password = 0;
    var lines = GetInputLines();
    foreach (var line in lines)
    {
      var rotation = int.Parse(line[1..]);
      dial += line[0] == 'L' ? -rotation : rotation;

      password += dial <= 0 && rotation > Math.Abs(dial) ? 1 : 0;
      password += Math.Abs(dial / 100);
      
      dial = Helpers.Mod(dial, 100);
    }

    Answer(password);
  }
}