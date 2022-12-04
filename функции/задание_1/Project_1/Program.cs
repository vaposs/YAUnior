using System;

namespace Project_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int column = 3;
            int line = 1;
            int number = 1;

            string[,] fullDossier = new string[line, column];
            const string addDossier = "add";
            const string printDossier = "print";
            const string deleteDossier = "delete";
            const string seachDossier = "seach";
            const string exitProgram = "exit";
            string command;
            bool isWork = true;

            FillFirstLine(fullDossier);

            while (isWork)
            {
                Console.WriteLine($"Введите команду \n1.{addDossier}\n2.{printDossier}\n3.{deleteDossier}\n4.{seachDossier}\n5.{exitProgram}");
                Console.Write("\nВведите команду - ");
                command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case addDossier:
                        AddDossier(ref fullDossier);
                        break;
                    case printDossier:
                        PrintDossier(fullDossier, number);
                        break;
                    case deleteDossier:
                        DeleteDossier(ref fullDossier);
                        break;
                    case seachDossier:
                        SeachDossier(fullDossier);
                        break;
                    case exitProgram:
                        isWork = false;
                        break;
                }
                Console.Clear();
            }
        }

        static void AddDossier(ref string[,] fullDossier)
        {
            Console.Write("введите Имя и Должность через пробел - ");
            string newDossier = Console.ReadLine();
            string[] word = newDossier.Split(' ');
            string[,] tempArray = new string[(fullDossier.GetLength(0) + 1), fullDossier.GetLength(1)];

            for (int i = 0; i < fullDossier.GetLength(0); i++)
            {
                for (int j = 0; j < fullDossier.GetLength(1); j++)
                {
                    tempArray[i, j] = fullDossier[i, j];
                }
            }
            fullDossier = tempArray;

            for (int i = 0; i < fullDossier.GetLength(0); i++)
            {
                for (int j = 0; j < fullDossier.GetLength(1); j++)
                {
                    if(i != 0 && j == 0)
                    {
                        fullDossier[i, j] =  Convert.ToString(i);
                    }
                    else if(j != 0)
                    {



                        fullDossier[fullDossier.GetLength(0)- 1, j] = word[j - 1];
                    }
                }
            }
        }

        static void PrintDossier(string[,] fullDossier, int number)
        {
            for (int i = 0; i < fullDossier.GetLength(0); i++)
            {
                for (int j = 0; j < fullDossier.GetLength(1); j++)
                {
                    Console.Write(fullDossier[i,j]);
                    Console.Write("      ");
                }
                Console.Write("\n");
            }
            Console.ReadKey();
        }

        static void DeleteDossier(ref string[,] fullDossier)
        {
            int deleteDossier;
            bool nextDosser = true;

            if (fullDossier.GetLength(0) <= 1)
            {
                Console.Write("в списке нету досье");
                Console.ReadKey();
            }
            else
            {
                Console.Write("Укажите номер строки для удаления - ");
                deleteDossier = Convert.ToInt32(Console.ReadLine());

                if (deleteDossier > fullDossier.GetLength(0) || deleteDossier < 1)
                {
                    Console.Write("Такого досье нету.");
                    Console.ReadKey();
                }
                else
                {
                    string[,] tempArray = new string[fullDossier.GetLength(0) - 1, fullDossier.GetLength(1)];

                    for (int i = 0; i < fullDossier.GetLength(0); i++)
                    {
                        if(i == deleteDossier && nextDosser == true)
                        {
                            i++;
                            nextDosser = false;
                        }
                        for (int j = 0; j < fullDossier.GetLength(1); j++)
                        {
                            if (nextDosser == false)
                            {
                                tempArray[i - 1, j] = fullDossier[i, j];
                            }
                            else
                            {
                                tempArray[i, j] = fullDossier[i, j];
                            }
                        }
                    }
                    fullDossier = tempArray;
                }
            }
        }

        static void SeachDossier(string[,] fullDossier)
        {
            bool founfDossier = false;

            Console.Write("Укажите имя искаемого досье - ");
            string findDossier = Console.ReadLine();

            for (int i = 0; i < fullDossier.GetLength(0); i++)
            {
                if (fullDossier[i, 1] == findDossier)
                {
                    for (int j = 0; j < fullDossier.GetLength(1); j++)
                    {
                        Console.Write(fullDossier[i,j] + "    ");
                        
                    }
                    founfDossier = true;
                    Console.ReadKey();
                }
            }

            if (founfDossier == false)
            {
                Console.WriteLine("досье с такой фамилией нету.");
                Console.ReadKey();
            }
        }

        static void FillFirstLine(string[,] fullDossier)
        {
            fullDossier[0, 0] = "№";
            fullDossier[0, 1] = "   ИМЯ";
            fullDossier[0, 2] = "   ДОЛЖНОСТЬ";
        }
    }
}