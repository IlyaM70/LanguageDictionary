using System;
using System.Collections.Generic;


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
                            FileManager.Replace(file, path, dictionary);
                            break;


                        case "2":
                            word = ConsoleApp.GetWord();
                            choise = ConsoleApp.Menu2(true);
                            switch (choise)
                            {
                                case "1":
                                    translations = dictionary[word];
                                    dictionary.Remove(word);
                                    word = ConsoleApp.GetWord();
                                    dictionary.Add(word, translations);
                                    break;

                                case "2":
                                    dictionary.Remove(word);
                                    tranlate = ConsoleApp.GetTranslate(false);
                                    translations = new List<string>();
                                    translations.Add(tranlate);
                                    dictionary.Add(word, translations);
                                    dictionary = DictionaryManager.MoreTranslations(dictionary, word, translations);
                                    break;
                            }

                            FileManager.Replace(file, path, dictionary);
                            break;

                        case "3":
                            word = ConsoleApp.GetWord();
                            tranlate = ConsoleApp.GetTranslate(false);
                            choise = ConsoleApp.Menu2(false);


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
                            DictionaryManager.FindTranslate(dictionary,false);
                            break;
                        case "5":
                            DictionaryManager.FindTranslate(dictionary,true);
                            break;

                    }

                    break;

                case "0":
                    break;
            }
           

            

        }
    }
}
