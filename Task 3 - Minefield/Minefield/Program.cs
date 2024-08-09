using Minefield.Services;

int[][] minefieldMap = [
  [0, 0, 1, 0],
  [0, 0, 0, 0],
  [1, 0, 0, 0],
  [0, 1, 0, 0]
];

// Implementing a 2D array with both Unique key and the flag about bombs.
// Such as; 1  0   2  0   3  1   4 0	
//          5  0   6  0   7  0   8 0	
//          9  1   10 0   11 0	12 0	
//          13 0	 14 1 	15 0	16 0	

KeyValuePair<int, int>[][] numberedMinefieldMap = new KeyValuePair<int, int>[minefieldMap.Length][];
int number = 1;

for (int i = 0; i < minefieldMap.Length; i++)
{
  numberedMinefieldMap[i] = new KeyValuePair<int, int>[minefieldMap[i].Length];
  for (int j = 0; j < minefieldMap[i].Length; j++)
  {
    numberedMinefieldMap[i][j] = new KeyValuePair<int, int>(number++, minefieldMap[i][j]);
  }
}


for (int i = 0; i < numberedMinefieldMap.Length; i++)
{
  for (int j = 0; j < numberedMinefieldMap[i].Length; j++)
  {
    Console.Write(numberedMinefieldMap[i][j].Key + " " + numberedMinefieldMap[i][j].Value + "\t");
  }
  Console.WriteLine();
}

int x = 1, y = 2;
List<int> adjValues = AdjacentNumberService.GetAdjacentValues(numberedMinefieldMap, x, y);

Console.WriteLine();

for (int i = 0; i < adjValues.Count; i++) 
{
  Console.Write(adjValues[i]);
  Console.Write(" ");
}