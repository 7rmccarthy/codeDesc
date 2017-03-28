#region License

// Copyright (c) 2017, Vira
// All rights reserved.
// Solution: LanguageLoadingManager
// Project: LanguageLoadingManager
// Filename: LanguagePack.cs
// Date - created:2017.03.28 - 18:45
// Date - current: 2017.03.28 - 19:24

#endregion

#region Usings

using System.Collections.Generic;
using System.IO;

#endregion

namespace LanguageLoadingManager
{
    /// <summary>
    ///     The Language pack represents a programming language.
    /// </summary>
    public class LanguagePack
    {
        /// <summary>
        ///     The file extension of this language pack.
        /// </summary>
        public readonly string Extension;

        /// <summary>
        ///     All keywords are stored inside here.
        /// </summary>
        public readonly List<Keyword> Keywords;

        /// <summary>
        ///     The name of the language pack.
        /// </summary>
        public readonly string Name;

        public LanguagePack(string name, string extension, List<Keyword> keywords)
        {
            Name = name;
            Extension = extension;
            Keywords = keywords;
        }

        /// <summary>
        ///     Loads a language pack from an excel file.
        /// </summary>
        /// <param name="file">The excel file containing the keywords</param>
        /// <returns>This method returns the gathered data inside a generated language pack.</returns>
        public static LanguagePack LoadFromFile(string file)
        {
            if (!File.Exists(file)) throw new FileNotFoundException();

            var extension = Path.GetExtension(file);
            var name = Path.GetFileNameWithoutExtension(file);
            var words = new List<Keyword>(); // TODO: read excel file

            //// TEMP!!!
            words.Add(new Keyword("0000FFFF", "test"));
            words.Add(new Keyword("00FF00FF", "test2", false));
            words.Add(new Keyword("FF0000FF", "test3"));

            return new LanguagePack(name, extension, words);
        }
    }
}