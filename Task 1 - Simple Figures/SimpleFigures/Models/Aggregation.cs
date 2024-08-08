namespace SimpleFigures.Models
{
  public class Aggregation
  {
    // private List<object> _figures {get; set;}
    public List<object> Figures { get; private set; }

    public Aggregation()
    {
      Figures = [];
    }

    public void AddFigure(object figure)
    {
      if (figure is Point || figure is Line || figure is Circle)
      {
        Figures.Add(figure);
      }
      else
      {
        throw new ArgumentException("Unsupported Object.");
      }
    }

    public void Move(double xVal, double yVal)
    {
      foreach (var figure in Figures)
      {
        switch (figure)
        {
          case Point point:
            point.Move(xVal, yVal);
            break;
          case Line line:
            line.Move(xVal, yVal);
            break;
          case Circle circle:
            circle.Move(xVal, yVal);
            break;
        }
      }
    }

    public void Rotate(Point origin, double angle)
    {
      foreach (var figure in Figures)
      {
        switch (figure)
        {
          case Point point:
            point.Rotate(origin, angle);
            break;
          case Line line:
            line.Rotate(origin, angle);
            break;
          case Circle circle:
            circle.Rotate(origin, angle);
            break;
        }
      }
    }
  }
}
