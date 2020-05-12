using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextAnalizer.WordCounter.Helpers
{
    public static class WorldCounterStringHelper
    {
        private const string RegexWordPattern = "[^\\w]";
        private const string RegexWordSeparators = "[-']";

        public static string[] SplitWords(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string[0];
            }
            return Regex.Split(text.RemoveCharactersThatSeparateWords(), RegexWordPattern, RegexOptions.IgnoreCase).RemoveEmptyWords();
        }

        private static string RemoveCharactersThatSeparateWords(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            return Regex.Replace(text, RegexWordSeparators, string.Empty);
        }

        private static string[] RemoveEmptyWords(this string[] words)
        {
            if (words == null)
            {
                return words;
            }
            return words.Where(w => w != string.Empty).ToArray();
        }
    }
}
