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
using System.Linq;
using System.Text.RegularExpressions;

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
        /// Applies the regex of the language pack on the code/text.
        /// </summary>
        /// <param name="toAlter">The text, that needs to get altered for the visualisation.</param>
        /// <returns>Returns the altered code containing color codes.</returns>
        public string ApplyOnString(string toAlter)
        {
            Keywords.ForEach(x=>toAlter = x.ApplyOnString(toAlter));

            return toAlter;
        }

        /// <summary>
        ///     Loads a language pack from an excel file.
        /// </summary>
        /// <param name="file">The excel file containing the keywords</param>
        /// <returns>This method returns the gathered data inside a generated language pack.</returns>
        public static LanguagePack LoadFromFile(string file)
        {
            if (!File.Exists(file)) throw new FileNotFoundException();

            var words = new List<Keyword>();
            string programmingLanguage;
            string extension;

            using (var reader = new StreamReader(file))
            {
                var heading = reader.ReadLine();
                programmingLanguage = heading.Split(',')[0];
                extension = heading.Split(',')[1];

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#") || !line.IsValid())
                    {
                        continue;
                    }

                    words.Add(new Keyword(
                        line.Split(',')[0],
                        line.Split(',')[1],
                        bool.Parse(line.Split(',')[2])
                    ));
                }
            }

            return new LanguagePack(programmingLanguage, extension, words);
        }
    }
}