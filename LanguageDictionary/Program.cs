using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;

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

                    ///// get file
                    FileManager.GetFileList(path);
                    Console.WriteLine("Введите имя файла");
                    var file = Console.ReadLine();
                    var filePath = @$"{path}\{file}";
                    //Console.WriteLine(filePath);

                    //// get dictionary
                    var dictionary = FileManager.Read(filePath);

                    /// get word and tranlations
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
                            dictionary.Add(word, translations);
                        }
                        else
                        {
                            translations.Add(tranlate);
                            dictionary.Add(word, translations);
                        }
                    }
                    //Console.WriteLine(dictionary);
                    FileManager.Replace(file, path, dictionary);
                    break;

                    
                case "3":
                    FileManager.GetFileList(path);
                    Console.WriteLine("Введите имя файла");
                    file = Console.ReadLine();
                    filePath = @$"{path}\{file}";

                    dictionary = FileManager.Read(filePath);


                    Console.WriteLine("Введите слово");
                    word = Console.ReadLine();

                    Console.WriteLine("Выберите вариант");
                    Console.WriteLine("1.Заменить слово");
                    Console.WriteLine("2.Заменить перевод слова");
                    choise = Console.ReadLine();
                    

                    switch (choise)
                    {
                        case "1":
                            translations = dictionary[word];
                            dictionary.Remove(word);
                            Console.WriteLine("Введите новое слово");
                            word = Console.ReadLine();
                            dictionary.Add(word, translations);
                            break;

                        case "2":
                            dictionary.Remove(word);
                            Console.WriteLine("Введите новый перевод");
                            tranlate = Console.ReadLine();
                            translations = new List<string>();
                            translations.Add(tranlate);
                            flag = true;
                            while (flag)
                            {
                                Console.WriteLine("Напишите дополнительный перевод или 0 для выхода");
                                tranlate = Console.ReadLine();
                                if (tranlate == "0")
                                {
                                    flag = false;
                                    dictionary.Add(word, translations);
                                }
                                else
                                {
                                    translations.Add(tranlate);
                                    dictionary.Add(word, translations);
                                }
                            }
                            break;
                    }

                    FileManager.Replace(file, path, dictionary);
                    break;

                case "4":
                    ///// get file
                    FileManager.GetFileList(path);
                    Console.WriteLine("Введите имя файла");
                    file = Console.ReadLine();
                    filePath = @$"{path}\{file}";
                    

                    //// get dictionary
                    dictionary = FileManager.Read(filePath);

                    Console.WriteLine("Введите слово");
                    word = Console.ReadLine();

                    Console.WriteLine("Выберите вариант");
                    Console.WriteLine("1.Удалить слово");
                    Console.WriteLine("2.Удалить перевод слова");
                    choise = Console.ReadLine();


                    switch (choise)
                    {
                        case "1":
                            dictionary.Remove(word);
                            break;

                        case "2":
                            dictionary.Remove(word);
                            translations = new List<string>();
                            dictionary.Add(word, translations);
                            break;
                    }

                    FileManager.Replace(file, path, dictionary);
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
