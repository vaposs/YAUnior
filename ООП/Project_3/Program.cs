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
    List<Player> players = new List<Player>();
    int _currentIndex = 1;

    public void Begin()
    {
        const string AddPlayerCommand = "1";
        const string BanPlayerCommand = "2";
        const string UnBanPlayerCommand = "3";
        const string DeletePlayerCommand = "4";
        const string PrintPlayerCommand = "5";
        const string ExitProgramCommand = "6";

        bool isWork = true;

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
                    AddPlayer();
                    break;

                case BanPlayerCommand:
                    BanPlayer();
                    break;

                case UnBanPlayerCommand:
                    Unban();
                    break;

                case DeletePlayerCommand:
                    DeletePlayer();
                    break;

                case PrintPlayerCommand:
                    PrintBasePlayer();
                    break;

                case ExitProgramCommand:
                    isWork = false;
                    break;
            }
        }
    }

    private void AddPlayer()
    {
        int number = _currentIndex++;
        string name = RegisterUniqueName();
        int lvl = 1;
        bool isBan = false;
        Player tempPlayer = new Player(number, name, lvl, isBan);
        players.Add(new Player(number,name,lvl,isBan));
    }

    private void BanPlayer()
    {
        Player tempPlayer;

        Console.Write("Введите ID игрока для бана - ");

        tempPlayer = TryGetPlayer();

        if(tempPlayer == null)
        {
            Console.WriteLine("такого плеера нету");
        }
        else
        {
            tempPlayer.BanPrayer();
        }
    }

    private void Unban()
    {
        Player tempPlayer;

        Console.Write("Введите ID игрока для бана - ");

        tempPlayer = TryGetPlayer();

        if (tempPlayer == null)
        {
            Console.WriteLine("такого плеера нету");
        }
        else
        {
            tempPlayer.Unban();
        }
    }

    private void DeletePlayer()
    {
        Player tempPlayer;

        Console.Write("Введите номер ирока для удаления - ");

        tempPlayer = TryGetPlayer();

        if (tempPlayer == null)
        {
            Console.WriteLine("такого плеера нету");
        }
        else
        {
            players.Remove(tempPlayer);
        }
    }

    private void PrintFirstLine()
    {
        Console.WriteLine("уникальный номер   |\t     имя\t   |    лвл    |    бан(true/false)    ");
    }

    private string RegisterUniqueName()
    {
        int numberNames = 44;
        Random random = new Random();
        int number = random.Next() % numberNames;

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

    private void PrintBasePlayer()
    {
        PrintFirstLine();

        foreach (Player player in players)
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

    private Player TryGetPlayer()
    {
        int number = GetNumber();

        foreach (Player player in players)
        {
            if (number == player.Number)
            {
                return player;
            }
        }
        return null;
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

    public void Unban()
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