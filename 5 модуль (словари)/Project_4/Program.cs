using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Project_4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string AddDossierCommand = "add";
            const string PrintDossierCommand = "print";
            const string DeleteDossierCommand = "delete";
            const string ExitProgramCommand = "exit";

            Dictionary<string, string> dossier = new Dictionary<string, string>();
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"Введите команду \n");
                Console.WriteLine($"1.{AddDossierCommand}");
                Console.WriteLine($"2.{PrintDossierCommand}");
                Console.WriteLine($"3.{DeleteDossierCommand}");
                Console.WriteLine($"4.{ExitProgramCommand}");
                Console.Write("\nВведите команду - ");

                string command;

                command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case AddDossierCommand:
                        AddForDossier(dossier);
                        break;

                    case PrintDossierCommand:
                        PrintDossier(dossier);
                        break;

                    case DeleteDossierCommand:
                        DeleteDossier(dossier);
                        break;

                    case ExitProgramCommand:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Неверная команда");
                        break;
                }
            }
        }

        static void AddForDossier(Dictionary<string, string> dossier)
        {
            string tempProfesion = "";
            string tempName = "";

            Console.Write("Введите ФИО - ");
            tempName = Console.ReadLine();

            while (dossier.ContainsKey(tempName))
            {
                Console.Write("Такое ФИО уже есть, введите заново ФИО - ");
                tempName = Console.ReadLine();
            }

            Console.Write("Введите професию - ");
            tempProfesion = Console.ReadLine();
            dossier.Add(tempName, tempProfesion);
        }

        static void DeleteDossier(Dictionary<string, string> dossier)
        {
            if (dossier.Count == 0)
            {
                Console.WriteLine("Список досье пуст.");
            }
            else
            {
                string tempName;
                Console.Write("Введите ФИО досье для удаления - ");
                tempName = Console.ReadLine();

                if(dossier.Remove(tempName)== false)
                {
                    Console.WriteLine($"{tempName} - такого ФИО нет");
                }
                else
                {
                    Console.WriteLine("досье удалено");
                }
            }
        }

        static void PrintDossier(Dictionary<string, string> dossiers)
        {
            if(dossiers.Count == 0)
            {
                Console.WriteLine("Список досье пуст.");
            }
            else
            {
                PrintFirstLine();
                foreach (var dossier in dossiers)
                {
                    Console.WriteLine($"{dossier.Key} - {dossier.Value}");
                }
            }
        }

        static void PrintFirstLine()
        {
            Console.WriteLine("Професия     -       ФИО     ");
        }
    }
}
