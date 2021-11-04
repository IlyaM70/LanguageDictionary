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
            var choise = ConsoleApp.MainMenu();
            switch (choise)
            {
                case "1":
                    var languageFrom = ConsoleApp.GetLanguageFrom();
                    var languageTo = ConsoleApp.GetLanguageTo();
                    FileManager.Create(languageFrom, languageTo, path);
                    break;
                case "2":
                    ///// get file
                    FileManager.GetFileList(path);
                    var file = ConsoleApp.GetFile();
                    var filePath = @$"{path}\{file}";
                    //// get dictionary
                    var dictionary = FileManager.Read(filePath);

                    choise = ConsoleApp.Menu1();
                    switch (choise)
                    {
                        case "1":
                            /// get word and tranlations
                            var word = ConsoleApp.GetWord();
                            var tranlate = ConsoleApp.GetTranslate(false);
                            var translations = new List<string>();
                            translations.Add(tranlate);
                            dictionary.Add(word, translations);
                            dictionary = DictionaryManager.MoreTranslations(dictionary, word, translations);
                            //Console.WriteLine(dictionary);
                            FileManager.Replace(file, path, dictionary);
                            break;


                        case "2":
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
                                    var flag = true;
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

                        case "3":
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

                        case "4":

                            Console.WriteLine("Введите слово");
                            word = Console.ReadLine();
                            translations = new List<string>();
                            translations = dictionary.GetValueOrDefault(word);

                            Console.WriteLine("Перевод:");
                            foreach (var translate in translations)
                            {
                                Console.WriteLine(translate);
                            }

                            break;
                        case "5":
                                               
                            Console.WriteLine("Введите слово");
                            word = Console.ReadLine();
                            translations = new List<string>();
                            translations = dictionary.GetValueOrDefault(word);

                            Console.WriteLine("Перевод:");
                            foreach (var translate in translations)
                            {
                                Console.WriteLine(translate);
                            }

                            File.WriteAllText($@"{Environment.CurrentDirectory}/перевод.txt", $"{word}:");
                            foreach (var translate in translations)
                            {
                                File.AppendAllText($@"{Environment.CurrentDirectory}/перевод.txt", $"{translate}, ");
                            }
                            Console.WriteLine("Перевод записан в перевод.txt");

                            break;


                    }

                    break;

                case "0":
                    break;
            }
           

            

        }
    }
}
