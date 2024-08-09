namespace Minefield.Services
{
  public class AdjacentNumberService
  {
    public static bool IsValidPosition(int i, int j, int n, int m)
    {
      if (i < 0 || j < 0 || i > n - 1 || j > m - 1) return false;
      return true;
    }

    public static List<int> GetAdjacentValues(KeyValuePair<int, int>[][] arr, int i, int j)
    {
      int n = arr.Length;
      int m = arr[0].Length;

      List<int> values = [];

      if (IsValidPosition(i - 1, j - 1, n, m))
      { 
        values.Add(arr[i - 1][j - 1].Key); 
      }
      if (IsValidPosition(i - 1, j, n, m))
      {
        values.Add(arr[i - 1][j].Key);
      }
      if (IsValidPosition(i - 1, j + 1, n, m))
      {
        values.Add(arr[i - 1][j + 1].Key);
      }
      if (IsValidPosition(i, j - 1, n, m))
      {
        values.Add(arr[i][j - 1].Key);
      }
      if (IsValidPosition(i, j + 1, n, m))
      {
        values.Add(arr[i][j + 1].Key);
      }
      if (IsValidPosition(i + 1, j - 1, n, m))
      {
        values.Add(arr[i + 1][j - 1].Key);
      }
      if (IsValidPosition(i + 1, j, n, m))
      {
        values.Add(arr[i + 1][j].Key);
      }
      if (IsValidPosition(i + 1, j + 1, n, m))
      {
        values.Add(arr[i + 1][j + 1].Key);
      }

      return values;
    }
  }
}
