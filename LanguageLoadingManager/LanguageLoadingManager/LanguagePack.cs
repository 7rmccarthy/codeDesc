using System.Collections.Generic;

namespace LanguageLoadingManager
{
    public class LanguagePack
    {
        public readonly string Name;
        public readonly string Extension;
        public readonly List<Keyword> Keywords;

        public static LanguagePack LoadFromFile(string file)
        {
            return null;
        }

        public LanguagePack(string name, string extension, List<Keyword> keywords)
        {
            Name = name;
            Extension = extension;
            Keywords = keywords;
        }
    }
}