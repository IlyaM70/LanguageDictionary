using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageDictionary
{
    public static class ConsoleApp
    {
        public static string MainMenu()
        {
            Console.WriteLine("Словарь разных языков");
            Console.WriteLine("Выберите действие");
            Console.WriteLine("1.Создать словарь");
            Console.WriteLine("2.Выполнить действие со словарем");
            Console.WriteLine("0.Выйти");
            var choise = Console.ReadLine();
            return choise;
        }

        public static string GetLanguageFrom()
        {
            Console.WriteLine("Напишите с какого языка будет осуществляться перевод");
            var languageFrom = Console.ReadLine();
            return languageFrom;
        }
        public static string GetLanguageTo()
        {
            Console.WriteLine("Напишите на какой язык будет осуществляться перевод");
            var languageTo = Console.ReadLine();
            return languageTo;
        }

        public static string GetFile()
        {
            Console.WriteLine("Введите имя файла");
            var file = Console.ReadLine();
            return file;
        }

        public static string Menu1()
        {
            Console.WriteLine("Выберите действие");
            Console.WriteLine("1.Добавить слово и перевод в существующий словарь");
            Console.WriteLine("2.Заменить слово или его перевод в словаре");
            Console.WriteLine("3.Удалить слово или его перевод в словаре");
            Console.WriteLine("4.Искать перевод слова");
            Console.WriteLine("5.Записать слово и его перевод в файл");
            var choise = Console.ReadLine();
            return choise;
        }

        public static string GetWord()
        {
            Console.WriteLine("Введите слово");
            var word = Console.ReadLine();
            return word;
        }
        public static string GetTranslate(bool isAddition)
        {
            if (isAddition == false)
            {
                Console.WriteLine("Введите перевод");
            }
            else
            {
                Console.WriteLine("Введите дополнительный перевод или 0 для выхода");
            }
            var translate = Console.ReadLine();
            return translate;
        }
    }
}
