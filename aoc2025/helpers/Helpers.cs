namespace aoc2025.helpers;

public static class Helpers
{
  public static int Mod(int x, int m) {
    return (x%m + m)%m;
  }
}