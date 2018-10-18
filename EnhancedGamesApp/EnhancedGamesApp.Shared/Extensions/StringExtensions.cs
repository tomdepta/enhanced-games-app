using System.Text.RegularExpressions;

namespace EnhancedGamesApp.Shared.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveSpecialCharacters(this string text)
        {
            return Regex.Replace(text, "[^a-zA-Z0-9_]+", "", RegexOptions.Compiled);
        }
    }
}
