namespace SimpleFigures.Models
{
  public class Circle
  {
    public Point Center { get; private set; }
    public double Radius { get; private set; }

    public Circle(Point center, double radius)
    {
      Center = center;
      Radius = radius;
    }

    public void Move(double xVal, double yVal)
    {
      Center.Move(xVal, yVal);
    }

    public void Rotate(Point origin, double angle)
    {
      Center.Rotate(origin, angle);
    }
  }
}
