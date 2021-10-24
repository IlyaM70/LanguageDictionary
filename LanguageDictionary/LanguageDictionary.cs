using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LanguageDictionary
{
    public class LanguageDictionary
    {
        
        public LanguageDictionary(string languageFrom,string languageTo)
        {
            var languageDictionary = new Dictionary<string, List<string>>();
            string jsonString = JsonSerializer.Serialize(languageDictionary);
            File.WriteAllText($"{Environment.CurrentDirectory}/dictionaries/{languageFrom}-{languageTo}.json", jsonString);
        }
    }
}
