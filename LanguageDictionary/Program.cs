using System;
using System.Collections.Generic;
using System.IO;

namespace LanguageDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @$"{Environment.CurrentDirectory}\dictionaries";
            Console.WriteLine("Словарь разных языков");
            Console.WriteLine("Выберите действие");
            Console.WriteLine("1.Создать словарь");
            Console.WriteLine("2.Добавить слово и перевод в существующий словарь");
            Console.WriteLine("3.Заменить слово или его перевод в словаре");
            Console.WriteLine("4.Удалить слово или его перевод в словаре");
            Console.WriteLine("5.Искать перевод слова");
            Console.WriteLine("6.Записать слово и его перевод в файл");
            Console.WriteLine("0.Выйти");
            var choise = Console.ReadLine();

            

            switch (choise)
            {
                case "1":
                    Console.WriteLine("Напишите с какого языка будет осуществляться перевод");
                    var languageFrom = Console.ReadLine();
                    Console.WriteLine("Напишите на какой язык будет осуществляться перевод");
                    var languageTo = Console.ReadLine();
                    var languageDictionary = new LanguageDictionary(languageFrom,languageTo,path);
                    break;
                case "2":

                    FileManager.GetFileList(path);
                    Console.WriteLine("Введите имя файла");
                    var file = Console.ReadLine();
                    var filePath = @$"{path}\{file}";
                    Console.WriteLine(filePath);

                    Console.WriteLine("Напишите новое слово");
                    var word = Console.ReadLine();
                    Console.WriteLine("Напишите перевод");
                    var tranlate = Console.ReadLine();
                    var translations = new List<string>();
                    translations.Add(tranlate);
                    var flag = true;
                    while(flag)
                    {
                        Console.WriteLine("Напишите дополнительный перевод или 0 для выхода");
                        tranlate = Console.ReadLine();
                        if (tranlate == "0")
                        {
                            flag = false;
                        }
                        else
                        {
                            translations.Add(tranlate);
                            
                        }
                    }
                    FileManager.Write(file, path, word, translations);
                    break;

                    
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;
                case "0":
                    break;
                
            }

        }
    }
}
