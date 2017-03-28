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
    }
}