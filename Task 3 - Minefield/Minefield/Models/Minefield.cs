using MinefieldGame.Models;

namespace MinefieldGame.Services
{
  public class Minefield
  {
    public int[][] MinefieldMap { get; private set; } 
    public KeyValuePair<Point, int>[][] IndexedMinefieldMap { get; private set; } 
    private List<Point> visited;
    private List<Point> safePath;
    private Point? ogStart;

    public Minefield(int[][] minefieldMap)
    {
      MinefieldMap = minefieldMap;
      IndexedMinefieldMap = GetIndexedMinefieldMap(minefieldMap);

      visited = [];
      safePath = [];
    }

    private KeyValuePair<Point, int>[][] GetIndexedMinefieldMap(int[][] minefieldMap) {
      KeyValuePair<Point, int>[][] indexedMinefieldMap = new KeyValuePair<Point, int>[minefieldMap.Length][];

      for (int i = 0; i < minefieldMap.Length; i++)
      {
        indexedMinefieldMap[i] = new KeyValuePair<Point, int>[minefieldMap[i].Length];
        for (int j = 0; j < minefieldMap[i].Length; j++)
        {
          indexedMinefieldMap[i][j] = new KeyValuePair<Point, int>(new Point(i, j), minefieldMap[i][j]);
        }
      }
      return indexedMinefieldMap;
    }

    public List<Point> GetPath(Point start, Point end) {
      visited = [];
      safePath = [];

      safePath = SearchTillEnd(start, end, []);
      
      return safePath;
    }

    public List<Point> SearchTillEnd(Point start, Point end, List<Point> prev) {
      try {
        ogStart ??= start;

        List<Point> safeAdjacentPoints = GetSafeAdjacentPoints(start);
        safeAdjacentPoints = RemoveVisitedFromList(safeAdjacentPoints);

        prev.Add(start);
        if (end.Equals(start)) {
          return prev;
        }
        else if (IsDeadEnd(start, safeAdjacentPoints)) {
          prev.Clear();
          visited.Add(start);

          SearchTillEnd(ogStart, end, prev);
        }
        else {
          foreach (Point point in safeAdjacentPoints)
          {
            if (!IsAlreadyPicked(point, prev)) SearchTillEnd(point, end, prev);
          }
        }
        return prev;
      }
      catch (ArgumentOutOfRangeException) {
        return [];
      }
    }

    public void PrintMinefieldMap(List<Point>? safePath = null) {
      for (int i = 0; i < IndexedMinefieldMap.Length; i++) {
        for (int j = 0; j < IndexedMinefieldMap[0].Length; j++) {
          if (IndexedMinefieldMap[j][i].Value == 0) {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("X   ");
            Console.ResetColor();
          }
          else if (IndexedMinefieldMap[j][i].Value == 1) {
            if (safePath is not null && safePath.Contains(IndexedMinefieldMap[j][i].Key)) {
              Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else {
              Console.ForegroundColor = ConsoleColor.DarkBlue;
            }
            Console.Write("O   ");
            Console.ResetColor();
          }
        }
        Console.WriteLine("\n");
      }
    }

    public void PrintMinefieldMapCoordinates() {
      for (int i = 0; i < IndexedMinefieldMap.Length; i++) {
        for (int j = 0; j < IndexedMinefieldMap[0].Length; j++) {
          if (IndexedMinefieldMap[j][i].Value == 0) {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"({IndexedMinefieldMap[j][i].Key.X}, {IndexedMinefieldMap[j][i].Key.Y})  ");
            Console.ResetColor();
          }
          else if (IndexedMinefieldMap[j][i].Value == 1) {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write($"({IndexedMinefieldMap[j][i].Key.X}, {IndexedMinefieldMap[j][i].Key.Y})  ");
            Console.ResetColor();
          }
        }
        Console.WriteLine("\n");
      }
    }

    private List<Point> GetSafeAdjacentPoints(Point point) {
      List<Point> safeAdjacentValues = [];

      List<Point> allAdjacentValues = AdjacentNumberService.GetAdjacentValues(IndexedMinefieldMap, point);
      foreach (Point adjacentValue in allAdjacentValues)
      {
        if (IndexedMinefieldMap[adjacentValue.X][adjacentValue.Y].Value == 1) safeAdjacentValues.Add(adjacentValue);
      }

      return safeAdjacentValues;
    }

    private bool IsAlreadyPicked(Point point, List<Point> adjacentPoints) {
      for (int i = 0; i < adjacentPoints.Count; i++) {
        if (point.Equals(adjacentPoints[i])) return true;
      }
      return false;
    }

    private List<Point> RemoveVisitedFromList(List<Point> adjacentPoints) {

      for (int i = 0; i < adjacentPoints.Count; i++) {
        for (int j = 0; j < visited.Count; j++) {
          if (visited[j].Equals(adjacentPoints[i])) adjacentPoints.Remove(adjacentPoints[i]);
        }
      }
      return adjacentPoints;
    }

    private bool IsDeadEnd(Point targetPoint, List<Point> adjacentPoints) {
      return adjacentPoints.Count == 1 && !targetPoint.Equals(ogStart); 
    }
  }
}