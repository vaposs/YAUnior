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
            const string AddWord = "addword";
            const string PrintAll = "printall";
            const string PrintWord = "printone";
            const string Exit = "exit";

            string command;
            bool isExitProgram = false;
            Dictionary<string, string> glossary = new Dictionary<string, string>();

            while (isExitProgram == false)
            {
                Console.WriteLine("\nвыбирите действие:");
                Console.WriteLine($"1.{AddWord}");
                Console.WriteLine($"2.{PrintWord}");
                Console.WriteLine($"3.{PrintAll}");
                Console.WriteLine($"4.{Exit}");
                Console.Write("Введите команду - ");
                command = Console.ReadLine();
                
                switch (command.ToLower())
                {
                    case AddWord:
                        AddWordMethod(glossary);
                        break;

                    case PrintWord:
                        PrintOneWordMethod(glossary);
                        break;

                    case PrintAll:
                        PrintDictionaryMethod(glossary);
                        break;

                    case Exit:
                        isExitProgram = true;
                        break;
                }
            }
        }

        static string TakeWord()
        {
            string templWord;

            Console.Write("Введите слово - ");
            templWord = Console.ReadLine();

            return templWord;
        }

        static void AddWordMethod(Dictionary<string, string> glossary)
        {
            string word = TakeWord();
            bool wordIsRepeat = glossary.ContainsKey(word);

            if (wordIsRepeat)
            {
                Console.Write("\nПовтор, такое слово уже есть.");
            }
            else
            {
                Console.Write("Введите значение слова - ");
                glossary.Add(word, Console.ReadLine());
            }
        }

        static void PrintDictionaryMethod(Dictionary<string,string> glossary)
        {
            foreach (var word in glossary)
            {
                Console.WriteLine($"слово {word.Key} означает {word.Value}");
            }
            Console.Write("\n");
        }

        static void PrintOneWordMethod(Dictionary<string, string> glossary)
        {
            string word;

            if(glossary.Count == 0)
            {
                Console.WriteLine("Словарь пустой");
            }
            else
            {
                word = TakeWord();

                if (glossary.ContainsKey(word))
                {
                    Console.WriteLine($"слово {word} означает {glossary[word]}");
                }
                else
                {
                    Console.WriteLine("Такого слова нету в словаре.");
                }
            }
        }
    }
}