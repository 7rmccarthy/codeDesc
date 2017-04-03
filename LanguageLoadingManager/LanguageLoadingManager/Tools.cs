#region License

// Copyright (c) 2017, Vira
// All rights reserved.
// Solution: LanguageLoadingManager
// Project: LanguageLoadingManager
// Filename: Tools.cs
// Date - created:2017.03.28 - 18:45
// Date - current: 2017.03.28 - 19:24

#endregion

namespace LanguageLoadingManager
{
    internal static class Tools
    {
        /// <summary>
        ///     Generating regex code based on the parameter.
        /// </summary>
        /// <param name="keyword">The keyword which should have that color.</param>
        /// <param name="current">true: this current word; false: the following word</param>
        /// <returns>This function returns regex code based on the keyword and the color.</returns>
        public static string RegexFromString(this string keyword, bool current)
        {
            return current ? $@"(\w +)(?<=\b\s{keyword})" : $@"(?<=\b{keyword}\s)(\w+)";
        }

        /// <summary>
        /// Checks if the string is in a valid format. (keyword,color,boolean)
        /// </summary>
        /// <param name="keywordLine">The string that should get checked for validation.</param>
        /// <returns>true: the line is valid; false: the line is invalid</returns>
        public static bool IsValid(this string keywordLine)
        {
            bool doNotHaveCsharpSevenDot0;

            return !string.IsNullOrWhiteSpace(keywordLine) && keywordLine.Split(',').Length == 3 &&
                   keywordLine.Split(',')[1].OnlyHexInString() && bool.TryParse(keywordLine.Split(',')[2], out doNotHaveCsharpSevenDot0);
        }

        /// <summary>
        /// Some validation if the string is a hexvalue.
        /// </summary>
        /// <param name="test">The stirng to test about being hex.</param>
        /// <returns>true: The value is a hexvalue; false: The value is not a hexvalue</returns>
        public static bool OnlyHexInString (this string test)
        {
            // For C-style hex notation (0xFF) you can use @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z"
            return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
        }
    }
}