using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security;

namespace Project_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string next = "next";
            const string print = "print";
            const string exit = "exit";

            string command;
            bool exitProgram = true;
            Dictionary<string, string> glossary = new Dictionary<string, string>();

            while (exitProgram)
            {
                Console.WriteLine("выбирите действие:");
                Console.WriteLine($"1.{next}");
                Console.WriteLine($"2.{print}");
                Console.WriteLine($"3.{exit}");
                Console.Write("Введите команду - ");
                command = Console.ReadLine();
                Console.Clear();

                switch (command.ToLower())
                    {
                    case next:
                        Next(ref glossary);
                        break;

                    case print:
                        Print(glossary);
                        break;

                    case exit:
                        exitProgram = false;
                        break;
                }
            }
        }

        static void Next(ref Dictionary<string, string> glossary)
        {
            string temporaryVariable;

            Console.Write("Введите слово - ");
            temporaryVariable = Console.ReadLine();

            if (glossary.ContainsKey(temporaryVariable))
            {
                Console.WriteLine($"слово {temporaryVariable} означает {glossary.Values}");
            }
            else
            {
                Console.Write("введите значения слова - ");
                glossary.Add(temporaryVariable, Console.ReadLine());
            }
        }

        static void Print( Dictionary<string,string> glossary)
        {
            foreach (var item in glossary)
            {
                Console.WriteLine($"слово {item.Key} означает {item.Value}");
            }
            Console.Write("\n");
        }
    }
}
