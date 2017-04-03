#region License

// Copyright (c) 2017, Vira
// All rights reserved.
// Solution: LanguageLoadingManager
// Project: LanguageLoadingManager
// Filename: LLM.cs
// Date - created:2017.03.28 - 18:45
// Date - current: 2017.03.28 - 19:24

#endregion

#region Usings

using System.Collections.Generic;
using System.IO;
using System.Linq;

#endregion

namespace LanguageLoadingManager
{
    /// <summary>
    ///     The Language Loading Manager represents a manager, which handels the loading and saving of the language packs.
    /// </summary>
    public static class LLM
    {
        /// <summary>
        ///     A collection of all language packs.
        /// </summary>
        public static Dictionary<string, LanguagePack> LanguagePacks;

        /// <summary>
        ///     true: this manager got initialized; false: this manager has to get initialized
        /// </summary>
        public static bool IsInitialized { get; private set; }

        /// <summary>
        ///     Initializes this manager and its submembers.
        /// </summary>
        public static void Initialize()
        {
            LanguagePacks = new Dictionary<string, LanguagePack>();
            IsInitialized = true;
        }

        /// <summary>
        ///     (Re)loads all language packs.
        /// </summary>
        /// <param name="directory">The directory, where all the language packs are stored.</param>
        /// <param name="searchPattern">
        ///     Defines which files should get read. (Keep in mind that this algorithm does only work on
        ///     excel files!)
        /// </param>
        public static void Reload(string directory, string searchPattern = "*.csv")
        {
            if (!IsInitialized || !Directory.Exists(directory)) return;

            // Clear all data from before.
            LanguagePacks.Clear();

            // Load all data from the files:
            Directory.GetFiles(directory, searchPattern)
                .ToList()
                .ForEach(
                    x =>
                        LanguagePacks.Add(
                            Path.GetExtension(x),
                            LanguagePack.LoadFromFile(x)
                        ));
        }
    }
}