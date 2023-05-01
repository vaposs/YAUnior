using System;
using System.Collections.Generic;

namespace Project_3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string addPlayerCommand = "add";
            const string changeStatusPlayerCommand = "change";
            const string deletePlayerCommand = "delete";
            const string printPlayerCommand = "print"; 
            const string exitProgramCommand = "exit";

            int many_players = 0;
            Player[] basePlayers = new Player[many_players];
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"1.{addPlayerCommand}");
                Console.WriteLine($"2.{changeStatusPlayerCommand}");
                Console.WriteLine($"3.{deletePlayerCommand}");
                Console.WriteLine($"4.{printPlayerCommand}");
                Console.WriteLine($"5.{exitProgramCommand}");

                Console.Write($"Введите команду - ");

                string command;

                command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case addPlayerCommand:
                        AddPlayer(ref basePlayers);
                        break;

                    case changeStatusPlayerCommand:
                        ChangeStatus(ref basePlayers);
                        break;

                    case deletePlayerCommand:
                        DeletePlayer(ref basePlayers);
                        break;

                    case printPlayerCommand:
                        PrintBasePlayer(ref basePlayers);
                        break;

                    case exitProgramCommand:
                        isWork = false;
                        break;
                }
            }
        }

        static void AddPlayer(ref Player[] basePlayers)
        {
            int number = UniqueNumber();
            string name = UniqueName();
            int lvl = 1;
            bool ban = false;

            AddElement(ref basePlayers, number, name, lvl, ban);
        }

        static void ChangeStatus(ref Player[] basePlayers)
        {
            bool changeStatusBar = true;
            int changeIdentifier;

            Console.Write("Введите индификатор игрока для бана/розбана: ");
            changeIdentifier = GetNumber();

            for (int i = 0; i < basePlayers.Length; i++)
            {
                if (changeIdentifier == basePlayers[i].GetIndifikator())
                {
                    if (basePlayers[i].GetStatusBan() == false)
                    {
                        basePlayers[i].Ban = true;
                        changeStatusBar = false;
                    }
                    else
                    {
                        basePlayers[i].Ban = false;
                        changeStatusBar = false;
                    }
                }
            }
            if(changeStatusBar)
            {
                Console.WriteLine("Такого игрока нету");
            }
        }

        static void DeletePlayer(ref Player[] basePlayers)
        {
            bool deleteStatus = true;
            int deletionIdentifier;

            if (basePlayers.Length == 0)
            {
                Console.WriteLine("список игроков пустой");
            }
            else
            {
                Console.Write("Введите индификатор игрока для удаления: ");
                deletionIdentifier = GetNumber();

                for (int i = 0; i < basePlayers.Length; i++)
                {
                    if (deletionIdentifier == basePlayers[i].GetIndifikator())
                    {
                        int deletePlayerNumber = i;
                        DeleteElement( ref basePlayers, deletePlayerNumber);
                        deleteStatus = false;
                    }
                }
                if (deleteStatus)
                {
                    Console.WriteLine("Такого игрока нету");
                }
            }
        }

        static void DeleteElement(ref Player[] array, int numberDeleteElement)
        {
            Player[] tempArray = new Player[array.Length - 1];

            for (int i = 0; i < numberDeleteElement; i++)
            {
                tempArray[i] = array[i];
            }

            for (int i = numberDeleteElement; i < array.Length - 1; i++)
            {
                tempArray[i] = array[i + 1];
            }
            array = tempArray;
        }       

        static void PrintBasePlayer(ref Player[] basePlayer)
        {
            PrintFirstLine();

            for (int i = 0; i < basePlayer.Length; i++)
            {
                basePlayer[i].Print();
            }
        }

        static void AddElement(ref Player[] array, int number, string name, int lvl, bool ban)
        {
            Player[] tempArray = new Player[array.Length + 1];
            Player player = new Player(number, name, lvl, ban);

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            array = tempArray;
            array[array.Length - 1] = player;
        }

        static int GetNumber()
        {
            string line;
            bool isConversionSucceeded = true;
            bool isSuccess;
            int number = 0;

            while (isConversionSucceeded)
            {
                line = Console.ReadLine();
                isSuccess = int.TryParse(line, out number);

                if (isSuccess)
                {
                    if (number < 0)
                    {
                        Console.Write("Неверный ввод. Число меньше нуля.");

                    }
                    else
                    {
                        isConversionSucceeded = false;
                    }
                }
                else
                {
                    Console.Write("Неверный ввод.");
                }
            }

            return number;
        }

        static public int UniqueNumber()
        {
            Random random_number = new Random();

            return random_number.Next();
        }

        static void PrintFirstLine()
        {
            Console.WriteLine("уникальный номер   |     имя      |    лвл    |    бан(true/false)    ");
        }

        static public string UniqueName()
        {
            int numberNames = 44;
            int number = UniqueNumber() % numberNames;

            List<string> name = new List<string>() {
                "илья", "олег", "джон", "марк", "ефим",
                "яков", "отто", "аким", "адам", "лука",
                "инна", "клим", "наум", "глеб", "осип",
                "юлий", "фома", "арон", "роза", "ваня",
                "арам", "влас", "иуда", "боян", "лавр",
                "коля", "фрол", "женя", "зоря", "рейн",
                "миша", "изот", "шарф", "леон", "гуго",
                "гиви", "икар", "саша", "арий", "пров",
                "петя", "ланг", "агей", "сева", "боря"
            };

            return name[number];
        }    
    }
}

class Player
{
    public Player(int number, string name, int lvl, bool ban)
    {
        Number = number;
        Name = name;
        Lvl = lvl;
        Ban = ban;
    }

    public int Number { get; private set;}
    public string Name { get; private set; }
    public int Lvl { get; private set; }
    public bool Ban { get; set; }

    public int GetIndifikator()
    {
        return Number;
    }

    public bool GetStatusBan()
    {
        return Ban;
    }

    public void Print()
    {
        Console.Write(Number + "\t\t");
        Console.Write(Name + "\t\t");
        Console.Write(Lvl + "\t\t");
        Console.Write(Ban + "\n");
    }
}