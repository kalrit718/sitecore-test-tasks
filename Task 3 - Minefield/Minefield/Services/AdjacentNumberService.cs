using MinefieldGame.Models;

namespace MinefieldGame.Services
{
  public class AdjacentNumberService
  {
    // (x,y)	

    // (0,0)  (1,0)  (2,0)  (3,0) (4,0)	|
    //                                  |
    // (0,1)  (1,1)  (2,1)  (3,1) (4,1)	|
    //                                  |
    // (0,2)  (1,2)  (2,2)  (3,2) (4,2)	b
    //                                  |
    // (0,3)  (1,3)	 (2,3)  (3,3) (4,3)	|
    //                                  |
    // (0,4)  (1,4)	 (2,4)  (3,4) (4,4)	|

    // --------------- a ---------------

    // public static List<Point> GetSafeAdjacentValues(KeyValuePair<Point, int>[][] refMatrix, Point refPoint)
    // {
    //   List<Point> allAdjacentValues = GetAdjacentValues(refMatrix, refPoint)
    

    //   return safeAdjacentValues;
    // }
    
    public static List<Point> GetAdjacentValues(KeyValuePair<Point, int>[][] refMatrix, Point refPoint)
    {
      int a = refMatrix[0].Length;
      int b = refMatrix.Length;

      List<Point> adjacentValues = [];

      // Top left adjacent point
      if (IsValidPosition(refPoint.X - 1, refPoint.Y - 1, a, b))
      {
        adjacentValues.Add(refMatrix[refPoint.X - 1][refPoint.Y - 1].Key); 
      }
      // Left adjacent point
      if (IsValidPosition(refPoint.X - 1, refPoint.Y, a, b))
      {
        adjacentValues.Add(refMatrix[refPoint.X - 1][refPoint.Y].Key);
      }
      // Bottom left adjacent point
      if (IsValidPosition(refPoint.X - 1, refPoint.Y + 1, a, b))
      {
        adjacentValues.Add(refMatrix[refPoint.X - 1][refPoint.Y + 1].Key);
      }
      // Top adjacent point
      if (IsValidPosition(refPoint.X, refPoint.Y - 1, a, b))
      {
        adjacentValues.Add(refMatrix[refPoint.X][refPoint.Y - 1].Key);
      }
      // Bottom adjacent point
      if (IsValidPosition(refPoint.X, refPoint.Y + 1, a, b))
      {
        adjacentValues.Add(refMatrix[refPoint.X][refPoint.Y + 1].Key);
      }
      // Top right adjacent point
      if (IsValidPosition(refPoint.X + 1, refPoint.Y - 1, a, b))
      {
        adjacentValues.Add(refMatrix[refPoint.X + 1][refPoint.Y - 1].Key);
      }
      // Right adjacent point
      if (IsValidPosition(refPoint.X + 1, refPoint.Y, a, b))
      {
        adjacentValues.Add(refMatrix[refPoint.X + 1][refPoint.Y].Key);
      }
      // Bottom right adjacent point
      if (IsValidPosition(refPoint.X + 1, refPoint.Y + 1, a, b))
      {
        adjacentValues.Add(refMatrix[refPoint.X + 1][refPoint.Y + 1].Key);
      }

      return adjacentValues;
    }

    private static bool IsValidPosition(int x, int y, int a, int b)
    {
      if (x < 0 || y < 0 || y > a - 1 || x > b - 1) return false;
      return true;
    }
  }
}
