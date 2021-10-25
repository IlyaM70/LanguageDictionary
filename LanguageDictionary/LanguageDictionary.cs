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
        
        public LanguageDictionary(string languageFrom,string languageTo, string path)
        {
            var languageDictionary = new Dictionary<string, List<string>>();
            string jsonString = JsonSerializer.Serialize(languageDictionary);
            File.WriteAllText(@$"{path}\{languageFrom}-{languageTo}.json", jsonString);
        }
    }
}
