using System;
using System.Collections.Generic;

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
                        AddPlayer(players);
                        break;

                    case ChangeStatusPlayerCommand:
                        ChangeStatus(players);
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

        static void AddPlayer(List<Player> players)
        {
            int number = RegisterUniqueNumber(players);
            string name = RegisterUniqueName(players) + Convert.ToString(number);
            int lvl = 1;
            bool isBan = false;
            AddElement(players, number, name, lvl, isBan);
        }

        static void AddElement(List<Player> players, int number, string name, int lvl, bool isBan)
        {
            Player tempPlayer = new Player(number, name, lvl, isBan);
            players.Add(tempPlayer);
            Console.WriteLine(tempPlayer);
        }

        static void ChangeStatus(List<Player> players)
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
                            if (numberPlayer == player.GetNumber())
                            {
                                player.BanPrayer();
                            }
                        }
                        isWork = false;
                        break;

                    case UnBanPlayer:
                        foreach (var player in players)
                        {
                            if (numberPlayer == player.GetNumber())
                            {
                                player.UnBanPrayer();
                            }
                        }
                        isWork = false;
                        break;
                }
            }
        }

        static void DeletePlayer(List<Player> players)
        {
            Console.Write("Введите номер ирока для удаления - ");

            int deleteNumberPlayers = GetNumber();

            DeleteElement(players, deleteNumberPlayers);
        }

        static void DeleteElement(List<Player> players, int deleteNumberPlayers)
        {
            int indexDelete = 0;

            foreach (var player in players)
            {
                if(player.GetNumber() == deleteNumberPlayers)
                {
                    players.RemoveAt(indexDelete);
                    break;
                }
                indexDelete++;
            }
        }       

        static public int RegisterUniqueNumber(List<Player> players)
        {
            bool newNumber = false;
            int randomNumber = 0;
            Random random = new Random();

            randomNumber = random.Next();

            while (newNumber)
            {
                foreach (var number in players)
                {
                    if (number.GetNumber()== randomNumber)
                    {
                        randomNumber = random.Next();
                    }
                    else
                    {
                        newNumber = true;
                    }
                }
            }

            return randomNumber;
        }

        static void PrintFirstLine()
        {
            Console.WriteLine("уникальный номер   |\t     имя\t   |    лвл    |    бан(true/false)    ");
        }

        static public string RegisterUniqueName(List<Player> players)
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

        static void PrintBasePlayer(List<Player> basePlayer)
        {
            PrintFirstLine();

            foreach (var player in basePlayer)
            {
                player.Print();
            }
        }

        static int GetNumber()
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

        static bool TryGetPlayer(List<Player> players, int number)
        {
            bool isSuccess = false;

            foreach (var player in players)
            {
                if(number == player.GetNumber())
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

        private int Number { get; set; }
        private string Name { get; set; }
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
            if(this.Ban == false)
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

        public int GetNumber()
        {
            return Number;
        }

        public string GetName()
        {
            return Name;
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
}