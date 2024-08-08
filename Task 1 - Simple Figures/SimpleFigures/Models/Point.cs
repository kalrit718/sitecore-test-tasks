namespace SimpleFigures.Models
{
  public class Point
  {
    public double X { get; private set; }
    public double Y { get; private set; }
    
    public Point(double x, double y)
    {
      X = x;
      Y = y;
    }
    
    public void Move(double xVal, double yVal)
    {
      X += xVal;
      Y += yVal;
    }

    /// <summary>
    /// Rotates the point around another origin point by a specific angle.
    /// Inspired by https://stackoverflow.com/a/2259502/5283536
    /// </summary>
    /// <param name="origin">Origin point coordinates</param>
    /// <param name="angle">Angle to be rotated (in degrees)</param>
    public void Rotate(Point origin, double angle)
    {
      // 360° = 2π rad
      double radians = angle * (Math.PI / 180);
      double sinTheta = Math.Sin(radians);
      double cosTheta = Math.Cos(radians);

      // translate the point back to origin
      double xTranslated = X - origin.X;
      double yTranslated = Y - origin.Y;

      // rotate the point
      double xRotated = xTranslated * cosTheta - yTranslated * sinTheta;
      double yRotated = xTranslated * sinTheta + yTranslated * cosTheta;

      // translate the point back
      X = xRotated + origin.X;
      Y = yRotated + origin.Y;
    }
  }
}
