namespace Palindrome
{
  public class PalindromeTester
  {
    public static bool IsPalindrome(string inputString, string trashSymbolsString)
    {
      inputString = inputString.ToLower();
      trashSymbolsString = trashSymbolsString.ToLower();

      string filteredString = new string(inputString.Where(character => !trashSymbolsString.Contains(character)).ToArray());

      string reversedString = new string(filteredString.Reverse().ToArray());
      return filteredString == reversedString;
    }

    public static bool IsPalindromeBySingleScan(string inputString, string trashSymbolsString)
    {
      int left = 0;
      int right = inputString.Length - 1;

      while (left < right)
      {
        if (trashSymbolsString.Contains(char.ToLower(inputString[left]))) 
        {
          left++;
          continue;
        }

        if (trashSymbolsString.Contains(char.ToLower(inputString[right])))
        {
          right--;
          continue;
        }

        if (char.ToLower(inputString[left]) != char.ToLower(inputString[right])) 
        {
          return false;
        }

        left++;
        right--;
      }

      return true;
    }
  }
}
