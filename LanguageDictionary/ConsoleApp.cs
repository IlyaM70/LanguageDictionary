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
    }
}
