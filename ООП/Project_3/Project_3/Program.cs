using System;
using System.Collections.Generic;

//Доработать. 1 - первый комментарий из прошлой проверки не был исправлен. Вам нужен еще один класс - Database. В котором будет сосредоточена вся логика работы с базой данных.
//class MainClass - не стоит переименовывать класс Program, он отвечает именно за работу программы. В class Program оставляйте одну функцию Main (можно общую функцию по типу
//ReadInt()), а для всего остального функционала выделяйте дополнительный класс.

//новый класс создан, по поводу переименования class MainClass, ничего не переименововал. не понимаю как исправить и что имеенно имеется в виду.

namespace Project_3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string AddPlayerCommand = "1";
            const string ChangeStatusPlayerCommand = "2";
            const string DeletePlayerCommand = "3";
            const string PrintPlayerCommand = "4";
            const string ExitProgramCommand = "5";

            List<Player> players = new List<Player>();
            DataBase dataBase = new DataBase();
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"{AddPlayerCommand}. Добавить игрока");
                Console.WriteLine($"{ChangeStatusPlayerCommand}. Бан/Розбан");
                Console.WriteLine($"{DeletePlayerCommand}. Удалить игрока");
                Console.WriteLine($"{PrintPlayerCommand}. Вывести список игроков");
                Console.WriteLine($"{ExitProgramCommand}. Выход");

                Console.Write($"Введите номер команды - ");

                string command;
                command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case AddPlayerCommand:
                        dataBase.AddPlayer(players);
                        break;

                    case ChangeStatusPlayerCommand:
                        dataBase.ChangeStatus(players);
                        break;

                    case DeletePlayerCommand:
                        dataBase.DeletePlayer(players);
                        break;

                    case PrintPlayerCommand:
                        dataBase.PrintBasePlayer(players);
                        break;

                    case ExitProgramCommand:
                        isWork = false;
                        break;
                }
            }
        }
    }   
}

class DataBase
{
    public void AddPlayer(List<Player> players)
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

    public void ChangeStatus(List<Player> players)
    {
        const string BanPlayer = "1";
        const string UnBanPlayer = "2";

        string command;
        int numberPlayer;
        bool isWork = true;

        while (isWork)
        {
            Console.WriteLine($"{BanPlayer}.Забанить игрока");
            Console.WriteLine($"{UnBanPlayer}.Розбанить игрока");
            Console.Write($"Введите номер команды - ");
            command = Convert.ToString(GetNumber());
            Console.Write($"Введите номер игрока - ");
            numberPlayer = GetNumber();

            switch (command)
            {
                case BanPlayer:
                    foreach (var player in players)
                    {
                        if (numberPlayer == player.Number)
                        {
                            player.BanPrayer();
                        }
                    }
                    isWork = false;
                    break;

                case UnBanPlayer:
                    foreach (var player in players)
                    {
                        if (numberPlayer == player.Number)
                        {
                            player.UnBanPrayer();
                        }
                    }
                    isWork = false;
                    break;
            }
        }
    }

    public void DeletePlayer(List<Player> players)
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
        bool isNewNumber = true;
        bool repick = false;
        int repicks = 0;
        int randomNumber = 0;
        Random random = new Random();

        if(players.Count == 0)
        {
            randomNumber = random.Next();
        }
        else
        {
            while(isNewNumber)
            {
                repick = false;
                randomNumber = random.Next();

                foreach (var player in players)
                {
                    if(player.Number == randomNumber)
                    {
                        repick = true;
                    }
                }

                if (repick == false)
                {
                    isNewNumber = false;
                }

                repicks++;

                if (repick == true && repicks > int.MaxValue)
                {
                    return 0;
                }
            }
        }
        return randomNumber;
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

    public void PrintBasePlayer(List<Player> basePlayer)
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

        foreach (var player in players)
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
    public Player(int number, string name, int lvl, bool ban)
    {
        Number = number;
        Name = name;
        Lvl = lvl;
        Ban = ban;
    }

    public int Number { get; private set; }
    public string Name { get; private set; }
    private int Lvl { get; set; }
    private bool Ban { get; set; }

    public void Print()
    {
        Console.Write(Number + "\t\t");
        Console.Write(Name + "\t\t");
        Console.Write(Lvl + "\t\t");
        Console.Write(Ban + "\n");
    }

    public string Names()
    {
        return this.Names();
    }

    public bool BanPrayer()
    {
        if (this.Ban == false)
        {
            Console.WriteLine("Плаер забанен");
            return this.Ban = true;
        }
        else
        {
            Console.WriteLine("Плаер уже забанен");
            return this.Ban;
        }
    }

    public bool UnBanPrayer()
    {
        if (this.Ban == true)
        {
            Console.WriteLine("Плаер розабанен");
            return this.Ban = false;
        }
        else
        {
            Console.WriteLine("Плаер уже розабанен");
            return this.Ban;
        }
    }
}
