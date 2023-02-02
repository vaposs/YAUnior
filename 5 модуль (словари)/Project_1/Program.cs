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
            const string Next = "next";
            const string Print = "print";
            const string Exit = "exit";

            string command;
            bool isExitProgram = true;
            Dictionary<string, string> glossary = new Dictionary<string, string>();

            while (isExitProgram)
            {
                Console.WriteLine("выбирите действие:");
                Console.WriteLine($"1.{Next}");
                Console.WriteLine($"2.{Print}");
                Console.WriteLine($"3.{Exit}");
                Console.Write("Введите команду - ");
                command = Console.ReadLine();
                Console.Clear();

                switch (command.ToLower())
                    {
                    case Next:
                        NextWord(glossary);
                        break;

                    case Print:
                        PrintDictionary(glossary);
                        break;

                    case Exit:
                        isExitProgram = false;
                        break;
                }
            }
        }

        static void NextWord(Dictionary<string, string> glossary)
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

        static void PrintDictionary( Dictionary<string,string> glossary)
        {
            foreach (var item in glossary)
            {
                Console.WriteLine($"слово {item.Key} означает {item.Value}");
            }
            Console.Write("\n");
        }
    }
}
