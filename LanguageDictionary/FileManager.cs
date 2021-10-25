using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

        public static void Write(string file, string path, string word, List<string> translations)
        {
            var languageDictionary = new Dictionary<string, List<string>>()
            {
                { word,translations}
            };
            string jsonString = JsonSerializer.Serialize(languageDictionary);
            Console.WriteLine(jsonString);
            File.AppendAllText(@$"{path}\{file}", jsonString, Encoding.Unicode);
        }


    }
}
