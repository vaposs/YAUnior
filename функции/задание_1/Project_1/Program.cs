using System;
using System.Collections.Specialized;

namespace Project_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int column = 3;
            int line = 1;
            int number = 1;

            string[,] fullDossier = new string[line,column];
            const string addDossier = "add";
            const string printDossier = "print";
            const string deleteDossier = "delete";
            const string seachDossier = "seach";
            const string exitProgram = "exit";
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
                        Console.Write("введите ФИО и должность через пробел - ");
                        string newDossier = Console.ReadLine();
                        string[] word = newDossier.Split(' ');
                        string[,] tempArray = new string[(fullDossier.GetLength(0) + 1), fullDossier.GetLength(1)];


                        break;





                        /*

                        
                        

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
                                fullDossier[fullDossier.GetLength(0) - 1, j] = word[j];
                            }
                        }
                        break;

                        */

                    case printDossier:
                        for (int i = 0; i < fullDossier.GetLength(0); i++)
                        {
                            for (int j = 0; j < fullDossier.GetLength(1); j++)
                            {
                                if(j == 0)
                                {
                                    fullDossier[i, j] = Convert.ToString(number);
                                    number++;

                                }
                                else if(i == 0 && j == 1)
                                {
                                    Console.Write(" ФИО - ");
                                }
                                else if(i == 0 && j == 2)
                                {
                                    Console.Write("ДОЛЖНОСТЬ");
                                }
                                else if(j == fullDossier.GetLength(1) - 1)
                                {
                                    Console.Write(fullDossier[i, j]);
                                }
                                else
                                {
                                    Console.Write(fullDossier[i, j] + " - ");
                                }
                            }
                            Console.Write("\n");
                        }
                        break;
                    case deleteDossier://удалить выбрано досье
                        break;
                    case seachDossier:
                        Console.Write("Укажите ФИО искаемого досье - ");
                        string findDossier = Console.ReadLine();
                        string[] dossier = findDossier.Split(' ');

                        for (int i = 0; i < fullDossier.GetLength(0); i++)
                        {
                            if(fullDossier[i,0] == dossier[i])
                            {

                            }
                        }

                        break;
                    case exitProgram:
                        isWork = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine("Hello World!");
        }
    }
}
