using System;
using System.CodeDom.Compiler;
using System.Collections.Specialized;

namespace Project_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string AddDossier = "add";
            const string PrintDossier = "print";
            const string DeleteDossier = "delete";
            const string SeachDossier = "seach";
            const string ExitProgram = "exit";
            int sizeArray = 1;
            string[] name = new string[sizeArray];
            string[] profession = new string[sizeArray];
            string command;
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"Введите команду \n1.{AddDossier}\n2.{PrintDossier}\n3.{DeleteDossier}\n4.{SeachDossier}\n5.{ExitProgram}");
                Console.Write("\nВведите команду - ");
                command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case AddDossier:
                        AddDossierFunction(ref name,ref profession);
                        break;
                    case PrintDossier:
                        PrintDossierFunction(name, profession);
                        break;
                    case DeleteDossier:
                        DeleteDossierFunction(ref name, ref profession);
                        break;
                    case SeachDossier:
                        SeachDossierFunction(name, profession);
                        break;
                    case ExitProgram:
                        isWork = false;
                        break;
                }
                Console.Clear();
            }
        }

        static void AddDossierFunction(ref string[] name,ref string[] profession)
        {
            Console.Write("Введите ФИО: ");
            ArrayAdd(ref name);
            Console.Write("Введите професию: ");
            ArrayAdd(ref profession);
            for (int i = 0; i < name.Length - 1; i++)
            {
                Console.WriteLine(name[i]);
            }
        }

        static void PrintDossierFunction(string[] name, string[] profession)   
        {
            PrintFirstLine();

            for (int i = 1; i < name.Length; i ++)
            {
                Console.Write($"{i}.");
                Console.Write(name[i]);
                Console.Write(" - ");
                Console.Write(profession[i]);
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        static void DeleteDossierFunction(ref string[] name, ref string[] profession)
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

        static void SeachDossierFunction(string[] name, string[] profession)
        {
            int fioSize = 5;
            string seachDossier;
            string tempLine;
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
                        Console.Write($"{i}.");
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

        static void ArrayAdd(ref string[] array)
        {
            string[] tempArray = new string[array.Length + 1];

            string tempLine = Console.ReadLine();

            for (int i = 0; i < array.Length; i ++)
            {
                Console.WriteLine(tempArray[i]);
                tempArray[i] = array[i];
            }
            array = tempArray;
            array[array.Length - 1] = tempLine;
        }
    }
}