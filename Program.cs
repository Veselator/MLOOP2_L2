using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLOOP2_L2
{
    internal class Program
    {
        public const string TITLE = "Лабораторна робота №2.1";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            FileManager mainFileManager = new FileManager();
            bool isRunning = true;

            do
            {
                WriteTitle();
                WriteMenu(mainFileManager);

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine(" Неможливо зчитати вибір.");
                }
                else if (choice == 0)
                {
                    isRunning = false;
                }
                else if (choice < 0 || choice > mainFileManager.FileCount)
                {
                    Console.WriteLine(" Ваш вибір знаходиться поза межами допустимого діапазону.");
                }
                else
                {
                    Console.WriteLine(mainFileManager.GetFile(choice - 1));
                }

                if (isRunning)
                {
                    Console.Write("\n Натисніть будь-яку клавішу для продовження...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while(isRunning);
        }

        private static void WriteTitle()
        {
            Console.WriteLine($"\n === {TITLE} ===\n");
        }

        private static void WriteMenu(FileManager fileManager)
        {
            Console.WriteLine(" Виберіть файл, із яким бажаєте працювати (0 - вихід)");
            Console.WriteLine(fileManager.ToString());

            Console.Write(" > ");
        }
    }
}
