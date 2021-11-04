using System;
using System.Collections.Generic;
using System.IO;


namespace LanguageDictionary
{
    public static class DictionaryManager
    {
        public static Dictionary<string, List<string>> MoreTranslations(Dictionary<string, List<string>> dictionary, string word, List<string> translations)
        {
            var flag = true;
            while (flag)
            {

                var tranlate = ConsoleApp.GetTranslate(true);
                if (tranlate == "0")
                {
                    flag = false;
                    //dictionary.Add(word, translations);
                }
                else
                {
                    translations.Add(tranlate);
                    //dictionary.Add(word, translations);
                    dictionary.TryAdd(word, translations);
                }
            }
            return dictionary;
        }

        public static void FindTranslate( Dictionary<string, List<string>> dictionary, bool isExporting)
        {
            var word = ConsoleApp.GetWord();
            var translations = new List<string>();
            translations = dictionary.GetValueOrDefault(word);
            ConsoleApp.PrintTranslate(translations);

            if (isExporting == true)
            {
                File.WriteAllText($@"{Environment.CurrentDirectory}/перевод.txt", $"{word}:");
                foreach (var translate in translations)
                {
                    File.AppendAllText($@"{Environment.CurrentDirectory}/перевод.txt", $"{translate}, ");
                }
                Console.WriteLine("Перевод записан в перевод.txt");
            }
            
        }


    }
}
