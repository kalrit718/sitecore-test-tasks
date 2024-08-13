namespace MinefieldGame.Models
{
  public class Point: IEquatable<Point>
  {
    public int X { get; private set; }
    public int Y { get; private set; }

    public Point(int x, int y)
    {
      X = x;
      Y = y;
    }

    public bool Equals(Point? other)
    {
      if (other == null) return false;
      if (other.X == X && other.Y == Y) return true;
      return false;
    }
  }
}