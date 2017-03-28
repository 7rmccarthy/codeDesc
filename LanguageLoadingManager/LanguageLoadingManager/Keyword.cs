#region License

// Copyright (c) 2017, Vira
// All rights reserved.
// Solution: LanguageLoadingManager
// Project: LanguageLoadingManager
// Filename: Keyword.cs
// Date - created:2017.03.28 - 18:45
// Date - current: 2017.03.28 - 19:24

#endregion

namespace LanguageLoadingManager
{
    /// <summary>
    ///     Represents text, which does have a special meaning.
    /// </summary>
    public struct Keyword
    {
        /// <summary>
        ///     The keyword itself.
        /// </summary>
        public readonly string Name;

        /// <summary>
        ///     The color, which this keyword should be colored in.
        /// </summary>
        public readonly string Color;

        /// <summary>
        ///     The regex code to find that keyword.
        /// </summary>
        public readonly string RegexCode;

        /// <summary>
        ///     true: the speciel word is the current one; false: the special word is the next one
        /// </summary>
        public readonly bool Current;

        /// <summary>
        ///     Initializes an instance of this class.
        /// </summary>
        /// <param name="name">The keyword itself.</param>
        /// <param name="color">The color, which this keyword should be colored in.</param>
        /// <param name="current">true: the speciel word is the current one; false: the special word is the next one</param>
        public Keyword(string name, string color, bool current = true)
        {
            Name = name;
            Color = color;
            Current = current;
            RegexCode = name.RegexFromString(current);
        }
    }
}