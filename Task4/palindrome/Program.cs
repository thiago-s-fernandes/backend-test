namespace palindrome
{
  public class PalindromeChecker
  {
    public static bool CheckPalindrome(string value)
    {
      if (string.IsNullOrEmpty(value)) return true;

      return IsPalindromeRecursive(value, 0, value.Length - 1);
    }

    private static bool IsPalindromeRecursive(string text, int left, int right)
    {
      // Avança left até encontrar caractere alfanumérico ou ultrapassar right
      while (left < right && !char.IsLetterOrDigit(text[left]))
        left++;

      // Avança right até encontrar caractere alfanumérico ou ultrapassar left
      while (right > left && !char.IsLetterOrDigit(text[right]))
        right--;

      // Caso base: índices cruzados ou iguais
      if (left >= right)
        return true;

      // Compara caracteres ignorando case
      if (char.ToLower(text[left]) != char.ToLower(text[right]))
        return false;

      // Chama recursivamente o método
      return IsPalindromeRecursive(text, left + 1, right - 1);
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine(PalindromeChecker.CheckPalindrome("rotor")); // true
      Console.WriteLine(PalindromeChecker.CheckPalindrome("motor")); // false
      Console.WriteLine(PalindromeChecker.CheckPalindrome("")); // true
      Console.WriteLine(PalindromeChecker.CheckPalindrome("12321")); // true
      Console.WriteLine(PalindromeChecker.CheckPalindrome("A cara rajada da jararaca")); // true
    }
  }
}
