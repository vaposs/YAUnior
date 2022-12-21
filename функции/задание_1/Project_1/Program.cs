using System;
using System.CodeDom.Compiler;

namespace Project_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string addDossier = "add";
            const string printDossier = "print";
            const string deleteDossier = "delete";
            const string seachDossier = "seach";
            const string exitProgram = "exit";
            int sizeArray = 1;
            string[] name = new string[sizeArray];
            string[] profession = new string[sizeArray];
            string command;
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"Введите команду \n1.{addDossier}\n2.{printDossier}\n3.{deleteDossier}\n4.{seachDossier}\n5.{exitProgram}");
                Console.Write("\nВведите команду - ");
                command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case addDossier:
                        AddDossier(ref name,ref profession);
                        break;
                    case printDossier:
                        PrintDossier(ref name, ref profession);
                        break;
                    case deleteDossier:
                        DeleteDossier(ref name, ref profession);
                        break;
                    case seachDossier:
                        SeachDossier(ref name, ref profession);
                        break;
                    case exitProgram:
                        isWork = false;
                        break;
                }
                Console.Clear();
            }
        }

        static void AddDossier(ref string[] name,ref string[] profession)
        {
            int sizeTempArray = 1;
            string tempString;
            string[] tempLine = new string[sizeTempArray];
            string[] tempName = new string[name.Length + 1];
            string[] tempProfession = new string[profession.Length + 1];
            int fio = 0;
            int profa = 1;
            bool fineLine = true;

            while (fineLine)
            {
                Console.Write("Введите фио и должность через дефис (-): ");
                tempString = Console.ReadLine();

                tempLine = tempString.Split('-');
                if (tempLine.Length <= 1)
                {
                    Console.Write("повторите ввод строки в формате 'ФИО - ПРОФЕСИЯ'\n");
                }
                else
                {
                    name[name.Length - 1] = tempLine[fio];
                    profession[profession.Length - 1] = tempLine[profa];
                    fineLine = false;
                }
            }
            for (int i = 0; i < name.Length; i++)
            {
                tempName[i] = name[i];
                tempProfession[i] = profession[i];
            }
            name = tempName;
            profession = tempProfession;
        }

        static void PrintDossier(ref string[] name, ref string[] profession)   
        {
            PrintFirstLine();

            for (int i = 0; i < name.Length - 1; i ++)
            {
                Console.Write($"{i + 1}.");
                Console.Write(name[i]);
                Console.Write(" - ");
                Console.Write(profession[i]);
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        static void DeleteDossier(ref string[] name, ref string[] profession)
        {
            string deleteDossierString;
            int deleteDossierInt = 0;
            string[] tempName = new string[name.Length - 1];
            string[] tempProfession = new string[profession.Length - 1];
            bool isConversionSucceeded = true;
            bool isSuccess;
            int number;

            if (name.Length == 1)
            {
                Console.WriteLine("Список досье пустой.");
            }
            else
            {
                while (isConversionSucceeded)
                {
                    Console.WriteLine("Введите номер досье для удаления: ");
                    deleteDossierString = Console.ReadLine();
                    isSuccess = int.TryParse(deleteDossierString, out number);

                    if (isSuccess)
                    {
                        deleteDossierInt = Convert.ToInt32(deleteDossierString) - 1;

                        if (deleteDossierInt > name.Length)
                        {
                            Console.WriteLine("Число больше количества досье.");
                        }
                        else
                        {
                            isConversionSucceeded = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод.");
                    }
                }

                for (int i = 0; i < tempName.Length; i++)
                {
                    if(i < deleteDossierInt)
                    {
                        tempName[i] = name[i];
                        tempProfession[i] = profession[i];
                    }
                    else if(i >= deleteDossierInt)
                    {
                        tempName[i] = name[i + 1];
                        tempProfession[i] = profession[i + 1];
                    }
                }
                Console.WriteLine("Досье удалено.");
            }
            name = tempName;
            profession = tempProfession;
            Console.ReadKey();
        }

        static void SeachDossier(ref string[] name, ref string[] profession)
        {
            int fioSize = 3;
            string seachDossier;
            string tempLine;
            bool notDossier = false;
            string[] seachLine = new string[fioSize];
            
            if (name.Length == 1)
            {
                Console.WriteLine("Список досье пустой.");
            }
            else
            {
                Console.Write("Введите фамилию с досье для поиска: ");
                seachDossier = Console.ReadLine();

                for (int i = 0; i < name.Length  - 1 ; i ++)
                {
                    tempLine = name[i];
                    seachLine = tempLine.Split(' ');

                    if (seachDossier == seachLine[0])
                    {
                        PrintFirstLine();
                        Console.Write($"{i + 1}.");
                        Console.Write(name[i]);
                        Console.Write(" - ");
                        Console.Write(profession[i] + "\n");
                    }
                }
            }
            Console.ReadKey();
        }

        static void PrintFirstLine()
        {
            Console.Write("№");
            Console.Write("    ФИО    ");
            Console.Write("   професия   \n");
        }
    }
}