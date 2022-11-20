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
                        AddDossier(fullDossier);
                        break;
                    case printDossier:
                        PrintDossier(fullDossier, number);
                        break;
                    case deleteDossier:
                        DeleteDossier();
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

        static void AddDossier(string[,] fullDossier)
        {
            Console.Write("введите ФИО и должность через пробел - ");
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


                    fullDossier[fullDossier.GetLength(0), j] = word[j];
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
                }
                Console.Write("\n");
            }
        }

        static void DeleteDossier()
        {

        }

        static void SeachDossier(string[,] fullDossier)
        {
            Console.Write("Укажите ФИО искаемого досье - ");
            string findDossier = Console.ReadLine();
            string[] dossier = findDossier.Split(' ');

            for (int i = 0; i < fullDossier.GetLength(0); i++)
            {
                if (fullDossier[i, 0] == dossier[i])
                {

                }
            }
        }

        static void FillFirstLine(string[,] fullDossier)
        {
            fullDossier[0, 0] = " №_";
            fullDossier[0, 1] = "_фамилия/имя/отчество_";
            fullDossier[0, 2] = "_ДОЛЖНОСТЬ";
        }
    }
}
