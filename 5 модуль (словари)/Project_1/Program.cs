using System;
using System.Collections.Generic;

namespace Project_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string AddNewWord = "addnewword";
            const string PrintAllDictionary = "printalldictionary";
            const string PrintMeaningWord = "printmeaningword";
            const string Exit = "exit";

            string command;
            bool isExitProgram = false;
            Dictionary<string, string> glossary = new Dictionary<string, string>();

            while (isExitProgram == false)
            {
                Console.WriteLine("\nвыбирите действие:");
                Console.WriteLine($"1.{AddNewWord}");
                Console.WriteLine($"2.{PrintMeaningWord}");
                Console.WriteLine($"3.{PrintAllDictionary}");
                Console.WriteLine($"4.{Exit}");
                Console.Write("Введите команду - ");
                command = Console.ReadLine();
                
                switch (command.ToLower())
                {
                    case AddNewWord:
                        AddNew(glossary);
                        break;

                    case PrintMeaningWord:
                        DerivingMeaningWord(glossary);
                        break;

                    case PrintAllDictionary:
                        SearchAndOutputWord(glossary);
                        break;

                    case Exit:
                        isExitProgram = true;
                        break;

                    default:
                        Console.WriteLine($"{command} - такой команды нет.");
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

        static void AddNew(Dictionary<string, string> glossary)
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

        static void SearchAndOutputWord(Dictionary<string,string> glossary)
        {
            foreach (var word in glossary)
            {
                Console.WriteLine($"слово {word.Key} означает {word.Value}");
            }
            Console.Write("\n");
        }

        static void DerivingMeaningWord(Dictionary<string, string> glossary)
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