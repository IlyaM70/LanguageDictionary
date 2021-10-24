using System;

namespace LanguageDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
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
                    Console.WriteLine("Напишите с какого языка будет осуществляться перевод(на русском, начиная с заглавной буквы)");
                    var languageFrom = Console.ReadLine();
                    Console.WriteLine("Напишите на какой язык будет осуществляться перевод(на русском, начиная с заглавной буквы)");
                    var languageTo = Console.ReadLine();
                    var languageDictionary = new LanguageDictionary(languageFrom,languageTo);
                    break;
                case "2":
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
