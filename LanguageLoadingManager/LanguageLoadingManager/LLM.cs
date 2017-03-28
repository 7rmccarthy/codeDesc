using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LanguageLoadingManager
{
    public static class LLM
    {
        public static void Initialize()
        {
            LanguagePacks = new Dictionary<string, LanguagePack>();
            IsInitialized = true;
        }

        public static void Reload(string directory, string searchPattern = "*.*")
        {
            if(!IsInitialized||!Directory.Exists(directory))return;

            Directory.GetFiles(directory, searchPattern)
                .ToList()
                .ForEach(
                    x=>
                        LanguagePacks.Add(
                            Path.GetExtension(x),
                            LanguagePack.LoadFromFile(x)
            ));
        }

        public static bool IsInitialized { get; private set; }
        public static Dictionary<string, LanguagePack> LanguagePacks;
    }
}