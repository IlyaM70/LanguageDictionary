using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
