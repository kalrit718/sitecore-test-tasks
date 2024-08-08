using SimpleFigures.Models;

Point p1 = new Point(0, 0);
Point p2 = new Point(3, 4);

Line line = new Line(p1, p2);

Console.WriteLine("Initial coordinates of the line:");
Console.WriteLine($"Start Coordinates: ({line.Start.X}, {line.Start.Y})");
Console.WriteLine($"End Coordinates: ({line.End.X}, {line.End.Y})");

Console.WriteLine("------------------------------");

line.Move(2, -3);

Console.WriteLine("After moving the line:");
Console.WriteLine($"Start Coordinates: ({line.Start.X}, {line.Start.Y})");
Console.WriteLine($"End Coordinates: ({line.End.X}, {line.End.Y})");

Console.WriteLine("------------------------------");

line.Rotate(p1, 90);

Console.WriteLine("After rotating the line:");
Console.WriteLine($"Start Coordinates: ({line.Start.X}, {line.Start.Y})");
Console.WriteLine($"End Coordinates: ({line.End.X}, {line.End.Y})");

Console.WriteLine("------------------------------");

Circle circle = new Circle(p1, 5);

Console.WriteLine("Initial coordinates of the circle:");
Console.WriteLine($"Center Coordinates: ({circle.Center.X}, {circle.Center.Y})");

Console.WriteLine("------------------------------");

circle.Move(2, 3);

Console.WriteLine("After moving the circle:");
Console.WriteLine($"Center Coordinates: ({circle.Center.X}, {circle.Center.Y})");

Console.WriteLine("------------------------------");

circle.Rotate(p1, 90);

Console.WriteLine("After rotating the circle:");
Console.WriteLine($"Center Coordinates: ({circle.Center.X}, {circle.Center.Y})");

Console.WriteLine("------------------------------");

Aggregation aggregation = new Aggregation();
aggregation.AddFigure(p1);
aggregation.AddFigure(line);
aggregation.AddFigure(circle);

aggregation.Move(2, 3);

Console.WriteLine("After moving the aggregation:");

foreach (object figure in aggregation.Figures)
{
  switch (figure)
  {
    case Point pointFig:
      Console.WriteLine($"Point Coordinates: ({pointFig.X}, {pointFig.Y})");
      break;
    case Line lineFig:
      Console.WriteLine($"Line Start Coordinates: ({lineFig.Start.X}, {lineFig.Start.Y})");
      Console.WriteLine($"Line End Coordinates: ({lineFig.End.X}, {lineFig.End.Y})");
      break;
    case Circle circleFig:
      Console.WriteLine($"Circle Center Coordinates: ({circleFig.Center.X}, {circleFig.Center.Y})");
      break;
  }
}

Console.WriteLine("------------------------------");

Console.ReadLine();
