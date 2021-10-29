using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;


namespace LanguageDictionary
{
    public static class FileManager
    {
        public static void GetFileList(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] Files = directory.GetFiles();
            foreach (FileInfo file in Files)
            {
                Console.WriteLine(file.Name);
            }
        }

        //public static void Write(string file, string path, string word, List<string> translations)
        //{
        //    var languageDictionary = new Dictionary<string, List<string>>()
        //    {
        //        { word,translations}
        //    };
        //    var options = new JsonSerializerOptions
        //    {
        //        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        //        WriteIndented = true,
        //        AllowTrailingCommas = true
        //    };
        //    string jsonString = System.Text.Json.JsonSerializer.Serialize(languageDictionary, options);
        //    //string jsonString = JsonConvert.SerializeObject(languageDictionary, Formatting.Indented);

        //    //Console.WriteLine(jsonString);
        //    File.AppendAllText(@$"{path}\{file}", jsonString);
        //}

        public static Dictionary<string, List<string>> Read (string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            var dictionary = new Dictionary<string, List<string>>();
            return dictionary = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, List<string>>>(jsonString);
            //return dictionary = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(jsonString);
        }

        public static void Replace(string file, string path, Dictionary<string, List<string>> dictionary )
        {
            
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true,
                AllowTrailingCommas = true
            };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(dictionary, options);
            //string jsonString = JsonConvert.SerializeObject(languageDictionary, Formatting.Indented);
            //Console.WriteLine(jsonString);
            File.WriteAllText(@$"{path}\{file}", jsonString);
        }

        


    }
}
