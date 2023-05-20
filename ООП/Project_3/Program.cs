using System;
using System.Collections.Generic;

namespace Project_3
{
    class Program
    {
        public static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();
            dataBase.Begin();
        }
    }   
}

class DataBase
{
    public void Begin()
    {
        const string AddPlayerCommand = "1";
        const string BanPlayerCommand = "2";
        const string UnBanPlayerCommand = "3";
        const string DeletePlayerCommand = "4";
        const string PrintPlayerCommand = "5";
        const string ExitProgramCommand = "6";

        List<Player> players = new List<Player>();
        bool isWork = true;
        bool banPlayer = false;

        while (isWork)
        {
            Console.WriteLine($"{AddPlayerCommand}. Добавить игрока");
            Console.WriteLine($"{BanPlayerCommand}. Бан игпрока");
            Console.WriteLine($"{UnBanPlayerCommand}. Розбан игрока");
            Console.WriteLine($"{DeletePlayerCommand}. Удалить игрока");
            Console.WriteLine($"{PrintPlayerCommand}. Вывести список игроков");
            Console.WriteLine($"{ExitProgramCommand}. Выход");

            Console.Write($"Введите номер команды - ");

            string command;
            command = Console.ReadLine();

            switch (command.ToLower())
            {
                case AddPlayerCommand:
                    AddPlayer(players);
                    break;

                case BanPlayerCommand:
                    BanPlayer(players, banPlayer);
                    break;

                case UnBanPlayerCommand:
                    BanPlayer(players, banPlayer);
                    break;

                case DeletePlayerCommand:
                    DeletePlayer(players);
                    break;

                case PrintPlayerCommand:
                    PrintBasePlayer(players);
                    break;

                case ExitProgramCommand:
                    isWork = false;
                    break;
            }
        }
    }

    private void AddPlayer(List<Player> players)
    {
        if (RegisterUniqueNumber(players) == 0)
        {
            Console.WriteLine("База игроков переполнена");
        }
        else
        {
            int number = RegisterUniqueNumber(players);
            string name = RegisterUniqueName(players) + Convert.ToString(number);
            int lvl = 1;
            bool isBan = false;
            AddElement(players, number, name, lvl, isBan);
        }
    }

    private void AddElement(List<Player> players, int number, string name, int lvl, bool isBan)
    {
        Player tempPlayer = new Player(number, name, lvl, isBan);
        players.Add(tempPlayer);
    }

    private void BanPlayer(List<Player> players, bool statusBan)
    {
        Console.Write("Введите ID игрока для бана/розбана - ");

        int numberPlayer = GetNumber();

        if(TryGetPlayer(players, numberPlayer))
        {
            foreach (var player in players)
            {
                if(statusBan == false)
                {
                    if (player.Number == numberPlayer)
                    {
                        player.BanPrayer();
                    }
                }
                if (statusBan == true)
                {
                    if (player.Number == numberPlayer)
                    {
                        player.UnBan();
                    }
                }
            }
        }
    }

    private void DeletePlayer(List<Player> players)
    {
        Console.Write("Введите номер ирока для удаления - ");

        int deleteNumberPlayers = GetNumber();

        DeleteElement(players, deleteNumberPlayers);
    }

    private void DeleteElement(List<Player> players, int deleteNumberPlayers)
    {
        int indexDelete = 0;

        foreach (var player in players)
        {
            if (player.Number == deleteNumberPlayers)
            {
                players.RemoveAt(indexDelete);
                break;
            }
            indexDelete++;
        }
    }

    private int RegisterUniqueNumber(List<Player> players)
    {
        const int nextNumber = 1;

        int currentIndex = players.Count + nextNumber;

        return currentIndex;
    }

    private void PrintFirstLine()
    {
        Console.WriteLine("уникальный номер   |\t     имя\t   |    лвл    |    бан(true/false)    ");
    }

    private string RegisterUniqueName(List<Player> players)
    {
        int numberNames = 5;
        int number = RegisterUniqueNumber(players) % numberNames;

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

    private void PrintBasePlayer(List<Player> basePlayer)
    {
        PrintFirstLine();

        foreach (var player in basePlayer)
        {
            player.Print();
        }
    }

    private int GetNumber()
    {
        string line;
        bool isConversionSucceeded = true;
        bool isNumber;
        int number = 0;

        while (isConversionSucceeded)
        {
            line = Console.ReadLine();
            isNumber = int.TryParse(line, out number);

            if (isNumber)
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

    private bool TryGetPlayer(List<Player> players, int number)
    {
        bool isSuccess = false;

        foreach (Player player in players)
        {
            if (number == player.Number)
            {
                return true;
            }
        }

        return isSuccess;
    }
}

class Player
{
    public Player(int number, string name, int lvl, bool isBan)
    {
        Number = number;
        Name = name;
        Lvl = lvl;
        IsBan = isBan;
    }

    public int Number { get; private set; }
    public string Name { get; private set; }
    public int Lvl { get; private set; }
    public bool IsBan { get; private set; }

    public void Print()
    {
        Console.Write(Number + "\t\t");
        Console.Write(Name + "\t\t");
        Console.Write(Lvl + "\t\t");
        Console.Write(IsBan + "\n");
    }

    public void BanPrayer()
    {
        if (IsBan == false)
        {
            Console.WriteLine("Плеер забанен");
            IsBan = true;
        }
        else
        {
            Console.WriteLine("Плеер уже забанен");
        }
    }

    public void UnBan()
    {
        if (IsBan == true)
        {
            Console.WriteLine("Плаер розабанен");
            IsBan = false;
        }
        else
        {
            Console.WriteLine("Плаер уже розабанен");
        }
    }
}
