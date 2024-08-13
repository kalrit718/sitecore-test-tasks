using System.Text.RegularExpressions;
using MinefieldGame.Models;
using MinefieldGame.Services;

int[][] minefieldMap = [
  [1, 0, 1, 0, 1],
  [1, 0, 0, 1, 0],
  [0, 1, 0, 0, 1],
  [0, 0, 1, 1, 0],
  [1, 1, 0, 0, 0]
];

Minefield minefield = new Minefield(minefieldMap);

while (true) {
  Console.WriteLine("\nMinefield Map: \n");
  minefield.PrintMinefieldMap();

  Console.WriteLine("\nMinefield Map Coordinates: \n");
  minefield.PrintMinefieldMapCoordinates();

  Console.Write("\nEnter coordinates of the starting point (x, y): ");
  string? startingCoordinatesStr = Console.ReadLine();
  int[]? startingCoordinates;

  Regex coordinatesReg = new Regex(@"\d+\s*,\s*\d+");

  if (startingCoordinatesStr is not null && coordinatesReg.IsMatch(startingCoordinatesStr)) {
    Match startingCoordinatesMatch = coordinatesReg.Match(startingCoordinatesStr);
    startingCoordinates = startingCoordinatesMatch.Value
                          .Split(char.Parse(","))
                          .Select(number => Convert.ToInt32(number.Trim()))
                          .ToArray();
  }
  else {
    Console.Clear();
    continue;
  }

  Console.Write("\nEnter coordinates of the target point (x, y): ");
  string? endingCoordinatesStr = Console.ReadLine();
  int[]? endingCoordinates;

  if (endingCoordinatesStr is not null && coordinatesReg.IsMatch(endingCoordinatesStr)) {
    Match endingCoordinatesMatch = coordinatesReg.Match(endingCoordinatesStr);
    endingCoordinates = endingCoordinatesMatch.Value
                          .Split(char.Parse(","))
                          .Select(number => Convert.ToInt32(number.Trim()))
                          .ToArray();
  }
  else {
    Console.Clear();
    continue;
  }

  List<Point> safePath = minefield.GetPath(
    new Point(startingCoordinates[0], startingCoordinates[1]), 
    new Point(endingCoordinates[0], endingCoordinates[1])
  );

  if (safePath.Count > 0) {
    Console.WriteLine("\nSafe path to the target point: \n");
    minefield.PrintMinefieldMap(safePath);
  }
  else {
    Console.WriteLine("\nA safe path to the target point does not exist! \n");
  }

  Console.WriteLine("Press enter to play again...");
  Console.ReadLine();
  Console.Clear();
}
