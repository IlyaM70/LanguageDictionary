using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;



namespace LanguageDictionary
{
    public static class FileManager
    {
        public static void Create(string languageFrom, string languageTo, string path)
        {
            var languageDictionary = new Dictionary<string, List<string>>();
            string jsonString = JsonSerializer.Serialize(languageDictionary);
            File.WriteAllText(@$"{path}\{languageFrom}-{languageTo}.json", jsonString);
        }
        public static void GetFileList(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] Files = directory.GetFiles();
            foreach (FileInfo file in Files)
            {
                Console.WriteLine(file.Name);
            }
        }
        
        public static Dictionary<string, List<string>> Read (string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Dictionary<string, List<string>>>(jsonString);
            
        }

        public static void Replace(string file, string path, Dictionary<string, List<string>> dictionary )
        {
            
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true,
                AllowTrailingCommas = true
            };
            string jsonString = JsonSerializer.Serialize(dictionary, options);
            File.WriteAllText(@$"{path}\{file}", jsonString);
        }

        


    }
}
