using System;
using System.CodeDom.Compiler;
using System.Collections.Specialized;

namespace Project_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string AddDossierCommand = "add";
            const string PrintDossierCommand = "print";
            const string DeleteDossierCommand = "delete";
            const string SeachDossierCommand = "seach";
            const string ExitProgramCommand = "exit";

            string[] name = new string[0];
            string[] profession = new string[0];
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"Введите команду \n");
                Console.WriteLine($"1.{AddDossierCommand}");
                Console.WriteLine($"2.{PrintDossierCommand}");
                Console.WriteLine($"3.{DeleteDossierCommand}");
                Console.WriteLine($"4.{SeachDossierCommand}");
                Console.WriteLine($"5.{ExitProgramCommand}");

                Console.Write("\nВведите команду - ");

                string command;

                command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case AddDossierCommand:
                        AddDossier(ref name,ref profession);
                        break;

                    case PrintDossierCommand:
                        PrintDossier(name, profession);
                        break;

                    case DeleteDossierCommand:
                        DeleteDossier(ref name, ref profession);
                        break;

                    case SeachDossierCommand:
                        SeachDossier(name, profession);
                        break;

                    case ExitProgramCommand:
                        isWork = false;
                        break;
                }
            }
        }

        static void AddDossier(ref string[] name,ref string[] profession)
        {
            Console.Write("Введите ФИО: ");
            AddElement(ref name);
            Console.Write("Введите професию: ");
            AddElement(ref profession);
        }

        static void PrintDossier(string[] name, string[] profession)   
        {
            PrintFirstLine();

            for (int i = 0; i < name.Length; i ++)
            {
                Console.Write($"{i+1}.");
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
            int number;
            bool isSuccess;
            bool isConversionSucceeded = true;

            if (name.Length == 0)
            {
                Console.Write("список досье пустой");
            }
            else
            {
                while (isConversionSucceeded)
                {
                    Console.WriteLine("Введите номер досье для удаления: ");
                    deleteDossierString = Console.ReadLine();
                    isSuccess = int.TryParse(deleteDossierString, out number);
                    deleteDossierInt = Convert.ToInt32(deleteDossierString);

                    if (isSuccess && deleteDossierInt > 0)
                    {
                        if (deleteDossierInt > name.Length)
                        {
                            Console.WriteLine("номер больше чем количество досье");
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

                DeleteElement(ref name, deleteDossierInt);
                DeleteElement(ref profession, deleteDossierInt);
                Console.WriteLine("Досье удалено.");
            }
        }

        static void SeachDossier(string[] name, string[] profession)
        {
            int fioSize = 5;
            string seachDossier;
            string tempLine;
            string[] seachLine = new string[fioSize];
            char lineDivider = ' ';
            
            if (name.Length == 0)
            {
                Console.WriteLine("Список досье пустой.");
            }
            else
            {
                Console.Write("Введите фамилию с досье для поиска: ");
                seachDossier = Console.ReadLine();

                for (int i = 0; i < name.Length; i ++)
                {
                    tempLine = name[i];
                    seachLine = tempLine.Split(lineDivider);

                    if (seachDossier == seachLine[0])
                    {
                        PrintFirstLine();
                        Console.Write($"{i+1}.");
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

        static void AddElement(ref string[] array)
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

        static void DeleteElement(ref string[] array, int numberDeleteElement)
        {
            string[] tempArray = new string[array.Length - 1];
            numberDeleteElement--;

            for (int i = 0; i < numberDeleteElement; i++)
            {
                tempArray[i] = array[i];
            }

            for(int i = numberDeleteElement; i < array.Length - 1; i++)
            {
                tempArray[i] = array[i + 1];
            }

            array = tempArray;
        }
    }
}