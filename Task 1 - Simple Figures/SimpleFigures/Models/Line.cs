namespace SimpleFigures.Models
{
  public class Line
  {
    public Point Start { get; private set; }
    public Point End { get; private set; }

    public Line(Point start, Point end)
    {
      Start = start;
      End = end;
    }

    public void Move(double xVal, double yVal)
    {
      Start.Move(xVal, yVal);
      End.Move(xVal, yVal);
    }

    public void Rotate(Point origin, double angle)
    {
      Start.Rotate(origin, angle);
      End.Rotate(origin, angle);
    }
  }
}
