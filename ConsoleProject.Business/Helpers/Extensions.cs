using System.Text.RegularExpressions;

namespace ConsoleProject.Business.Helpers;

public static class Extensions
{
    public static bool IsOnlyLetters(this string input)
    {
        return Regex.IsMatch(input, @"^[a-zA-Z]+$");
    }
}
