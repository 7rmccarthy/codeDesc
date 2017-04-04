using System;
using System.Linq;
using LanguageLoadingManager;

namespace Testing
{
    internal class Program
    {
        private const string ExampleCode = @"test test2  abcsfdkjösdklj   test3";

        public static void Main(string[] args)
        {
            Console.Title = "Testing";

            LLM.Initialize();
            LLM.Reload("example", "*.txt");

            Console.WriteLine();
            Console.WriteLine(LLM.LanguagePacks[LLM.LanguagePacks.Keys.First()].ApplyOnString(ExampleCode));

            Console.ReadKey(true);
        }
    }
}