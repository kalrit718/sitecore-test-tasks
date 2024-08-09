
using Palindrome;

string inputString1 = "A!N,N A";
string inputString2 = "A!N,NB A";
string trashSymbolsString = ", !";

bool result;

Console.WriteLine("Using 'IsPalindrome' method");

result = PalindromeTester.IsPalindrome(inputString1, trashSymbolsString);
if (result) 
{
  Console.WriteLine($"'{inputString1}' is a palindrome! (without trash symbols)");
}
else
{
  Console.WriteLine($"'{inputString1}' is not a palindrome!");
}

result = PalindromeTester.IsPalindrome(inputString2, trashSymbolsString);
if (result) 
{
  Console.WriteLine($"'{inputString2}' is a palindrome! (without trash symbols)");
}
else
{
  Console.WriteLine($"'{inputString2}' is not a palindrome!");
}

Console.WriteLine("------------------------------");

Console.WriteLine("Using 'IsPalindromeBySingleScan' method");

result = PalindromeTester.IsPalindromeBySingleScan(inputString1, trashSymbolsString);
if (result) 
{
  Console.WriteLine($"'{inputString1}' is a palindrome! (without trash symbols)");
}
else
{
  Console.WriteLine($"'{inputString1}' is not a palindrome!");
}

result = PalindromeTester.IsPalindromeBySingleScan(inputString2, trashSymbolsString);
if (result) 
{
  Console.WriteLine($"'{inputString2}' is a palindrome! (without trash symbols)");
}
else
{
  Console.WriteLine($"'{inputString2}' is not a palindrome!");
}